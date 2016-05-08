using LibreriaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListarElementos
{
    public class ListarLibros
    {
        public static void InfoLibro(Dictionary<string, Libro> nombreDiccionario, string llave)
        {
            StringBuilder entradaInformacion = new StringBuilder();
            entradaInformacion.Append("1) Autor: ");
            entradaInformacion.Append(nombreDiccionario[llave].Autor);
            entradaInformacion.Append("\n2) Titulo: ");
            entradaInformacion.Append(nombreDiccionario[llave].Titulo);
            entradaInformacion.Append("\n3) Ejemplares: ");
            entradaInformacion.Append(nombreDiccionario[llave].Ejemplares.ToString());
            entradaInformacion.Append("\n4) Fecha de alta: ");
            entradaInformacion.Append(nombreDiccionario[llave].FechaAlta.ToShortDateString());
            entradaInformacion.Append("\n5) Fecha de publicación: ");
            entradaInformacion.Append(nombreDiccionario[llave].FechaPublicacion.ToShortDateString());

            Console.WriteLine(entradaInformacion.ToString());
        }
        
        public static void ListarTodosLosLibros(Dictionary<string, Libro> nombreDiccionario)
        {
            StringBuilder cabecera = new StringBuilder();
            cabecera.Append("Autor\t\t");
            cabecera.Append("Título\t\t");
            cabecera.Append("ISBN\t\t");
            cabecera.Append("Ejemplares\t\t");
            cabecera.Append("Fecha de alta\t\t");
            cabecera.Append("Publicación\t\t");
            Console.WriteLine(cabecera);

            foreach (Libro libro in nombreDiccionario.Values)
            {
                Console.WriteLine(libro.MostrarInfoTabulada());
            }
        }
    }
}
