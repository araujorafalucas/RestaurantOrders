using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.RequestModels
{
    public class OrderRequest
    {
        [Required]
        public string Input { get; set; }
    }
}
