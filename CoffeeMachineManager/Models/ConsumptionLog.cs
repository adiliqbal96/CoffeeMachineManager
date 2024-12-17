using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMachineManager.Models
{
    public class ConsumptionLog
    {
        public int Id { get; set; }

        [ForeignKey("CoffeeMachine")]
        public int CoffeeMachineId { get; set; }

        public CoffeeMachine CoffeeMachine { get; set; }

        [Required]
        public int CoffeeUsed { get; set; } // Coffee consumption in grams

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
