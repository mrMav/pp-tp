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
        public string ClienteC { get; set; }
        public DateTime DataCompra { get; set; }
        public string TipoPagamento { get; set; }
        public bool EstadoPagamento { get; set; }
        public string VinhosComprados { get; set; }
        public float CustoTotal { get; set; }

    }
}
