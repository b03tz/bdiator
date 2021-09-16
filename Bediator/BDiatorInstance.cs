using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bediator.Helpers;

namespace Bediator
{
    public class BDiatorInstance<THandlerType, TMessageType> : IBDiatorInstance
    {
        private readonly IHandlerProvider handlerProvider;
        private readonly AssemblyScanner assemblyScanner = new AssemblyScanner();
        private readonly Dictionary<Type, List<Type>> handlersByMessageTypes;

        public BDiatorInstance(IHandlerProvider handlerProvider, BDiatorOptions bDiatorOptions)
        {
            this.handlerProvider = handlerProvider;
            this.handlersByMessageTypes = this.assemblyScanner.GetHandlers<THandlerType, TMessageType>(bDiatorOptions.HandlerAssemblies);
        }

        public async Task<bool> HandleAsync<TMessageType1>(TMessageType1 message)
        {
            if (!this.handlersByMessageTypes.ContainsKey(message.GetType()))
                return false;

            await RaiseHandlersAsync(this.handlersByMessageTypes[message.GetType()], message);

            return true;
        }

        private async Task RaiseHandlersAsync<TMessageType1>(IEnumerable<Type> handlers, TMessageType1 message)
        {
            foreach (var handlerType in handlers)
            {
                var messageHandler = this.handlerProvider.GetService(handlerType) ??
                                     throw new ApplicationException($"No messagehandler registered for {handlerType}");
                
                var method = messageHandler.GetType().GetMethod("Handle");
                
                if (method == null)
                    throw new ApplicationException($"Handler {messageHandler} should have a 'Handle' method!");

                var result = method?.Invoke(messageHandler, new object?[] { message });

                if (result == null)
                    continue;

                Task resultTask = (Task) result;

                await resultTask;
            }
        }
    }
}