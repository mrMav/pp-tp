using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    [Serializable]
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
                    Utils.PrintListItem(p.ToString());
                }
            }
            else
            {
                Utils.PrintError("No products found.");
            }
        }
        public void ListShoppingCart(List<Product> cart)
        {
            if (cart.Count > 0)
            {
                foreach (Product p in cart)
                {
                    Utils.PrintListItem(p.ToString());
                }
            }
            else
            {
                Utils.PrintError("Shopping Cart is empty.");
            }
        }
        public void ListClients()
        {
            if (Clients.Count > 0)
            {
                foreach (Client c in Clients)
                {
                    Utils.PrintListItem(c.ToString());
                }
            }
            else
            {
                Utils.PrintError("No clients found.");
            }
        }
        public void ListPurchases(ClientCard card)
        {
            if (card.Purchases.Count > 0)
            {
                foreach (Purchase p in card.Purchases)
                {
                    Utils.PrintListItem(p.ToString());
                }
            }
            else
            {
                Utils.PrintError("No purchases were made.");
            }
        }

        public void DeleteProduct(Product p)
        {
            Stock.Remove(p);
            Console.WriteLine("Product deleted.");
        }

        public void AddClient(string name, string adress, string phoneNumber, string email, string cc, string nif)
        {
           Clients.Add(new Client(name, adress, phoneNumber, email, cc, nif));
        }

        public void MakePurchase(Client c, List<Product> cart, string desc, int quant, float pTotal)
        {
            int accPoints;

            accPoints = (int)Math.Floor(pTotal / 50);
            c.Card.Purchases.Add(new Purchase(cart, desc, quant, pTotal, accPoints));
            c.Card.CardPoints += accPoints;
        }

        public void CheckBalance(ClientCard cc) {
            float total = 0;

            foreach (Purchase p in cc.Purchases)
                total += p.PurchaseTotal;

            Console.WriteLine("Total spent: " + total + ", Points in Card: " + cc.CardPoints);
        }
    }
}
