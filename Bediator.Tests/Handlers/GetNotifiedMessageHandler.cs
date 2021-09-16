using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    internal class GetNotifiedMessageHandler : IMessageHandler<GetNotifiedMessage>
    {
        public async Task HandleAsync(GetNotifiedMessage message)
        {
            message.Counter.Count += 1;
            await Task.Delay(50);
        }
    }
}