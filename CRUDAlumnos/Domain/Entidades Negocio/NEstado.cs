using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositorios;
using Entidades;

namespace Domain.Entidades_Negocio
{
    public class NEstado
    {
        public DEstado estado=new DEstado();
        public List<Estado> Consultar()
        {
            List<Estado> lista = new List<Estado>();
            lista=estado.Consultar();
            return lista;
        }
    }
}
