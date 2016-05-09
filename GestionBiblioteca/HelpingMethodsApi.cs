using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class HelpingMethodsApi
    {
        public static void PartingMessge()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Muchas gracias por haber confiado en nuestra aplicación\n");
            message.Append("Namarië\n");
            message.Append("Presiona cualquiere tecla para salir");
            Console.WriteLine(message.ToString());
        }

        public static void NonValidOptionMessage()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Por favor, introduce una opción válida\n");
            mensaje.Append("Presiona cualquier tecla para continuar");
            Console.WriteLine(mensaje.ToString());
        }

        public static void RenderAllAvailableOptions()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Menú de la aplicación\n");
            message.Append("1) Añadir Libro\n");
            message.Append("2) Listar Libros\n");
            message.Append("3) Eliminar Libro\n");
            message.Append("4) Modificar Libro\n");
            message.Append("5) Salir\n\n");
            message.Append("Introduzca el número de la opción que desea realizar: ");
            Console.WriteLine(message.ToString());
        }

        public static void WelcomeMessage()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Maara tulda\n");
            message.Append("Gestión de la biblioteca de Rivendel");
            Console.WriteLine(message.ToString());
        }
    }
}
