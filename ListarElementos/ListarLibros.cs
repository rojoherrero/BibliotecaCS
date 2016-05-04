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
            cabecera.Append("\t\t\t\t");
            cabecera.Append("Título");
            cabecera.Append("\t\t\t\t");
            cabecera.Append("ISBN");
            Console.WriteLine(cabecera);

            foreach (Libro item in nombreDiccionario.Values)
            {
                StringBuilder libroPorPantalla = new StringBuilder();
                libroPorPantalla.Append(item.Autor);
                libroPorPantalla.Append("\t\t\t\t");
                libroPorPantalla.Append(item.Titulo);
                libroPorPantalla.Append("\t\t\t\t");
                libroPorPantalla.Append(item.ISBN);
                Console.WriteLine(libroPorPantalla);
            }
        }
    }
}
