using proyectoef;
using proyectoef.Models;

namespace webapi.Services;

public class TareasService : ITareasService
{
    TareaContext context;

    public TareasService(TareaContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
}