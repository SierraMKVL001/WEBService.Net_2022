using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public struct Estado
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Curp { get; set; }
        public Estado(int id,string nombre,string curp)
        {
            ID = id;
            Nombre = nombre;
            Curp = curp;
        }
    }
}
