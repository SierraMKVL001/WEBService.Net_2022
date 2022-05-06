using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DataAccess.Repositorios;

namespace Domain.Entidades_Negocio
{
    public class NItemISR
    {
        public DItemISR isr=new DItemISR();
        public  ItemISR CalcularISR(decimal sldo)
        {
            List<ItemISR> _ISR = new List<ItemISR>();
            _ISR = isr.Consultar();
            decimal liminf = 0, limsup = 0, cuotaf = 0, exedliminf = 0, subsidio = 0;
            decimal sldoq = sldo / 2;
            var datos = from dISR in _ISR
                        select dISR;
            foreach (var l in datos)
            {
                if ((sldoq >= l.LimInf && sldoq <= l.LimSup))
                {
                    liminf = l.LimInf;
                    limsup = l.LimSup;
                    cuotaf = l.CuotaFija;
                    exedliminf = l.PorExced;
                    subsidio = l.Subcidio;
                }
            }
            ItemISR iSR = new ItemISR(liminf, limsup, cuotaf, exedliminf, subsidio);
            return iSR;
        }
    }
}
