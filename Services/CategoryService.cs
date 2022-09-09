

// using Entityframeworkproject.Models;
using sss.Models;

namespace sss.Services;

public class CategoryService : ICategoryService
 {
    TaskContext context;

    public CategoryService(TaskContext dbcontext){
        context = dbcontext;
    }

    public IEnumerable <Category> Get(){
        return context.Categorys;
    }

    public async Task Save (Category category){
        context.Add(category);
        await context.SaveChangesAsync();
    }
    public async Task Update (Guid id,Category category){

        var categoriaActual = context.Categorys.Find(id);

        if (categoriaActual != null){
            categoriaActual.Nombre = category.Nombre;
            categoriaActual.Descripcion = category.Descripcion;
            categoriaActual.Peso = category.Peso;
            await context.SaveChangesAsync();
        }
    }
     public async Task Delete (Guid id){

        var categoriaActual = context.Categorys.Find(id);

        if (categoriaActual != null){
           
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }


}

public interface ICategoryService{
    IEnumerable <Category> Get();
    Task Save (Category category);

    Task Update (Guid id,Category category);

    Task Delete (Guid id);
}