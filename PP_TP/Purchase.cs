using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class Purchase
    {
        public List<Product> Products { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public float PurchaseTotal { get; set; }
        public int AccumulatedPoints { get; set; }

        public void Purchases(List<Product> products, string desc, int quant, float pTotal, int accPoints)
        {
            this.Description = desc;
            this.PurchaseDate = DateTime.Now;
            this.Quantity = quant;
            this.PurchaseTotal = pTotal;
            this.AccumulatedPoints = accPoints;

        }

    }
}