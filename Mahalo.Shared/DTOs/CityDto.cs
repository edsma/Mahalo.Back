
namespace Mahalo.Shared.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }


        public string? Name { get; set; } // El signo de interrogación permite valores nulos.


        public bool IsActive { get; set; }

        public int StateId { get; set; }



        public DateTime CreationDate { get; set; }

        public StateDto? State { get; set; }
    }
}
