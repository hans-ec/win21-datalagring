using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Models
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
