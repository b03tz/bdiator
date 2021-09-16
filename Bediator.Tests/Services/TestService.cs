using Bediator.Tests.Interfaces;

namespace Bediator.Tests.Services
{
    internal class TestService : ITestService
    {
        public string GetName()
        {
            return "John Doe";
        }
    }
}