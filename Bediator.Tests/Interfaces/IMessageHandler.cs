﻿using System.Threading.Tasks;

namespace Bediator.Tests.Interfaces
{
    internal interface IMessageHandler<in TMessage>
        where TMessage : IMessage
    {
        Task Handle(TMessage message);
    }
}