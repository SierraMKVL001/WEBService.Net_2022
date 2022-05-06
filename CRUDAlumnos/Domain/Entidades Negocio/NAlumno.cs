using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositorios;
using Entidades;

namespace Domain.Entidades_Negocio
{
    public class NAlumno
    {
        DAlumno alumnos = new DAlumno();

        public void Actualizar(Alumno alumno)
        {
            alumnos.Actualizar(alumno);
        }
        public void Agregar(Alumno alumno)
        {
            alumnos.Agregar(alumno);
        }
        public void Eliminar(int id)
        {
            alumnos.Eliminar(id);
        }
        public Alumno Consultar(int id)
        {
            Alumno alumno = new Alumno();
            alumno=alumnos.Consultar(id);
            return alumno;
        }
        public List<Alumno> Consultar()
        {
            List<Alumno> list = new List<Alumno>();
            list=alumnos.Consultar();
            return list;
        }

    }
}
