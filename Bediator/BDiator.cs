using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bediator
{
    public class BDiator
    {
        private readonly IHandlerProvider handlerProvider;
        private readonly List<IBDiatorInstance> bDiatorInstances = new List<IBDiatorInstance>();
        private readonly BDiatorOptions options = new BDiatorOptions();
        
        public BDiator(IHandlerProvider handlerProvider, BDiatorOptions? bdiatorOptions = null)
        {
            this.options = bdiatorOptions ?? this.options;
            this.handlerProvider = handlerProvider;
        }

        public void Subscribe<THandlerType, TMessageType>()
        {
            this.bDiatorInstances.Add(new BDiatorInstance<THandlerType, TMessageType>(this.handlerProvider, this.options));
        }

        public async Task HandleAsync<TMessageType>(TMessageType message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var bdiatorFound = false;
            foreach (var bdiatorInstance in this.bDiatorInstances)
            {
                bdiatorFound = await bdiatorInstance.HandleAsync(message);

                if (bdiatorFound)
                    break;
            }

            if (!bdiatorFound)
            {
                throw new ApplicationException($"There was no handler registered for message type {message.GetType()}");
            }
        }
    }
}