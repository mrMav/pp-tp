using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class ClientCard
    {
        public Client AssignedClient { get; set; }
        public List<Purchase> Purchases { get; set; }
        public int CardPoints { get; set; }

        //constructor
        public ClientCard(Client aClient, List<Purchase> purchases, int cPoints)
        {
            this.AssignedClient = aClient;
            this.Purchases = purchases;
            this.CardPoints = cPoints;
        }
        

    }
}
