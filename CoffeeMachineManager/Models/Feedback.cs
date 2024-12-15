using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMachineManager.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [ForeignKey("CoffeeMachine")]
        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }

        [Required]
        public string FeedbackText { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Default: "Pending"
    }
}
