using System.Data;
using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareaContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareaContext(DbContextOptions<TareaContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategorioaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904ccc"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategorioaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904c02"), Nombre = "Actividades personales", Peso = 50 });


        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("CAtegoria");
            categoria.HasKey(p=> p.CategorioaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904c10"), CategoriaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904ccc"), PrioridadTarea = Prioridad.media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904c11"), CategoriaId = Guid.Parse("3a08a698-55a5-44a9-a6c8-d4a7c3904c02"), PrioridadTarea = Prioridad.baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);

            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Descripcion).IsRequired(false);
            
            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}