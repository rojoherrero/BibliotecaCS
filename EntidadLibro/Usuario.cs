using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEntidades
{
    public class Usuario
    {
        //Atributos del Usuario
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long IdUsuario { get; set; }
        public string Direccion { get; set; }
        public int NumTelfMovil { get; set; }

        //Constructor vacio
        public Usuario()
        {
        }

        //Constructor con argumentos
        public Usuario(string nombre, DateTime fechaNacimiento, long idUsuario, string direccion, int numTelfMovil)
        {
            Nombre = nombre;
            fechaNacimiento = FechaNacimiento;
            IdUsuario = idUsuario;
            Direccion = direccion;
            NumTelfMovil = numTelfMovil;
        }

        public string MostarInfoTabulada()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append(IdUsuario);
            informacion.Append("\t\t");
            informacion.Append(Nombre);
            informacion.Append("\t\t");
            informacion.Append(FechaNacimiento);
            informacion.Append("\t\t");
            informacion.Append(Direccion);
            informacion.Append("\t\t");
            informacion.Append(NumTelfMovil);

            return informacion.ToString();
        }
    }
}
