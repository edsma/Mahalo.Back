using Mahalo.Shared.Entities;

namespace Mahalo.Test.Mocks
{
    public static class CitiesMock
    {
        public static List<City> GetAllCities()
        {
            return new List<City>
            {
               new City
               {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "Azeroth",
                    State = StatesMock.GetAllStates().FirstOrDefault()
               }
            };
        }
    }
}
