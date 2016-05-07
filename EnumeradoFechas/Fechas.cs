using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeradosFechas
{
    public class Fechas
    {

        enum Meses { Enero = 1, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre };

        enum Dias : int { Max = 31, Min = 1};

        enum Anos : int { Max = 2016, Min = 1500};

    }
}
