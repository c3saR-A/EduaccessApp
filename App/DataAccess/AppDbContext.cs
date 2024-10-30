using App.Models;
using App.Utility;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Progreso> Progresos { get; set; }
        public DbSet<Practica> Practicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDB.RutaDB("Maui.db")}";
            optionsBuilder.UseSqlite(conexionDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Usuario>(entity =>
                {
                    entity.HasKey(columnaU => columnaU.Id);
                    entity.Property(columnaU => columnaU.Id).IsRequired().ValueGeneratedOnAdd();
                });

                modelBuilder.Entity<Materia>(entity =>
                {
                    entity.HasKey(columnaM => columnaM.Id);
                    entity.Property(columnaM => columnaM.Id).IsRequired().ValueGeneratedOnAdd();
                    entity.Property(columnaM => columnaM.Nombre).IsRequired();
                });

                modelBuilder.Entity<Clase>(entity =>
                {
                    entity.HasKey(columnaC => columnaC.Id);
                    entity.Property(columnaC => columnaC.Id).IsRequired().ValueGeneratedOnAdd();
                    entity.Property(columnaC => columnaC.Contenido).IsRequired();
                    //Relación con Materia
                    entity.HasOne(columnaC => columnaC.Materia).WithMany(columnaM => columnaM.Clases).HasForeignKey(columna => columna.IdMateria);
                });

                modelBuilder.Entity<Practica>(entity =>
                {
                    entity.HasKey(columnaP => columnaP.Id);
                    entity.Property(columnaP => columnaP.Id).IsRequired().ValueGeneratedOnAdd();
                    entity.Property(columnaP => columnaP.Nombre).IsRequired();
                    //Relación con Materia
                    entity.HasOne(columnaP => columnaP.Materia)
                          .WithMany(columnaM => columnaM.Practicas)
                          .HasForeignKey(columnaP => columnaP.IdMateria);
                });

            modelBuilder.Entity<Progreso>(entity =>
            {
                entity.HasKey(columnaP => columnaP.Id);
                entity.Property(columnaP => columnaP.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(columnaP => columnaP.ClaseCompletada).HasDefaultValue(false);
                entity.Property(columnaP => columnaP.PracticaCompletada).HasDefaultValue(false);

                // Relación con Usuario
                entity.HasOne(columnaP => columnaP.Usuario)
                      .WithMany()
                      .HasForeignKey(columnaP => columnaP.IdUsuario);

                // Relación con Materia
                entity.HasOne(columnaP => columnaP.Materia)
                      .WithMany()
                      .HasForeignKey(columnaP => columnaP.IdMateria);

                // Relación con Clase
                entity.HasOne(columnaP => columnaP.Clase)
                      .WithMany()
                      .HasForeignKey(columnaP => columnaP.IdClase);

                // Relación con Practica
                entity.HasOne(columnaP => columnaP.Practica)
                      .WithMany()
                      .HasForeignKey(columnaP => columnaP.IdPractica);
            });        

                modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = 1, Nombre = "Ciencias" },
                new Materia { Id = 2, Nombre = "Lenguaje" },
                new Materia { Id = 3, Nombre = "Sociales" },
                new Materia { Id = 4, Nombre = "Matemáticas" }
                );

                modelBuilder.Entity<Clase>().HasData(
                    new Clase { Id = 1, IdMateria = 1, Contenido = "El reino de los animales" },
                    new Clase { Id = 2, IdMateria = 1, Contenido = "El reino de las plantas" },
                    new Clase { Id = 3, IdMateria = 1, Contenido = "Los sentidos" }, 
                    new Clase { Id = 4, IdMateria = 4, Contenido = "Clasifiquemos por su color" },
                    new Clase { Id = 5, IdMateria = 4, Contenido = "Identifiquemos el grande y el pequeño" },
                    new Clase { Id = 6, IdMateria = 4, Contenido = "Identifiquemos el mediano" }
                );

            modelBuilder.Entity<Practica>().HasData(
                new Practica { Id = 1, IdMateria = 1, Nombre = "Práctica de Ciencias 1" },
                new Practica { Id = 2, IdMateria = 2, Nombre = "Práctica de Lenguaje 1" },
                new Practica { Id = 3, IdMateria = 3, Nombre = "Práctica de Sociales 1" },
                new Practica { Id = 4, IdMateria = 4, Nombre = "Práctica de Matemáticas 1" }
                ); 
            
        }
    }
}
