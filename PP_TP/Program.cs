using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = System.ConsoleColor.Green;

            SuperDume superdume = new SuperDume();

            int option = -1;
            int optionStockManager = -1;
            int optionClientsManager = -1;
            do
            {
                Console.WriteLine("----------:.SuPeRDuMe.:-------");
                Console.WriteLine("1 - Stock Manager");
                Console.WriteLine("2 - Client Manager");
                Console.WriteLine("3 - Save Data");
                Console.WriteLine("4 - Load Data");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Input option:");

                option = int.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                        {
                            // stock manager
                            
                            do
                            {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("1 - List Products");
                                Console.WriteLine("2 - Add New Product");
                                Console.WriteLine("3 - Update Stock");
                                Console.WriteLine("4 - Delete Product");
                                Console.WriteLine("0 - Back");
                                Console.WriteLine("--------------------------");

                                optionStockManager = int.Parse(Console.ReadLine());

                                switch (optionStockManager)
                                {
                                    case 1:

                                        // list products

                                        superdume.ListProducts();

                                        break;

                                    case 2:

                                        // add new product

                                        AddProduct(superdume);

                                        break;

                                    case 3:

                                        // update stock

                                        UpdateStock(superdume);

                                        break;

                                    case 4:

                                        // delete product

                                        break;

                                }

                            } while (optionStockManager != 0);

                            break;
                        }
                    case 2:
                        {
                            // Client Manager

                            do
                            {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("1 - Add New Client");
                                Console.WriteLine("2 - List Clients");
                                Console.WriteLine("3 - Client Actions");
                                Console.WriteLine("0 - Exit");
                                Console.WriteLine("--------------------------");

                                option = int.Parse(Console.ReadLine());

                                switch (option)
                                {
                                    case 1:
                                        // Add new client

                                        AddClient(superdume);

                                        break;

                                    case 2:
                                        //List Clients
                                        

                                        break;

                                    case 3:

                                        // Client Actions
                                        do
                                        {
                                            Console.WriteLine("--------------------------");
                                            Console.WriteLine("1 - Make Purchase");
                                            Console.WriteLine("2 - List Purchases");
                                            Console.WriteLine("3 - Check Balance");
                                            Console.WriteLine("0 - Exit");
                                            Console.WriteLine("--------------------------");

                                            option = int.Parse(Console.ReadLine());

                                            switch (option)
                                            {
                                                case 1:

                                                    break;

                                                case 2:


                                                    break;

                                                case 3:
                                                    break;

                                                case 0:

                                                    break;

                                            }

                                        } while (option != 0);
                                        break;

                                    case 0:

                                        break;

                                }

                            } while (option != 0);

                            break;

                        }
                    case 3:
                        {

                            break;

                        }
                    case 4:
                        {

                            break;
                        }
                    case 0: break;
                };

            } while (option != 0);

        }

        #region ProductManagement

        /*
         * return -1 if not found, otherwise, returns inputed code
         */
        public static Product CheckProductExists(SuperDume s, int code)
        {
            // if stock is not empty
            if (s.Stock.Count > 0)
            {

                // cycle each product in stock
                foreach (Product p in s.Stock)
                {

                    // if the product code is found
                    if (p.Code == code)
                    {
                        return p;
                    }

                }

            }

            // this means that no product was found
            return null;

        }

        /*
         *  Adds a new product to the specified SuperDume
         */
        public static void AddProduct(SuperDume s)
        {
            string desc;
            float price;
            int quant;

            Console.WriteLine("-> Input new product code:");
            int inputedCode = int.Parse(Console.ReadLine());

            Product product = CheckProductExists(s, inputedCode);

            if (product == null)
            {

                Console.WriteLine("-> Input new product description:");
                desc = Console.ReadLine();

                Console.WriteLine("-> Input new product price:");
                price = float.Parse(Console.ReadLine());

                Console.WriteLine("-> Input new product quantity:");
                quant = int.Parse(Console.ReadLine());

                s.AddProduct(inputedCode, desc, price, quant);

            }
            else
            {

                Utils.PrintError("Product code already in use!");

            }
        }

        /*
         *  updates a selected product
         */
        public static void UpdateStock(SuperDume s)
        {
            float price;
            int quant;

            Console.WriteLine("-> Input desired product code to modify:");
            int inputedCode = int.Parse(Console.ReadLine());

            Product product = CheckProductExists(s, inputedCode);

            if (product != null)
            {

                Console.WriteLine("Selected product: ");
                Console.WriteLine(product);

                Console.WriteLine("-> Input new product price:");
                price = float.Parse(Console.ReadLine());

                Console.WriteLine("-> Input new product quantity:");
                quant = int.Parse(Console.ReadLine());

                product.Price = price;
                product.Quantity = quant;

                Console.WriteLine("Product modified with sucess!");

            }
            else
            {

                Utils.PrintError("Product code does not exists!");

            }
        }

        public static void DeleteProduct(SuperDume s)
        {

            Console.WriteLine("-> Input desired product code to delete:");
            int inputedCode = int.Parse(Console.ReadLine());

            Product product = CheckProductExists(s, inputedCode);

            if(product != null)
            {
                s.DeleteProduct(product);

                Console.WriteLine("Product removed sucessfully.");

            } else
            {

                Utils.PrintError("Specified code not found in stock!\nNothing happened.");

            }

        }

        #endregion ProductManagment

        //Function to check for Id cards already made
        public static Client CheckClientExists(SuperDume s, string cc)
        {
            //
            if (s.Clients.Count > 0)
            {

                foreach (Client c in s.Clients)
                {
                    if (c.CC == cc)
                    {
                        return c;
                    }

                }
            }
            return null;
        }

        //Adds clients
        public static void AddClient(SuperDume s)
        {
            string name, adress, email, phoneNumber, cc, nif;
            Client client;


            Console.WriteLine("\n-> Enter ID card");
            cc = Console.ReadLine();

            client = CheckClientExists(s, cc);

            if (client == null)
            {

                Console.WriteLine("-> Enter Full Name");
                name = Console.ReadLine();

                Console.WriteLine("\n-> Enter Adress");
                adress = Console.ReadLine();

                Console.WriteLine("\n-> Enter Email");
                email = Console.ReadLine();

                Console.WriteLine("\n-> Enter Phone Number");
                phoneNumber = Console.ReadLine();

                Console.WriteLine("\n-> Enter Tax Number");
                nif = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Client already exists");
            }



        }

    }
}
