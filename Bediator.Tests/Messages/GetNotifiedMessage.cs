using Bediator.Tests.Interfaces;
using Bediator.Tests.Models;

namespace Bediator.Tests.Messages
{
    internal class GetNotifiedMessage : IMessage
    {
        public string Notification { get; set; } = null!;
        public Counter Counter { get; set; } = null!;
    }
}