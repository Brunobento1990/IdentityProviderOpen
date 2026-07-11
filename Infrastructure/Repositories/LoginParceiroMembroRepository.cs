using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class LoginParceiroMembroRepository : ILoginParceiroMembroRepository
{
    private readonly AppDbContext _context;

    public LoginParceiroMembroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ParceiroMembro?> ObterAsync(string email)
    {
        return await _context
            .ParceiroMembros
            .AsNoTracking()
            .Include(x => x.Parceiro)
            .Include(x => x.Usuario.Email)
            .FirstOrDefaultAsync(x => x.Usuario.Email == email);
    }
}