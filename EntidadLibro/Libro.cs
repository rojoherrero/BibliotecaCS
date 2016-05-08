using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEntidades
{
    public class Libro
    {
        // Atributos del libro
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Ejemplares { get; set; }

        // Constructor con todos los elementos
        public Libro(string autor, string titulo, string isbn, DateTime fechaPublicacion, DateTime fechaAlta, int ejemplares)
        {
            Autor = autor;
            Titulo = titulo;
            ISBN = isbn;
            FechaPublicacion = fechaPublicacion;
            FechaAlta = fechaAlta;
            Ejemplares = ejemplares;
        }

        //Constructor vacio
        public Libro()
        {
        }

        public string MostrarInfoLibro()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append(Autor);
            informacion.Append("\t\t");
            informacion.Append(Titulo);
            informacion.Append("\t\t");
            informacion.Append(ISBN);
            informacion.Append("\t\t");
            informacion.Append(Ejemplares);
            informacion.Append("\t\t");
            informacion.Append(FechaPublicacion.ToShortDateString());
            informacion.Append("\t\t");
            informacion.Append(FechaAlta.ToShortDateString());

            return informacion.ToString();
        }
    }
}
