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
            text.TextList.Print();

            TextProcessor processor = new TextProcessor(text);

            Console.WriteLine(processor.Text.TextList.GetLength());

            processor
                .OmitWordsWithLetterDuplicates()
                .RemoveOrs()
                .InsertOrs()
                .RemoveWordsWithLessThanNCharacters(4)
                .ProcessWordsWithMoreThanNCharacters(4);

            foreach (String word in processor.Text.TextList)
                Console.WriteLine(word);
            
            Console.ReadKey();
        }
    }
}
