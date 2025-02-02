using GestorTecnicos.DAL;
using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorTecnicos.Services
{
    public class TicketsService(IDbContextFactory<Contexto> Dbfactory) : CRUDService<Tickets>
    {
        public override async Task<bool> Insertar(Tickets entidad)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Tickets.Add(entidad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public override async Task<bool> Modificar(Tickets entidad)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Tickets.Update(entidad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public override async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tickets
                .AsNoTracking()
                .Where(t => t.TicketId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public override async Task<Tickets?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == id);
        }

        public override async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Tickets
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    
        public override async Task<bool> Guardar(Tickets entidad)
        {
            if (entidad.TicketId == 0)
                return await Insertar(entidad);
            else
                return await Modificar(entidad);
        }
    }
}
