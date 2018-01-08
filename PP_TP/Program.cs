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

            SuperDume superdume = new SuperDume();

            int option = -1;
            do
            {
                Console.ForegroundColor = System.ConsoleColor.Green;
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
                                Console.WriteLine("0 - Exit");
                                Console.WriteLine("--------------------------");

                                option = int.Parse(Console.ReadLine());

                                switch (option)
                                {
                                    case 1:

                                        // list products

                                        superdume.ListProducts();

                                        break;

                                    case 2:

                                        // add new product

                                        string desc;
                                        float price;
                                        int quant;

                                        Console.WriteLine("-> Input new product code:");
                                        int inputedCode = int.Parse(Console.ReadLine());

                                        int checkExists = CheckProductExists(superdume, inputedCode);

                                        if (checkExists == -1)
                                        {

                                            Console.WriteLine("-> Input new product description:");
                                            desc = Console.ReadLine();

                                            Console.WriteLine("-> Input new product price:");
                                            price = float.Parse(Console.ReadLine());

                                            Console.WriteLine("-> Input new product quantity:");
                                            quant = int.Parse(Console.ReadLine());
                                            
                                            superdume.AddProduct(inputedCode, desc, price, quant);

                                        }
                                        else
                                        {

                                            Console.WriteLine("Product code already in use!");

                                        }

                                        break;

                                    case 3:

                                        break;

                                    case 4:

                                        break;

                                }

                            } while (option != 0);

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
                                    Console.WriteLine("3 - Select Client");                                 
                                    Console.WriteLine("0 - Exit");
                                    Console.WriteLine("--------------------------");

                                    option = int.Parse(Console.ReadLine());

                                    switch (option)
                                    {
                                        case 1:


                                            break;

                                        case 2:
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

                                        case 3:
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
        /*
         * return -1 if not found, otherwise, returns inputed code
         */
        public static int SelectProduct(SuperDume s)
        {
            // get input from user
            int input = int.Parse(Console.ReadLine());

            return CheckProductExists(s, input);

        }

        /*
         * return -1 if not found, otherwise, returns inputed code
         */
        public static int CheckProductExists(SuperDume s, int code)
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
                        return code;
                    }

                }

            }

            // this means that no product was found
            return -1;

        }

    }
}
