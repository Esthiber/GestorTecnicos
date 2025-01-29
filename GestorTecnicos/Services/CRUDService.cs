using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class
    {
        /// <summary>
        /// Busca una entidad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> Buscar(int id)
        {
            Console.WriteLine($"Buscando entidad de tipo {typeof(T).Name}");
            return await Task.FromResult(default(T));
        }

        /// <summary>
        /// Elimina una entidad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Eliminar(int id)
        {
            Console.WriteLine($"Eliminando entidad de tipo {typeof(T).Name}");
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Guarda una entidad, si ya existe la modifica, si no la inserta
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task<bool> Guardar(T entidad)
        {
            Console.WriteLine($"Guardando entidad de tipo {typeof(T).Name}");
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Inserta una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task<bool> Insertar(T entidad)
        {
            Console.WriteLine($"Insertando entidad de tipo {typeof(T).Name}");
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Lista entidades que cumplan con un criterio
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public async Task<List<T>> Listar(Expression<Func<T, bool>> criterio)
        {
            Console.WriteLine($"Listando entidades de tipo {typeof(T).Name}");
            return await Task.FromResult(new List<T>());
        }

        /// <summary>
        /// Modifica una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task<bool> Modificar(T entidad)
        {
            Console.WriteLine($"Modificando entidad de tipo {typeof(T).Name}");
            return await Task.FromResult(true);
        }
    }
}
