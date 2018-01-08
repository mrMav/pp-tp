using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class Product
    {
         public int Code { get; set; }
         public string Description { get; set; }
         public float Price { get; set; }
         public int Quantity { get; set; }

        public Product (int code, string desc, float price, int quant)
        {
            this.Code = code;
            this.Description = desc;
            this.Price = price;
            this.Quantity = quant;
        }

        public override string ToString()
        {
            return "Code: " + this.Code + ", Description: " + this.Description + ", Price: " + this.Price + ", Quantity: " + this.Quantity;
            
        }
    }
}
