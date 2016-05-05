using EntidadLibro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListarElementos
{
    public class ListarLibros
    {
        public void todosLosLibros(Dictionary<string, Libro> nombreDiccionario)
        {
            StringBuilder cabecera = new StringBuilder();
            cabecera.Append("Autor");
            cabecera.Append("\t\t");
            cabecera.Append("Título");
            cabecera.Append("\t\t");
            cabecera.Append("ISBN");
            cabecera.Append("\t\t");
            cabecera.Append("Ejemplares");
            cabecera.Append("\t\t");
            cabecera.Append("Fecha de alta");
            cabecera.Append("\t\t");
            cabecera.Append("Publicación");
            Console.WriteLine(cabecera);

            foreach (Libro libro in nombreDiccionario.Values)
            {
                StringBuilder libroPorPantalla = new StringBuilder();
                libroPorPantalla.Append(libro.Autor);
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(libro.Titulo);
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(libro.ISBN);
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(libro.Ejemplares);
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(fechaSencillaAlta(libro));
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(fechaSencillaPublicacion(libro));
                Console.WriteLine(libroPorPantalla);
            }
        }

        // TODO Tengo que aprender Lambdas para refactorizar estos dos métodos privados
        private string fechaSencillaPublicacion(Libro libro)
        {
            StringBuilder fechaPublicacion = new StringBuilder();
            fechaPublicacion.Append(libro.FechaPublicacion.Day);
            fechaPublicacion.Append("/");
            fechaPublicacion.Append(libro.FechaPublicacion.Month);
            fechaPublicacion.Append("/");
            fechaPublicacion.Append(libro.FechaPublicacion.Year);

            return fechaPublicacion.ToString();
        }

        private string fechaSencillaAlta(Libro libro)
        {
            StringBuilder fechaPublicacion = new StringBuilder();
            fechaPublicacion.Append(libro.FechaAlta.Day);
            fechaPublicacion.Append("/");
            fechaPublicacion.Append(libro.FechaAlta.Month);
            fechaPublicacion.Append("/");
            fechaPublicacion.Append(libro.FechaAlta.Year);

            return fechaPublicacion.ToString();
        }
    }
}
