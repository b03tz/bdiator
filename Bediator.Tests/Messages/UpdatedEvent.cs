using System;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Models;

namespace Bediator.Tests.Messages
{
    internal class UpdatedEvent : IEvent
    {
        public DateTime UpdatedTime { get; set; }
        public Counter Counter { get; set; } = null!;
    }
}