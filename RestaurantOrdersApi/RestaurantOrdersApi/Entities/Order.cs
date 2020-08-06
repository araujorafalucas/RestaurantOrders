using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int MealTimeId { get; set; }
        public MealTime MealTime { get; set; }
        [Required]
        public DateTime OrderedDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public bool HasInputError { get; set; }
        public string RequestedOrder { get; set; }
    }
}
