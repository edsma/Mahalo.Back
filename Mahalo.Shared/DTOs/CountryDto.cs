namespace Mahalo.Shared.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<StateDto>? States { get; set; } = null;
    }
}
