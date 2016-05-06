﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEntidades
{
    public class Libro
    {
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Ejemplares { get; set; }
    }

    public class Prestamo
    {
        public string IsbnPrestado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaInicioPrestamo  { get; set; }
        public DateTime FechaFinPrestamo { get; set; }
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int NumTelefMovil { get; set; }
    }
}
