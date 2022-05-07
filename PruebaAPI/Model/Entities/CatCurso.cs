using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaAPI.Model.Entities
{
    public partial class CatCurso
    {
        public CatCurso()
        {
            Cursos = new HashSet<Curso>();
            InverseIdPreRequisitosNavigation = new HashSet<CatCurso>();
        }

        public short Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte Horas { get; set; }
        public short? IdPreRequisitos { get; set; }
        public bool Activo { get; set; }

        public virtual CatCurso IdPreRequisitosNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<CatCurso> InverseIdPreRequisitosNavigation { get; set; }
    }
}
