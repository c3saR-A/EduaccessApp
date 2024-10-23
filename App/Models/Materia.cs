using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public  class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Clase> Clases { get; set; }

    }
}
