
using Ref;

class Program
{
    public static void Main()
    {
        // class in the same project
        // can be directly referenced
        A a = new A("a");
        a.Print();

        // class in the same project with a namespace
        // can be referenced with namespace modifier
        new C().Print();
        new Ref.C().PrintRef();

        // class in another project
        // should first reference the project
        B b = new B(2);
        b.Print();

        //new LibLib(3).Print();
    }
}


namespace Ref
{
    partial class C
    {
        public void PrintRef()
        {
            Console.WriteLine("C Ref");
        }
    }
}