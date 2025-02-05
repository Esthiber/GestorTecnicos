using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class SistemasService(IDbContextFactory<Contexto> Dbfactory) : CRUDService<Sistemas>
    {
        public override async Task<bool> Guardar(Sistemas entidad)
        {
            if (!await Existe(entidad.SistemaId))
            {
                return await Insertar(entidad);
            }
            else
            {
                return await Modificar(entidad);
            }
        }

        public override async Task<bool> Insertar(Sistemas entidad)
        {
            await using var contexto = Dbfactory.CreateDbContext();
            contexto.Sistemas.Add(entidad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public override async Task<bool> Modificar(Sistemas entidad)
        {
            await using var contexto = Dbfactory.CreateDbContext();
            contexto.Sistemas.Update(entidad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public override async Task<bool> Eliminar(int id)
        {
            await using var contexto = Dbfactory.CreateDbContext();
            return await contexto.Sistemas
                .AsNoTracking()
                .Where(s => s.SistemaId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public override async Task<Sistemas?> Buscar(int id)
        {
            await using var contexto = Dbfactory.CreateDbContext();
            return await contexto.Sistemas
                .FirstOrDefaultAsync(s => s.SistemaId == id);
        }

        public override async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
        {
            await using var contexto = Dbfactory.CreateDbContext();
            return await contexto.Sistemas
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
