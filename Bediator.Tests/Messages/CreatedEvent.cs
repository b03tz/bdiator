using System;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Models;

namespace Bediator.Tests.Messages
{
    internal class CreatedEvent : IEvent
    {
        public CreatedEventDetails EventDetails { get; set; } = null!;
        public Counter Counter { get; set; } = null!;
    }

    internal class CreatedEventDetails
    {
        public Guid Id { get; set; }
    }
}