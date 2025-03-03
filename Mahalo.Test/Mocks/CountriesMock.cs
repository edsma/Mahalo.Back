using Mahalo.Shared.Entities;

namespace Mahalo.Test.Mocks
{
    public static class CountriesMock
    {
        public static List<Country> GetAllCountries()
        {
            return new List<Country>
            {
               new Country
               {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "WonderLand",
                    States = StatesMock.GetAllStates()
               }
            };
        }
    }
}
