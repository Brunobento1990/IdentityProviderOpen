using Domain.Entities;

namespace Domain.Repositories;

public interface ILoginParceiroMembroRepository
{
    Task<ParceiroMembro?> ObterAsync(string email);
}