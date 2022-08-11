Action<int> a = (int i) => { Console.WriteLine(i); };
Action<int> b = (int j) => { Console.WriteLine(-j); };
Action<int> c = a + b;
c(1);
// output:
// 1
// -1

Func<int, A> d = (int i) => { return new(i); };
Func<int, A> e = (int j) => { return new(-j); };
Func<int, A> f = d + e;
Console.WriteLine(f(1).Value);  // d's return value will be ignored
// output:
// -1

class A
{
    public int Value { get; set; }
    public A(int value)
    {
        Value = value;
    }
    ~A()
    {
        Console.WriteLine("destructor " + Value);
    }
};


//Action d = () => { Console.WriteLine("hello"); };
//var e = c + d;  // Error CS0019: Operator '+' cannot be applied to operands of type 'Action<int>' and 'Action'
//e(1);
