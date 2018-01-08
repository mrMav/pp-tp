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
                Console.WriteLine("----------:.SuPeRDuMe.:-------\n");
                Console.WriteLine("1 - Stock Manager");
                Console.WriteLine("2 - Cliente Manager");
                Console.WriteLine("3 - Save Data");
                Console.WriteLine("4 - Load Data");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine("Input option:");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            
                            Console.WriteLine("1 - List Products");
                            Console.WriteLine("2 - Add New Product");
                            Console.WriteLine("3 - Update Stock");
                            Console.WriteLine("4 - Delete Product");
                            Console.WriteLine("0 - Exit");

                            option = int.Parse(Console.ReadLine());

                            switch (option)
                            {
                                case 1:

                                    superdume.ListProducts();
                                    
                                    break;

                                case 2:

                                    int selectedProduct = SelectProduct(superdume);

                                    break;

                                case 3:

                                    break;

                                case 4:

                                    break;

                            }


                            break;
                        }
                    case 2:
                        {

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

        public static int SelectProduct(SuperDume s)
        {

            Console.WriteLine("-> Input product code:");
            int input = int.Parse(Console.ReadLine());
            
            foreach(Product p in s.Stock)
            {

                if(p.Code == input)
                {
                    return input;
                }

            }

            return -1;

        }

    }
}
