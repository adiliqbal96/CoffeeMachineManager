using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineManager.Models
{
    public class CoffeeMachine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Location { get; set; }

        [StringLength(100)]
        public string? Type { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Default: "Active"
    }
}
