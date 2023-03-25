using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC1_Zevallos_Varillas_Nicole.Models
{
    public class Pago
    {
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal MontoPagar { get; set; }
    }
}