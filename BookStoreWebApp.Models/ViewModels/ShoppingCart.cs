using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models.ViewModels
{
    public class ShoppingCart
    {
        public Product Product { get; set; }

        [Range(0, 1000, ErrorMessage="Cart count should be between 1-1000")]
        public int Count { get; set; }
    }
}
