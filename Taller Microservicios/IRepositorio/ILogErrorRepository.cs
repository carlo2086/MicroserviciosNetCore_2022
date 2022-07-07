using Capa.Dominio.Sistema;

namespace IRepositorio
{
    public interface ILogErrorRepository
    {
        bool insertError(LogError error);
    }
}
