namespace Mahalo.Shared.DTOs
{
    public class PsychologistsDTO
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public double XCoordinate { get; set; } = 0;

        public double YCoordinate { get; set; } = 0;

        public DateTime OfficeStart { get; set; }

        public DateTime OfficeEnd { get; set; }

        public double TerapyPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
