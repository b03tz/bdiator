using System.Threading.Tasks;
using Bediator.Tests.Models;

namespace Bediator.Tests.Messages
{
    public class ConcreteTestEvent : ConcreteEvent
    {
        public string Name { get; set; } = null!;
    }
}