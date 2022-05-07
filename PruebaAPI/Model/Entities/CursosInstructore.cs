using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaAPI.Model.Entities
{
    public partial class CursosInstructore
    {
        public int Id { get; set; }
        public short IdCurso { get; set; }
        public int IdInstructor { get; set; }
        public DateTime? FechaContratacion { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Instructore IdInstructorNavigation { get; set; }
    }
}
