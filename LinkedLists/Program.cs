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
            string firstEntryWithTwoSameLetters = TextProcessor.GetFirstWordWithTwoSameLetters(text);

            Console.WriteLine(processor.text.TextList.GetLength());

            processor.DeleteStringEntries(firstEntryWithTwoSameLetters)
                .OmitWordsWithLetterDuplicates("dolor")
                .RemoveOrs()
                .InsertOrs()
                .RemoveWordsWithLessThanFourCharacters()
                .ProcessWordsWithMoreThanNCharacters(4);


            processor.text.TextList.Print();


            Console.ReadKey();
        }
    }
}
