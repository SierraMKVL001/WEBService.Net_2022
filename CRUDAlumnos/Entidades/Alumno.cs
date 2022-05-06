using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public struct Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public decimal SueldoMensual { get; set; }
        public int IdEstadoOrig { get; set; }
        public int IdEstatus { get; set; }

        public Alumno(int id, string nombre,string primerApellido,string segundoApellido,string correo,string telefono,
            DateTime fechaNacimiento,string curp,decimal sueldoMensual,int idEstadoOrig, int idEstatus)
        {
            ID = id;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Correo = correo;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            CURP = curp;
            SueldoMensual = sueldoMensual;
            IdEstadoOrig = idEstadoOrig;
            IdEstatus = idEstatus;
        }
    }
}
