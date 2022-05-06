using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositorios;
using Entidades;

namespace Domain.Entidades_Negocio
{
    public class NEstatus
    {
        public DEstatus estatus=new DEstatus();
        public List<EstatusAlumnos> Consultar()
        {
            List<EstatusAlumnos> list = new List<EstatusAlumnos>();
            list=estatus.Consultar();
            return list;
        }
    }
}
