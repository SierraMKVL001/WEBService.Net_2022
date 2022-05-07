using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaAPI.Model.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Curp { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
