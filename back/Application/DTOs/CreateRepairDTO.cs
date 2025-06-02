using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateRepairDTO
    {
        [Required]
        public int ItemId { get; set; }
        
        [Required]
        public int CreatorId { get; set; }
    }
}