using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class Product
    {
         int Code { get; set; }
         string Description { get; set; }
         float Price { get; set; }
         int Quantity { get; set; }        

        public Product (int code, float price) {
            this.Code = code;
            this.Description = "";
            this.Price = price;
            this.Quantity = 0;
        }
    }
}
