﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    [Serializable]
    public class Purchase
    {
        public List<Product> Products { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public float PurchaseTotal { get; set; }
        public int AccumulatedPoints { get; set; }

        public Purchase(List<Product> products, string desc, int quant, float pTotal, int accPoints)
        {
            this.Products = products;
            this.Description = desc;
            this.PurchaseDate = DateTime.Now;
            this.Quantity = quant;
            this.PurchaseTotal = (float)Math.Round(pTotal, 2);
            this.AccumulatedPoints = accPoints;
        }

        public override string ToString()
        {
            string text = "\nPurchase Date: " + this.PurchaseDate + "\nProducts:";

            if (this.Products.Count > 0)
            {
                foreach (Product p in Products)
                {
                    text += ("\n" + p );
                }
            }

            text += "\nTotal: " + this.PurchaseTotal + " Euros, Accumulated Points: " + this.AccumulatedPoints;

            return text;
        }
    }
}