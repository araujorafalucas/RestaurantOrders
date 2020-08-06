using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Entities
{
    [Table("MealTimes")]
    public class MealTime
    {
        [Key]
        public int MealTimeId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsEnable { get; set; }
        public List<Dish> Dishes { get; set; }

    }
}
