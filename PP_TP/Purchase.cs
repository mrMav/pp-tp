using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class Purchase
    {
        public List<Product> products { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public float PurchaseTotal { get; set; }
        public int AccumulatedPoints { get; set; }

    }
}
