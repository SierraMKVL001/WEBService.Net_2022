using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DataAccess.Contratos
{
    internal interface IISRResult
    {
        List<ISRResult> Consultar();
    }
}
