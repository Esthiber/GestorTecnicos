using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class TecnicosService(IDbContextFactory<Contexto> Dbfactory) : CRUDService<Tecnicos>
    {
        public override async Task<bool> Guardar(Tecnicos tecnico)
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
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tecnicos.
                AnyAsync(t => t.TecnicoId == tecnico.TecnicoId);
        }

        public override async Task<bool> Insertar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico))
            {
                await using var contexto = await Dbfactory.CreateDbContextAsync();
                contexto.Tecnicos.Add(tecnico);
                return await contexto.SaveChangesAsync() > 0;
            }
            else //Por alguna razon aqui si funciona, no esta tomando encuenta en el metodo de Guardar
            {
                await using var contexto = await Dbfactory.CreateDbContextAsync();
                contexto.Tecnicos.Update(tecnico);
                return await contexto.SaveChangesAsync() > 0;
            }
        }

        public override async Task<bool> Modificar(Tecnicos tecnico)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Tecnicos.Update(tecnico);
            return await contexto.SaveChangesAsync() > 0;
        }

        public override async Task<Tecnicos?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .FirstOrDefaultAsync(t => t.TecnicoId == id);
        }

        public override async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AsNoTracking()
                .Where(t => t.TecnicoId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteNombres(string nombres)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AnyAsync(t => t.Nombres == nombres);
        }

        public override async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }


    }
}
