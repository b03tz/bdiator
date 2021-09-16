using System;

namespace Bediator
{
    public interface IHandlerProvider
    {
        public object GetService(Type handlerType);
    }
}