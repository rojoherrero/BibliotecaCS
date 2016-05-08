using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEntidades
{
    public class Prestamo
    {
        public long IdPrestamo { get; set; }
        public string ISBN { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        //Constructor vacio
        public Prestamo() { }

        //Constructor con argumentos
        public Prestamo(long idPrestamo, string isbn, long idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            IdPrestamo = idPrestamo;
            ISBN = isbn;
            IdUsuario = idUsuario;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public string MostrarInfoTabulada()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append(IdPrestamo);
            informacion.Append("\t\t");
            informacion.Append(IdUsuario);
            informacion.Append("\t\t");
            informacion.Append(ISBN);
            informacion.Append("\t\t");
            informacion.Append(FechaInicio.ToShortDateString());
            informacion.Append("\t\t");
            informacion.Append(FechaFin.ToShortDateString());
            
            return informacion.ToString();
        }

    }
}
