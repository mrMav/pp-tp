using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class SuperDume
    {
        public List<ClientCard> ClientCards { get; set; }
        public List<Product> Stock { get; set; }

        public void AddProduct(int code, string desc, float price, int quant)
        {
            Stock.Add(new Product(code, desc, price, quant));
        }

        public void ListProducts(int code, string desc, float price, int quant)
        {
            foreach(Product p in Stock)
            {
                Console.WriteLine(p);
            }
        }
        public void DeleteProduct(int code)
        {

        }

        public void AddClient(int code, string desc, float price, int quant)
        {
            Stock.Add(new Product(code, desc, price, quant));
        }
    }
}
