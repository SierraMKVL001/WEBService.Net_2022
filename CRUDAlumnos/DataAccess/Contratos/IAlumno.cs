using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DataAccess.Contratos
{
    internal interface IAlumno
    {
        List<Alumno> Consultar();
        Alumno Consultar(int id);
        void Agregar(Alumno alumno);
        void Actualizar(Alumno alumno);
        void Eliminar(int id);
    }
}
