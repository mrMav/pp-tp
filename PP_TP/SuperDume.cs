using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class SuperDume
    {
        public List<Client> Clients { get; set; }
        public List<Product> Stock { get; set; }

        // constructor
        public SuperDume()
        {

            this.Clients = new List<Client>();
            this.Stock = new List<Product>();

        }

        public void AddProduct(int code, string desc, float price, int quant)
        {
            Stock.Add(new Product(code, desc, price, quant));
        }

        public void ListProducts()
        {
            if(Stock.Count > 0)
            {
                foreach(Product p in Stock)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Utils.PrintError("No products found!");
            }
        }
        public void ListClients()
        {
            if (Clients.Count > 0)
            {
                foreach (Client c in Clients)
                {
                    Console.WriteLine(c);
                }
            }
            else
            {
                Utils.PrintError("No clients found!");
            }
        }
        public void DeleteProduct(Product p)
        {
            Stock.Remove(p);   
        }

        public void AddClient()
        {

            // TODO: colocar parametros no constructor abaixo
            //ClientCards.Add(new Client());
        }
    }
}
