using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca
{
    internal class MetodosAuxiliares
    {
        public static void MensajeDespedida()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Muchas gracias por haber confiado en nuestra aplicación\n");
            mensaje.Append("Namarië\n");
            mensaje.Append("Presiona cualquiere tecla para salir");
            Console.WriteLine(mensaje.ToString());
        }

        public static void MensajeOpcionNoValida()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Por favor, introduce una opción válida\n");
            mensaje.Append("Presiona cualquier tecla para continuar");
            Console.WriteLine(mensaje.ToString());
        }

        public static void PintarTodasLasOpciones()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Menú de la aplicación\n");
            mensaje.Append("1) Añadir Libro\n");
            mensaje.Append("2) Listar Libros\n");
            mensaje.Append("3) Eliminar Libro\n");
            mensaje.Append("4) Modificar Libro\n");
            mensaje.Append("5) Salir\n\n");
            mensaje.Append("Introduzca el número de la opción que desea realizar: ");
            Console.WriteLine(mensaje.ToString());
        }

        public static void MensajeBienvenida()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Maara tulda\n");
            mensaje.Append("Gestión de la biblioteca de Rivendel");
            Console.WriteLine(mensaje.ToString());
        }
    }
}
