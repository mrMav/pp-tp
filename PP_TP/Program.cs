using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                                        { // delete product
                                            Product p;

                                            Console.WriteLine("Select Product: ");
                                            p = CheckProductExists(superdume, int.Parse(Console.ReadLine()));
                                            if (p == null)
                                                Utils.PrintError("Wrong code/Product does not exist");
                                            else
                                                superdume.DeleteProduct(p);
                                            break;
                                        }

                                }
                            } while (optionStockManager != 0);

                            break;
                        }
                    case 2:
                        {
                            ClientManagerMenu(superdume);
                            break;

                        }
                    case 3:
                        {
                            WriteBinFile(superdume, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\superdume.bin");
                            break;
                        }
                    case 4:
                        {
                            superdume = ReadBinFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\superdume.bin");
                            if (superdume == null)
                            {
                                Utils.PrintError("There is no saved data");
                                superdume = new SuperDume();
                            }
                            
                            break;
                        }
                    case 0: break;
                };

            } while (option != 0);
        }

        #region ProductManagement

        /*
         * return null if not found, otherwise, returns found product
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

            if (product != null)
            {
                s.DeleteProduct(product);

                Console.WriteLine("Product removed sucessfully.");

            }
            else
            {

                Utils.PrintError("Specified code not found in stock!\nNothing happened.");

            }

        }

        #endregion ProductManagment

        #region ClientManagement

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

        //Choose Client
        public static void ChooseClientMenu(SuperDume superdume)
        {
            int optionClientActions = -1;
            Client cc;

            Console.WriteLine("Choose a client: ");
            cc = CheckClientExists(superdume, Console.ReadLine());
            if (cc == null)
                Utils.PrintError("Incorrect CC/Client doest not exist.");
            else
            {
                // Client Actions
                do
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1 - Make Purchase");
                    Console.WriteLine("2 - List Purchases");
                    Console.WriteLine("3 - Check Balance");
                    Console.WriteLine("0 - Back");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Input option:");

                    optionClientActions = int.Parse(Console.ReadLine());

                    switch (optionClientActions)
                    {
                        case 1:
                            MakePurchase(superdume, cc);
                            break;
                        case 2:
                            superdume.ListPurchases(cc.Card);
                            break;
                        case 3:
                            break;

                    }
                } while (optionClientActions != 0);
            }
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

                s.AddClient(name, adress, phoneNumber, email, cc, nif);
            }
            else
            {
                Console.WriteLine("Client already exists");
            }
        }

        #endregion ClientManagement

        // Client Manager
        public static void ClientManagerMenu(SuperDume superdume)
        {
            int optionClientsManager = -1;

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1 - Add New Client");
                Console.WriteLine("2 - List Clients");
                Console.WriteLine("3 - Client Actions");
                Console.WriteLine("0 - Back");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Input option:");

                optionClientsManager = int.Parse(Console.ReadLine());

                switch (optionClientsManager)
                {
                    case 1:
                        // Add new client

                        AddClient(superdume);

                        break;

                    case 2:
                        //List Clients
                        superdume.ListClients();

                        break;

                    case 3:
                        {
                            ChooseClientMenu(superdume);
                            break;
                        }

                    case 0:

                        break;

                }

            } while (optionClientsManager != 0);
        }

        public static void MakePurchase(SuperDume s, Client c)
        {
            bool canAdd = true;
            int optionMakePurchase = -1, nItems = 0;
            float pTotal = 0;

            Product productCode;
            List<Product> cart = new List<Product>();
            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1 - Add Product to Shopping Cart");
                Console.WriteLine("2 - Shopping Cart");
                Console.WriteLine("3 - List Products");
                Console.WriteLine("4 - End purchase");
                Console.WriteLine("0 - Back");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Input option:");

                optionMakePurchase = int.Parse(Console.ReadLine());

                switch (optionMakePurchase)
                {
                    case 1:
                        Console.WriteLine("Select Product: ");
                        productCode = CheckProductExists(s, int.Parse(Console.ReadLine()));
                        if (productCode == null)
                            Utils.PrintError("Wrong code/Product does not exist");
                        else
                        {
                            if (productCode.Quantity >= 1)
                            {
                                foreach (Product p in cart)
                                {
                                    if (productCode.Code == p.Code)
                                    {
                                        p.Quantity += 1;
                                        canAdd = false;
                                    }
                                }
                                if (canAdd == true)
                                    cart.Add(new Product(productCode.Code, productCode.Description, productCode.Price, 1));

                                pTotal += productCode.Price;
                                nItems += 1;
                                productCode.Quantity -= 1;
                            }
                            else
                                Utils.PrintError("Out of stock!");
                        }
                        break;
                    case 2:
                        s.ListShoppingCart(cart);
                        break;
                    case 3:
                        s.ListProducts();
                        break;
                    case 4:
                        {
                            if (nItems > 0)
                            {
                                s.MakePurchase(c, cart, "", nItems, pTotal);
                                optionMakePurchase = 0;
                            }
                            else
                                Utils.PrintError("Shopping Cart is empty!");
                        }
                        break;
                }
            } while (optionMakePurchase != 0);
        }

        //Save data to .bin file

        //If file already exists it will be replaced with the newer version

        //ERROR STARTING HERE!!!!!!!!!!!!!
        public static void WriteBinFile<SuperDume>(SuperDume s, string caminhoFicheiro, bool append = false)
        {
                using (Stream stream = File.Open(caminhoFicheiro, append ? FileMode.Append : FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, s);
                }

        }

        static SuperDume ReadBinFile(string caminhoFicheiro)
        {
            SuperDume s = null;
            if (File.Exists(caminhoFicheiro))
            {
                Stream stream = File.Open(caminhoFicheiro, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                s = (SuperDume)bf.Deserialize(stream);
                stream.Close();
            }
            return s;
        }

    }
}