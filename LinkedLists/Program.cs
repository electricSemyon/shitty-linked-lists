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
            text.ReadText("../../Assets/text.txt");

            text.Print();

            Console.WriteLine("---");

            TextProcessor processor = new TextProcessor(text);

            processor
                .OmitWordsWithLetterDuplicates()
                .RemoveOrs()
                .InsertOrs()
                .RemoveWordsWithLessThanNCharacters(4)
                .ProcessWordsWithMoreThanNCharacters(4);

            processor.Text.Print();

            Console.ReadKey();
        }
    }
}
