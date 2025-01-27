using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class CiudadesService(IDbContextFactory<Contexto> Dbfactory)
    {
        public async Task<bool> Guardar(Ciudades ciudad)
        {
            if (ciudad.CiudadId == 0)
                return await Insertar(ciudad);
            else
                return await Modificar(ciudad);
        }

        public async Task<bool> Insertar(Ciudades ciudad)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Ciudades.Add(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Ciudades ciudad)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Ciudades.Update(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .AsNoTracking()
                .Where(c => c.CiudadId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Ciudades?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .FirstOrDefaultAsync(c => c.CiudadId == id);
        }

        public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
   
    }
}
