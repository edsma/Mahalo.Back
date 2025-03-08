using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Id { get; set; }

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 6;

        public string? Filter { get; set; }

        public string? UserId { get; set; }

    }
}