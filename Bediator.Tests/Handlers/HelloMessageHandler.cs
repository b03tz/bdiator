using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    internal class HelloMessageHandler : IMessageHandler<HelloMessage>
    {
        public async Task Handle(HelloMessage message)
        {
            message.Counter.Count += 1;
            await Task.Delay(50);
        }
    }
}