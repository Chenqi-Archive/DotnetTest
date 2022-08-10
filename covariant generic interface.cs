interface IWrapper<out T>  // covariant generic interface
{
    void Print()
    {
        System.Console.WriteLine(typeof(T) + " " + "IWrapper");
    }
}


class Wrapper<T> : IWrapper<T>
{
    private T obj;
    public Wrapper(T obj)
    {
        this.obj = obj;
    }
    public void Print()
    {
        System.Console.WriteLine(obj.GetType() + " " + obj + " " + "Wrapper");
    }
}


class Program
{
    public static void Main()
    {
        //Object obj = new String("");
        IWrapper<string> wrapped_string = new Wrapper<string>(new string("hello"));
        IWrapper<object> wrapped_object = wrapped_string;  // type conversion
        // IWrapper<object> wrapped_object_2 = new Wrapper<string>(new string("hello"));  // also ok
        wrapped_string.Print();  // prints: System.String hello Wrapper
        wrapped_object.Print();  // prints: System.String hello Wrapper
    }
}