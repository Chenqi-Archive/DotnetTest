
int a;
int? na;
//int?? nna;
Action<int> act;
Action<int>? nact;

a = 1;
//a = null;  // Error CS0037 Cannot convert null to 'int' because it is a non-nullable value type
na = 1;
na = null;

act = null;  // Warning CS8600	Converting null literal or possible null value to non-nullable type.
//act(a);
//act.Invoke(a);  // System.NullReferenceException: 'Object reference not set to an instance of an object.'
act?.Invoke(a);  // nothing
act = (int a) => { Console.WriteLine(a); };
act(a);  // output: 1
//act((int)na);  // System.InvalidOperationException: 'Nullable object must have a value.'

nact = null;
//nact(a);
//nact.Invoke(a);  // System.NullReferenceException: 'Object reference not set to an instance of an object.'
nact?.Invoke(a);  // nothing
nact = (int a) => { Console.WriteLine(a); };
nact(na ?? 0);  // output: 0



ModAction<int> mact = (ref int a) => { a++; };
mact(ref a);
nact(a);  // output: 2
//mact(ref na);

delegate void ModAction<T>(ref T obj);
