using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

IServiceCollection services = new ServiceCollection();

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

services.Configure<Config>(configuration.GetSection("testconfig"));

services.AddTransient<A>();

IServiceProvider provider = services.BuildServiceProvider();
A a = provider.GetRequiredService<A>();
a.Print();


class Config
{
#nullable disable
    public List<string> keys { get; set; }
}

class A
{
    private IOptions<Config> options;
    public A(IOptions<Config> options)
    {
        this.options = options;
    }
    public void Print()
    {
        options.Value.keys.ForEach(Console.WriteLine);
    }
}