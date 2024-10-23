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
        public int Avance { get; set; }

        public Usuario usuario { get; set; }
        public Materia materia { get; set; }
    }
}
