using Mahalo.Back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq.Expressions;

namespace Mahalo.Test
{
    public class MahaloContextMock
    {
        public static Mock<DataContext> GetDbContext()
        {
            var dbName = Guid.NewGuid().ToString();
            var dbOptions = new DbContextOptionsBuilder<DataContext>()
                        .UseInMemoryDatabase(dbName)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                        .EnableSensitiveDataLogging(true)
                        .Options;
            return new Mock<DataContext>(dbOptions) { CallBase = true };
        }

        public static Mock<DbSet<T>> CreateMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            // Configurar como IQueryable
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<T>(queryable.Provider));
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            // Configurar como IAsyncEnumerable
            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(new TestAsyncEnumerator<T>(queryable.GetEnumerator()));

            return mockSet;
        }




        private class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
        {
            private readonly IQueryProvider _inner;

            public TestAsyncQueryProvider(IQueryProvider inner)
            {
                _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            }

            public IQueryable CreateQuery(Expression expression) => _inner.CreateQuery(expression);

            public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => _inner.CreateQuery<TElement>(expression);



            public object? Execute(Expression expression) => _inner.Execute(expression);

            public TResult Execute<TResult>(Expression expression) => (TResult)_inner.Execute(expression)!;

            // Implementación del método ExecuteAsync<TResult> para cumplir con la interfaz IAsyncQueryProvider
            public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
            {
                // Realiza la ejecución de la expresión de manera sincrónica
                TResult result = Execute<TResult>(expression);

                // Devuelve el resultado envuelto en una tarea asincrónica (Task<TResult>)
                return Task.FromResult(result);
            }

            TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
            {
                var t = Expression.Lambda(expression).Compile().DynamicInvoke();
                if (t == null)
                {
                    // Si TResult es un tipo de referencia, devuelve null. 
                    // Si TResult es un tipo de valor, devuelve su valor por defecto.
                    return typeof(TResult).IsClass || Nullable.GetUnderlyingType(typeof(TResult)) != null
                        ? (TResult)(object)null
                        : Activator.CreateInstance<TResult>();
                }

                return Task.FromResult(t as dynamic);
            }


        }



        private class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
        {
            private readonly IEnumerator<T> _inner;

            public TestAsyncEnumerator(IEnumerator<T> inner)
            {
                _inner = inner;
            }

            public T Current => _inner.Current;

            public ValueTask DisposeAsync() => new ValueTask(Task.CompletedTask);

            public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(Task.FromResult(_inner.MoveNext()));
        }
    }
}
