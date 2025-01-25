using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace GestorTecnicos.Services
{
    public class ClientesService(IDbContextFactory<Contexto> Dbfactory)
    {
        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!await Existe(cliente.ClienteId))
            {
                return await Insertar(cliente);
            }
            else
            {
                return await Modificar(cliente);
            }
        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Clientes.Add(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Clientes.Update(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AsNoTracking()
                .Where(c => c.ClienteId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Clientes?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        /// <summary>
        /// Verifica si un cliente existe en la base de datos en base al ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Si existe</returns>
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes.
                AnyAsync(c => c.ClienteId == id);
        }

        /// <summary>
        /// Verifica si un cliente existe en la base de datos en base al RNC
        /// </summary>
        /// <param name="RNC"></param>
        /// <returns></returns>
        public async Task<bool> Existe(string RNC)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes.
                AnyAsync(c => c.Rnc == RNC);
        }

        /// <summary>
        /// Verifica si un cliente existe en la base de datos en base al ID y los nombres
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombres"></param>
        /// <returns></returns>
        public async Task<bool> Existe(int id, string nombres)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes.
                AnyAsync(c => c.ClienteId != id && c.Nombres == nombres);
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
