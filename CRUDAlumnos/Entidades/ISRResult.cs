using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public struct ISRResult
    {
        public decimal Escedente { get; set; }
        public decimal Impuesto { get; set; }
        public ISRResult(decimal escedente,decimal impuesto)
        {
            Escedente = escedente;
            Impuesto = impuesto;
        }
    }
}
