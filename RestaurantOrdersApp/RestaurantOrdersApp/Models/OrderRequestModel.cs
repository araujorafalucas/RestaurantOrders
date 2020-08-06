using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApp.Models
{
    public class OrderRequestModel
    {
        [DisplayName("Entrada")]
        public string Input { get; set; }
        [DisplayName("Saída")]
        public string Output { get; set; }
    }
}
