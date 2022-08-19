using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


IServiceCollection services = new ServiceCollection();

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

Config config = configuration.GetSection("testconfig").Get<Config>();

services.Configure<Config>(configuration.GetSection("testconfig"));
services.AddTransient<A>();

IServiceProvider provider = services.BuildServiceProvider();
A a = provider.GetRequiredService<A>();
while (Console.ReadLine() != null)
{
    a.Print();
}


/*
{
  "testconfig": {
    "s": {
      "Key": [
        "abc",
        "def"
      ]
    }
  }
}
*/

class Config
{
#nullable disable
    [ConfigurationKeyName("s:Key")]
    public HashSet<string> keys { get; set; }
}

class A
{
    private IOptions<Config> options;
    private IOptionsMonitor<Config> options_m;
    public A(IOptions<Config> options, IOptionsMonitor<Config> options_m)
    {
        this.options = options;
        this.options_m = options_m;

        this.options_m.OnChange((config, str) =>
        {
            Console.WriteLine("config changed");
            config.keys.ToList().ForEach(Console.WriteLine);
            Console.WriteLine(str);
        });
    }
    public void Print()
    {
        options.Value.keys.ToList().ForEach(Console.WriteLine);
        options_m.CurrentValue.keys.ToList().ForEach(Console.WriteLine);
    }
}
