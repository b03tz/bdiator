using System;
using System.Threading.Tasks;
using Bediator.Tests.Exceptions;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    internal class ExceptionEventHandler : IEventHandler<ExceptionEvent>
    {
        public async Task HandleAsync(ExceptionEvent @event)
        {
            await Task.Delay(50);
            
            throw new ExceptionHandlerException("Handler has thrown exception!");
        }
    }
}