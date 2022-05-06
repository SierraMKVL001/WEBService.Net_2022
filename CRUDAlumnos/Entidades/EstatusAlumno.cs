using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public struct EstatusAlumnos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public EstatusAlumnos(int id,string nombre,string clave)
        {
            ID = id;
            Nombre = nombre;
            Clave = clave;
        }
    }
}
