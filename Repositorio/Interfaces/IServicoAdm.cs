
using RadarG6.Repositorios.Interfaces;

namespace api.Repositorios.Interfaces;

public interface IServicoAdm<T> : IServico<T>
{
    Task<T?> Login(string email, string senha);
}