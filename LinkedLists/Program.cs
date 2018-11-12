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

            processor.DeleteStringEntries(firstEntryWithTwoSameLetters);
            processor.OmitWordsWithLetterDuplicates("dolor");
            processor.RemoveOrs();
            processor.InsertOrs();
            processor.RemoveWordsWithLessThanFourCharacters();
            processor.ProcessWordsWithMoreThanFourCharacters();


            processor.text.TextList.Print();

            Console.ReadKey();
        }
    }
}
