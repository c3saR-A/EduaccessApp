using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Clase
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string Contenido { get; set; }
        public Materia Materia { get; set; }
    }
}
