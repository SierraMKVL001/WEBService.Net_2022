using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public struct IMSS
    {
        public decimal EnfyMat { get; set; }
        public decimal InvyVid { get; set; }
        public decimal Retiro { get; set; }
        public decimal Cesantia { get; set; }
        public decimal CreditoInf { get; set; }
        public IMSS(decimal enfyMat,decimal invyVid,decimal retiro,decimal cesantia,decimal creditoInf)
        {
            EnfyMat = enfyMat;
            InvyVid = invyVid;
            Retiro = retiro;
            Cesantia = cesantia;
            CreditoInf = creditoInf;
        }
    }
}
