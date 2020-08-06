using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Entities
{
    [Table("DishesMealTimes")]
    public class DishMealTime
    {
        [Required]
        public int DishId { get; set; }

        public Dish Dish { get; set; }
        [Required]
        public int MealTimeId { get; set; }

        public MealTime MealTime { get; set; }
        public int MaxAllowed { get; set; }
    }
}
