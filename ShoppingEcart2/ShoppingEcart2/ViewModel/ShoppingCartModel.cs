using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingEcart2.Models;

namespace ShoppingEcart2.ViewModel
{
    public class ShoppingCartModel
    {
        public Item ItemDB { get; set; }
        public string ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string ImagePath { get; set; }
        public string ItemName { get; set; }

    }
} 