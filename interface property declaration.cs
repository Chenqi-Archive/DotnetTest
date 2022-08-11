
interface I
{
    public string Name { get; set; }  // only serves as function interfaces
    void Print()
    {
        Console.WriteLine(Name);
    }
}

class A : I
{
    public string Name { get; set; }  // serves as both function interfaces and member variable
    public A(string name)
    {
        Name = name;
    }
}



class Program
{
    public static void Main()
    {
        A a = new A("test");
        I ia = a;
        //a.Print();  // Error CS1061: 'A' does not contain a definition for 'Print' and no accessible extension method 'Print' accepting a first argument of type 'A' could be found(are you missing a using directive or an assembly reference ?)
        ia.Print();  // output: test
    }
}
