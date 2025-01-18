using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class TecnicosService(IDbContextFactory<Contexto> Dbfactory)
    {
        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico))
            {
                return await Insertar(tecnico);
            }
            else
            {
                return await Modificar(tecnico);
            }
        }

        public async Task<bool> Existe(Tecnicos tecnico)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            return await db.Tecnicos.AnyAsync(t => t.TecnicoId == tecnico.TecnicoId);
        }

        public async Task<bool> Insertar(Tecnicos tecnico)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            db.Tecnicos.Add(tecnico);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tecnicos tecnico)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            db.Tecnicos.Update(tecnico);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<Tecnicos?> Buscar(int id)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            return await db.Tecnicos
                .Include(t => t.TecnicoId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            return await db.Tecnicos
                .AsNoTracking()
                .Where(t => t.TecnicoId == id)
                .ExecuteDeleteAsync() > 0;

        }

        // metodo listar
        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos,bool>> criterio)
        {
            await using var db = await Dbfactory.CreateDbContextAsync();
            return await db.Tecnicos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
