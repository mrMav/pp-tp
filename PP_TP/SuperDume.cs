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
        public void ListShoppingCart(List<Product> cart)
        {
            if (cart.Count > 0)
            {
                foreach (Product p in cart)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Utils.PrintError("Shopping Cart is empty!");
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
        public void ListPurchases(Client cc)
        {
            if (cc.Card.Purchases != null)
            {
                foreach (Purchase p in cc.Card.Purchases)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Utils.PrintError("No purchases were made!");
            }
        }

        public void DeleteProduct(Product p)
        {
            Stock.Remove(p);   
        }

        public void AddClient(string name, string adress, string phoneNumber, string email, string cc, string nif)
        {
           Clients.Add(new Client(name, adress, phoneNumber, email, cc, nif));
        }

        //BUG HERE
        public void MakePurchase(Client c, List<Product> cart, string desc, int quant, float pTotal)
        {
            int accPoints;

            accPoints = (int)Math.Floor(pTotal % 50);
            c.Card.Purchases.Add(new Purchase(cart, "", quant, pTotal, accPoints));
            c.Card.CardPoints += accPoints;
        }
    }
}
