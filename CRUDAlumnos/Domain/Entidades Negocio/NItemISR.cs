using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DataAccess.Repositorios;
using Newtonsoft.Json;

namespace Domain.Entidades_Negocio
{
    public class NItemISR
    {
        
        public  ItemISR CalcularISR(int id)
        {
            Alumno AlumnoList = new Alumno();
            DAlumno _dalmno=new DAlumno();
            DItemISR isr = new DItemISR();
            List<ItemISR> _ISR = new List<ItemISR>();
            AlumnoList = _dalmno.Consultar(id);
            decimal sldo = Convert.ToDecimal(AlumnoList.SueldoMensual);
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
        public ItemISR WebCalcularISR(int id)
        {
            ItemISR iSR = new ItemISR();
            WSAlumnos.WSAlumnosSoapClient _wsAlum = new WSAlumnos.WSAlumnosSoapClient();
            WSAlumnos.ItemISR ISR= _wsAlum.CalcularISR(id);
            var json= JsonConvert.SerializeObject(ISR);
            iSR = JsonConvert.DeserializeObject<ItemISR>(json);
            return iSR;
        }
    }
}
