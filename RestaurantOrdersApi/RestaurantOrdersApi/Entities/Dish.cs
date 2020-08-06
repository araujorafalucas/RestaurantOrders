using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Entities
{
    [Table("Dishes")]
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsEnable { get; set; }
        [Required]
        public int DishTypeId { get; set; }
        public DishType DishType { get; set; }
        public List<MealTime> MealTimes { get; set; }

    }
}
