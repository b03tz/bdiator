using System.Threading.Tasks;

namespace Bediator
{
    public interface IBDiatorInstance
    {
        Task<bool> HandleAsync<TMessageType>(TMessageType message);
    }
}