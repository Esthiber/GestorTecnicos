using GestorTecnicos.Models;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public interface ICRUDService<T> where T : class
    {
        // Create, Read, Update, Delete
        Task<bool> Insertar(T entidad);
        Task<T?> Buscar(int id);
        Task<bool> Modificar(T entidad);
        Task<bool> Eliminar(int id);

        Task<List<T>> Listar(Expression<Func<T, bool>> criterio);

        Task<bool> Guardar(T entidad);

    }
}
