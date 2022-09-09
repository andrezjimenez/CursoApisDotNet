using Microsoft.EntityFrameworkCore;
using Entityframeworkproject.Models;


namespace Entityframeworkproject;

public class TaskContext: DbContext
{
    public DbSet<Category> Categorys {get;set;}

    public DbSet<Tarea> Tasks {get;set;}

    public TaskContext(DbContextOptions<TaskContext> options): base(options){}

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category() {
            CategoryId = Guid.Parse("3e1da43b-c389-417d-bc6f-9c0be3b28eb1"),
            Nombre = "Actividades Pendientes",
            Peso = 20
        });
          categoryInit.Add(new Category() {
            CategoryId = Guid.Parse("3e1da43b-c389-417d-bc6f-9c0be3b28eb2"),
            Nombre = "Actividades Personales",
            Peso = 50
        });

        modelBuilder.Entity<Category>(category =>{
            category.ToTable("Categoria");
            category.HasKey(p=> p.CategoryId);
            category.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            category.Property(p => p.Descripcion).IsRequired(false);
            category.Property(p => p.Peso);

            category.HasData(categoryInit);
        }) ;

        List<Tarea> tareaInit = new List<Tarea>();
        tareaInit.Add(new Tarea(){
            TareaId = Guid.Parse("b21da43b-c389-417d-bc6f-9c0be3b28eb2"),
            Titulo = "Tarea 1",
            CategoryId = Guid.Parse("3e1da43b-c389-417d-bc6f-9c0be3b28eb1"),
            Descripcion = "Prueba de Descripcion 1",
            PrioridadTarea = Priority.Medium,
            FechaCreacion = DateTime.Now,
            Comments = "Esta es una prueba"
        });

        tareaInit.Add(new Tarea(){
            TareaId = Guid.Parse("b11da43b-c389-417d-bc6f-9c0be3b28eb2"),
            Titulo = "Tarea 02",
            CategoryId = Guid.Parse("3e1da43b-c389-417d-bc6f-9c0be3b28eb2"),
            Descripcion = "Prueba de Descripcion 2",
            PrioridadTarea = Priority.low,
            FechaCreacion = DateTime.Now,
            Comments = "Esta es una prueba 2"
        });

        modelBuilder.Entity<Tarea>(task => {
            task.ToTable("Tarea");
            task.HasKey(t=> t.TareaId);
            task.HasOne(t => t.Categoria).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
            task.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
            task.Property(t => t.Descripcion).IsRequired().HasMaxLength(250);
            task.Property(t => t.PrioridadTarea);
            task.Property(t => t.FechaCreacion);
            task.Ignore( t => t.Resumen);
            task.Property(t => t.Comments);

            task.HasData(tareaInit);
        });
        
    }
     
}
