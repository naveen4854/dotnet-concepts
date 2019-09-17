using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetConcepts.OOPS.UtiliesTests;

namespace DotNetConcepts.OOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //var DefaultScrambledList = new List<LinkedListItem<string>>()
            //    {
            //        new LinkedListItem<string>("b", "c"),
            //        new LinkedListItem<string>("a", "b"),
            //        new LinkedListItem<string>("d", null),
            //        new LinkedListItem<string>("c", "d"),
            //    };

            //var DefaultScrambledList = new List<LinkedListItem<string>>()
            //    {
            //        new LinkedListItem<string>("b", "d"),
            //        new LinkedListItem<string>("a", "c"),
            //        new LinkedListItem<string>("d", null),
            //        new LinkedListItem<string>("c", "b"),
            //    };

            //var result = DefaultScrambledList.SortAsLinkedList(x => x.Id, x => x.NextId);

            //MyStruct testStruct = new MyStruct { MyProperty = "initial value" };
            //var test = StructsExample.ChangeMyStruct(testStruct);
            //StructsExample.CheckValues();



            var test = LinkedListSample.createLinkedList(new[] { 1, 2, 3, 4 });

            Console.ReadLine();
        }
    }
}
