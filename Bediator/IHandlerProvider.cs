using System;

namespace Bediator
{
    public interface IHandlerProvider
    {
        object GetService(Type handlerType);
    }
}