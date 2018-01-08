using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class Client
    {
        string Name { get; set; }
        string Adress { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string CC { get; set; }
        string Nif { get; set; }

        public Client (string name,string adress, string phoneNumber, string email, string cc, string Nif)
        {
            this.Name = name;
            this.Adress = adress;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CC = cc;
            this.Nif = Nif;
        }
    }
}
