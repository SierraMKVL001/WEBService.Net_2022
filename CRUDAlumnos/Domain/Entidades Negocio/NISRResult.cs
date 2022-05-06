using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Domain.Entidades_Negocio
{
    public class NISRResult
    {
        public  ISRResult Calcular(ItemISR iSR, decimal sldoQ)
        {
            decimal excedent = ObtenerExcedente(iSR.LimInf, sldoQ, iSR.PorExced);
            decimal impuesto = ObtenerImpuesto(iSR.CuotaFija, excedent, iSR.Subcidio);
            ISRResult isr = new ISRResult(excedent, impuesto);
            return isr;
        }
        public static decimal ObtenerExcedente(decimal limInf, decimal sldoq, decimal exdLimI)
        {
            decimal result = 0;

            result = (sldoq - limInf) * (exdLimI / 100);

            return result;
        }
        public static decimal ObtenerImpuesto(decimal cuFija, decimal excedn, decimal subSid)
        {
            decimal resultado = 0;
            resultado = (cuFija + excedn) + subSid;
            return resultado;
        }
    }
}
