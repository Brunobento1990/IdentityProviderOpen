using Appication.DTOs;

namespace Appication.Interfaces;

public interface ILoginParceiroMembroService
{
    Task LoginAsync(LoginDto dto);
}