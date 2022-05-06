using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Domain.Entidades_Negocio
{
    public class NIMSS
    {
        IMSS _imss=new IMSS();
        public IMSS Calcular(decimal sueldo)
        {

            decimal UMAS =Convert.ToDecimal(ConfigurationManager.AppSettings["UMA"]);
            decimal EnfMap = (EnfMaP(sueldo,UMAS,0.4m)/100);
            decimal InvyVid = (InvVidP(sueldo, 0.625m)/100);
            decimal Ret = RetP(sueldo, 0m);
            decimal Cas = (CasP(sueldo, 1.125m)/100);
            decimal CrInf = CrInfP(sueldo, 0);
            _imss=new IMSS(EnfMap, InvyVid, Ret, Cas, CrInf);
            return _imss;

        }
        static decimal EnfMaP(decimal sbc, decimal umas, decimal por)
        {
            decimal res = (sbc - (3 * umas)) * por;
            return res;

        }
        static decimal InvVidP(decimal num1, decimal por)
        {
            decimal res = num1 * por;
            return res;
        }
        static decimal RetP(decimal num1, decimal por)
        {
            decimal res = num1 * por;
            return res;
        }
        static decimal CasP(decimal num1, decimal por)
        {
            decimal res = num1 * por;
            return res;
        }
        static decimal CrInfP(decimal num1, decimal por)
        {
            decimal num = num1 * por;
            return num;
        }
    }
}
