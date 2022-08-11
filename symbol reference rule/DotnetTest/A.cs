
internal class A
{
    public string Name { get; set; }
    public A(string name)
    {
        Name = name;
    }
    public void Print()
    {
        Console.WriteLine(Name);
    }
}
