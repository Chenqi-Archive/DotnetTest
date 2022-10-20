/*
  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
  </ItemGroup>
*/
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();

services.AddSingleton<ILogger, ConsoleLogger>();
services.AddTransient<A>();

IServiceProvider provider = services.BuildServiceProvider();
A a = provider.GetRequiredService<A>();
a.Log();  // output: A


interface ILogger
{
    void Log(string text);
}

class ConsoleLogger : ILogger
{
    public ConsoleLogger()
    {
    }

    public void Log(string text)
    {
        Console.WriteLine(text);
    }
}

class FileLogger : ILogger
{
    public void Log(string text)
    {
        File.AppendAllText("logfile.log", text);
    }
}

class A
{
    private ILogger logger;

    public A(ILogger logger)
    {
        this.logger = logger;
    }

    public void Log()
    {
        logger.Log("A");
    }
}
