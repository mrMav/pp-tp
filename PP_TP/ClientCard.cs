using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class ClientCard
    {

        public int CardPoints { get; set; }
        public List<Purchase> Purchases { get; set; }

        //constructor
        public ClientCard()
        {
            this.CardPoints = 0;
        }
        

    }
}
