using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Practica
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public Materia Materia { get; set; }
    }
}
