using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();

builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();

builder.Services.AddScoped<IDisordersRepository, DisordersRepository>();
builder.Services.AddScoped<IDisordersUnitOfWork, DisordersUnitOfWork>();

builder.Services.AddScoped<IDocumentTypesRepository, DocumentTypesRepository>();
builder.Services.AddScoped<IDocumentTypesUnitOfWork, DocumentTypesUnitOfWork>();

builder.Services.AddScoped<IPsychologistsRepository, PsychologistsRepository>();
builder.Services.AddScoped<IPsychologistsUnitOfWork, PsychologistsUnitOfWork>();

builder.Services.AddScoped<IResourcesRepository, ResourcesRepository>();
builder.Services.AddScoped<IResourcesUnitOfWork, ResourcesUnitOfWork>();

builder.Services.AddScoped<IResourcesDisorderRepository, ResourcesDisorderRepository>();
builder.Services.AddScoped<IResourcesDisorderUnitOfWork, ResourcesDisorderUnitOfWork>();

builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<IStatesUnitOfWork, StatesUnitOfWork>();

builder.Services.AddScoped<ITerapiesRepository, TerapiesRepository>();
builder.Services.AddScoped<ITerapiesUnitOfWork, TerapiesUnitOfWork>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersUnitOfWork, UsersUnitOfWork>();

var app = builder.Build();

SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();