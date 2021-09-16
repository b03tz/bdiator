using Bediator.Tests.Interfaces;
using Bediator.Tests.Models;

namespace Bediator.Tests.Messages
{
    internal class HelloMessage : IMessage
    {
        public string Message { get; set; } = null!;
        public Counter Counter { get; set; } = null!;
    }
}