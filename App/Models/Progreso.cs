using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
        public class Progreso
        {
            public int Id { get; set; }
            public int IdUsuario { get; set; }
            public int IdMateria { get; set; }
            public int? IdClase { get; set; }  // Relación opcional con Clase
            public int? IdPractica { get; set; }  // Relación opcional con Practica
            public bool ClaseCompletada { get; set; }
            public bool PracticaCompletada { get; set; }
            public Materia Materia { get; set; }
            public Usuario Usuario { get; set; }
            public Clase Clase { get; set; }
            public Practica Practica { get; set; }
        }

}
