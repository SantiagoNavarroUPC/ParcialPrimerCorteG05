using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    interface IBodega
    {
        double TipoBodega();
        enum Bodega { carga = 1, mantenimiento = 2 };
    }
}
