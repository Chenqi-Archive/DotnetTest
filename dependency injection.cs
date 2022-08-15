/*
  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
  </ItemGroup>
*/
using Microsoft.Extensions.DependencyInjection;


IServiceCollection services = new ServiceCollection();

services.AddSingleton<I, A>();
services.AddTransient<B>();

IServiceProvider provider = services.BuildServiceProvider();
B b = provider.GetRequiredService<B>();
b.Print();  // output: A


interface I
{
    void Print();
}

class A : I
{
    public void Print()
    {
        Console.WriteLine("A");
    }
}


class B
{
    readonly I i;
    public B(I i)
    {
        this.i = i;
    }
    public void Print()
    {
        i.Print();
    }
}