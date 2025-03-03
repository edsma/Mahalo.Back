using Mahalo.Shared.Entities;

namespace Mahalo.Test.Mocks
{
    public static class StatesMock
    {
        public static List<State> GetAllStates()
        {
            return new List<State>
            {
                new State
                {
                    Id = 1,
                    Name = "Kalimdor",
                    IsActive = true,
                    CreationDate = DateTime.Now,
                }
            };
        }
    }
}
