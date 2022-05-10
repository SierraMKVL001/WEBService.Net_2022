using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;
using DataAccess.Repositorios;
using Domain.Entidades_Negocio;

namespace WebServiceASMX
{
    /// <summary>
    /// Descripción breve de WSAlumnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSAlumnos : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public ItemISR CalcularISR(int id)
        {
            Alumno AlumnoList = new Alumno();
            DAlumno _dalmno = new DAlumno();
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
        [WebMethod]
        public IMSS CalcularIMSS(int id)
        {
            Alumno AlumnoList = new Alumno();
            DAlumno _dalmno = new DAlumno();
            List<ItemISR> _ISR = new List<ItemISR>();
            AlumnoList = _dalmno.Consultar(id);
            decimal sldo = Convert.ToDecimal(AlumnoList.SueldoMensual);
            NIMSS nIMSS = new NIMSS();
            IMSS _imss = new IMSS();
            _imss=nIMSS.Calcular(sldo);
            return _imss;
        }
    }
}
