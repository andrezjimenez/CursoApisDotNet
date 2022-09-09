

using sss.Models;

namespace sss.Services;

public class TaskService : ITaskService
 {
    TaskContext context;

    public TaskService(TaskContext dbcontext){
        context = dbcontext;
    }

    public IEnumerable <Tarea> Get(){
        return context.Tasks;
    }

    public async Task Save (Tarea task){
        context.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task Update (Guid id,Tarea task){

        var tareaActual = context.Tasks.Find(id);

        if (tareaActual != null){
            tareaActual.Titulo = task.Titulo;
            tareaActual.Descripcion = task.Descripcion;
            tareaActual.PrioridadTarea = task.PrioridadTarea;
            tareaActual.CategoryId = task.CategoryId;
            tareaActual.Resumen = task.Resumen;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete (Guid id){

         var tareaActual = context.Tasks.Find(id);

        if (tareaActual != null){
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITaskService{
    IEnumerable <Tarea> Get();    
    Task Save (Tarea task);
    Task Update (Guid id, Tarea task);

    Task Delete (Guid id);
}