using System.Linq.Expressions;
/*
         Esta clase es una simulacion, todos los metodos son virtuales y no hacen nada.
         Se debe sobreescribir en las clases hijas.
*/
namespace GestorTecnicos.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class
    {
        protected List<T> _dbContext = new();
        protected int _nextId = 1;

        /// <summary>
        /// Busca una entidad por su ID.
        /// </summary>
        public virtual async Task<T?> Buscar(int id)
        {
            var entidad = _dbContext.FirstOrDefault(e => e?.GetHashCode() == id);
            return await Task.FromResult(entidad);
        }

        /// <summary>
        /// Elimina una entidad por su ID.
        /// </summary>
        public virtual async Task<bool> Eliminar(int id)
        {
            var entidad = _dbContext.FirstOrDefault(e => e?.GetHashCode() == id);
            if (entidad != null)
            {
                _dbContext.Remove(entidad);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        /// <summary>
        /// Verifica si una entidad existe en base a su ID.
        /// </summary>
        public virtual async Task<bool> Existe(int id)
        {
            var existe = _dbContext.Any(e => e?.GetHashCode() == id);
            return await Task.FromResult(existe);
        }

        /// <summary>
        /// Guarda una entidad: si ya existe, la modifica; si no, la inserta.
        /// </summary>
        public virtual async Task<bool> Guardar(T entidad)
        {
            var id = entidad.GetHashCode();

            if (await Existe(id))
            {
                return await Modificar(entidad);
            }
            else
            {
                return await Insertar(entidad);
            }
        }

        /// <summary>
        /// Inserta una entidad en la lista en memoria.
        /// </summary>
        public virtual async Task<bool> Insertar(T entidad)
        {
            _dbContext.Add(entidad);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Lista todas las entidades que cumplan con un criterio.
        /// </summary>
        public virtual async Task<List<T>> Listar(Expression<Func<T, bool>> criterio)
        {
            var query = _dbContext.AsQueryable().Where(criterio).ToList();
            return await Task.FromResult(query);
        }

        /// <summary>
        /// Modifica una entidad existente.
        /// </summary>
        public virtual async Task<bool> Modificar(T entidad)
        {
            var id = entidad.GetHashCode();
            var existente = _dbContext.FirstOrDefault(e => e?.GetHashCode() == id);
            if (existente != null)
            {
                _dbContext.Remove(existente);
                _dbContext.Add(entidad);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
