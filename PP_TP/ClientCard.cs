using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    [Serializable]
    public class ClientCard
    {
        public List<Purchase> Purchases { get; set; }
        public int CardPoints { get; set; }

        //constructor
        public ClientCard()
        {
            this.Purchases = new List<Purchase>();
            this.CardPoints = 0;
        }
        

    }
}
