
namespace ContactManagement.Test
{
    using Microsoft.Extensions.Configuration;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected IConfiguration Configuration { get; private set; }

        public TestBase()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
