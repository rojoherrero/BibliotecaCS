using LibreriaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListarElementos
{
    public class OperacionesSobreLibros
    {
        public static void InfoLibro(Dictionary<string, Libro> nombreDiccionario, string llave)
        {
            StringBuilder entradaInformacion = new StringBuilder();
            entradaInformacion.Append("Autor: ");
            entradaInformacion.Append(nombreDiccionario[llave].Autor);
            entradaInformacion.Append("\n");
            entradaInformacion.Append("Titulo: ");
            entradaInformacion.Append(nombreDiccionario[llave].Titulo);
            entradaInformacion.Append("\n");
            entradaInformacion.Append("Ejemplares: ");
            entradaInformacion.Append(nombreDiccionario[llave].Ejemplares.ToString());
            entradaInformacion.Append("\n");
            entradaInformacion.Append("Fecha de alta: ");
            entradaInformacion.Append(nombreDiccionario[llave].FechaAlta.ToShortDateString());
            entradaInformacion.Append("\n");
            entradaInformacion.Append("Fecha de publicación: ");
            entradaInformacion.Append(nombreDiccionario[llave].FechaPublicacion.ToShortDateString());

            Console.WriteLine(entradaInformacion.ToString());
        }
        
        public static void ListarTodosLosLibros(Dictionary<string, Libro> nombreDiccionario)
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
                libroPorPantalla.Append(libro.FechaAlta.ToShortDateString());
                libroPorPantalla.Append("\t\t");
                libroPorPantalla.Append(libro.FechaPublicacion.ToShortDateString());
                Console.WriteLine(libroPorPantalla);
            }
        }
    }
}
