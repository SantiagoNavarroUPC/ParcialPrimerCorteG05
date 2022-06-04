using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    interface IBono
    {
        double TipoBono();
        double CrearBono();
        enum Bonus { bajo = 10000, alto = 15000, superior = 20000};
    }
}
