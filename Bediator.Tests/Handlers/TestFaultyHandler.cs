using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    public class TestFaultyHandler : IFaultyHandler<FaultyEvent>
    {
        public async Task HandleFaultyNamed(FaultyEvent @event)
        {
            await Task.Delay(50);
        }
    }
}