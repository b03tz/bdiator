using System;
using Bediator.Tests.Handlers;

namespace Bediator.Tests.Services
{
    public class NullHandlerProvider : IHandlerProvider
    {
        public object? GetService(Type handlerType)
        {
            return null;
        }
    }
}