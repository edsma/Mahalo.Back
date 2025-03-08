namespace Mahalo.Shared.DTOs
{
    public class StateDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<CityDto>? Cities { get; set; }
        public CountryDto? Country { get; set; } = null;
    }
}
