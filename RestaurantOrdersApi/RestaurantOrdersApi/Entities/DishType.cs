using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Entities
{
    [Table("DishTypes")]
    public class DishType
    {
        [Key]
        public int DishTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Sequence { get; set; }
        public bool IsEnable { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
