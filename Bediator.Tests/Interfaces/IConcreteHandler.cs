using System.Threading.Tasks;

namespace Bediator.Tests.Interfaces
{
    public interface IConcreteHandler<in TEvent>
    {
        void Handle(TEvent @event);
    }
}