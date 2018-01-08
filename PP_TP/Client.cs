using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    class Client
    {
        string Name { get; set; }
        string Adress { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string CC { get; set; }
        string Nif { get; set; }

        public Client (string name, string cc )
        {
            this.Name = name;
            this.Adress = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.CC = cc;
            this.Nif = "";
        }
    }
}
