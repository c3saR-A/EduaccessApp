using App.DataAccess;
using App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{

    public class UsuarioViewModel : INotifyPropertyChanged
    {
        private string nombre;
        private string nivel;
        private readonly AppDbContext dbContext;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Nivel
        {
            get => nivel;
            set
            {
                if (nivel != value)
                {
                    nivel = value;
                    OnPropertyChanged();
                }
            }
        }

        public UsuarioViewModel(int UsuarioId) 
        {
            dbContext = new AppDbContext();
            CargarUsuario(UsuarioId);
        }

        private void CargarUsuario(int UsuarioId)
        {
            // Cargar el usuario de la base de datos por ID
            var Usuario = dbContext.Usuarios.FirstOrDefault(ColumnaU => ColumnaU.Id == UsuarioId);

            if (Usuario != null)
            {
                Nombre = Usuario.Nombre; 
                Nivel = Usuario.Nivel;   
            }
            else
            {
                // por si no sale
                Nombre = "Desconocido"; 
                Nivel = "Desconocido"; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
