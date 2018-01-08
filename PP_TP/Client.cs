using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public class Client
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CC { get; set; }
        public string NIF { get; set; }

        public Client (string name, string adress, string phoneNumber, string email, string cc, string nif)
        {
            this.Name = name;
            this.Adress = adress;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CC = cc;
            this.NIF = nif;
        }
    }
}
