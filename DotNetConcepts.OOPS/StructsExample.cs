using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConcepts.OOPS
{
    class StructsExample
    {
        public static MyStruct ChangeMyStruct(MyStruct input)
        {
            input.MyProperty = "new value";
            return input;
        }

        public static void CheckValues()
        {
            A c1 = new A(), c2 = c1, c3 = new A();
            c1.a = c1.b = c2.a = c2.b = c3.a = c3.b = 1;
            B s1 = new B(), s2 = new B();
            s1.a = s1.b = s2.a = s2.b = 1;
            s1.A = new A();
            s2.A = s1.A;
            //s2.b = 3;
            Console.WriteLine("s1.Equals(s2)" + s1.Equals(s2));
            Console.WriteLine("s1.Equals(c1)" + s1.Equals(c1));
            Console.WriteLine("c1.Equals(c2)" + c1.Equals(c2));
            Console.WriteLine("c1.Equals(c3)" + c1.Equals(c3));
            Console.WriteLine("c1 == c2 {0}", c1 == c2);
        }
    }

    struct MyStruct
    {
        public string MyProperty { get; set; }
        public A A { get; set; }
    }

    class A
    {
        public int a, b;
    }
    struct B
    {
        public int a, b;
        public A A { get; set; }
    }
}
