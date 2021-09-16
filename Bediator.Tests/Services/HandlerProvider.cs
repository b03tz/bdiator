using System;
using Bediator.Tests.Handlers;

namespace Bediator.Tests.Services
{
    public class HandlerProvider : IHandlerProvider
    {
        public object GetService(Type handlerType)
        {
            switch (handlerType.Name)
            {
                case nameof(CreatedEventHandler):
                    return new CreatedEventHandler();
                case nameof(GetNotifiedMessageHandler):
                    return new GetNotifiedMessageHandler();
                case nameof(HelloMessageHandler):
                    return new HelloMessageHandler();
                case nameof(UpdatedEventHandler):
                    return new UpdatedEventHandler();
                case nameof(ExceptionEventHandler):
                    return new ExceptionEventHandler();
                case nameof(TestFaultyHandler):
                    return new TestFaultyHandler();
                case nameof(ConcreteTestEventHandler):
                    return new ConcreteTestEventHandler();
            }
            
            throw new ApplicationException($"Handler for type {handlerType} not implemented!");
        }
    }
}