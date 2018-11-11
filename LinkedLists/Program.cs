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
            Text text = new Text();

            text.ReadText("Assets/text.txt");
            text.TextList.Print();

            string firstEntryWithTwoSameLetters = TextProcessor.GetFirstWordWithTwoSameLetters(text);
            Text newText = TextProcessor.DeleteStringEntries(text, "dolor");


            Console.ReadKey();
        }
    }
}
