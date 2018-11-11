using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularDoublyLinkedList<int> text = new CircularDoublyLinkedList<int>();
            text.Append(1);
            text.Append(2);
            text.Append(3);
            text.Append(4);
            text.Print();

            //Text text = new Text();

            //text.ReadText("Assets/text.txt");



            Console.ReadKey();
        }
    }
}
