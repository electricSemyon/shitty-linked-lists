using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class TextProcessor
    {
        public Text text { get; }

        public TextProcessor(Text text)
        {
            this.text = text;
        }

        public static string GetFirstWordWithTwoSameLetters(Text text)
        {
            string result = null;

            text.TextList.ForEach(node =>
            {
                if (HasWordSameTwoLetters(node.data))
                    result = node.data;
            });

            return result;
        }

        public static bool HasWordSameTwoLetters(string word)
        {
            return word.ToList<char>().GroupBy(n => n).Any(c => c.Count() > 1);
        }

        public void DeleteStringEntries(string entry)
        {
            text.TextList.Filter(node => node.data != entry);
        }

        public void OmitWordsWithLetterDuplicates(string entry)
        {
            text.TextList.Filter(node => !HasWordSameTwoLetters(node.data));
        }

        public void SwapPairs(string entry)
        {
            text.TextList.Filter(node => HasWordSameTwoLetters(node.data));
        }

        public void RemoveOrs()
        {
            text.TextList.Filter(node => node.data != "or");
        }

        public void InsertOrs()
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            text.TextList.ForEach(node => {
                newTextList.Append(node.data);
                newTextList.Append("or");
            });

            text.TextList = newTextList;
        }

        public void RemoveWordsWithLessThanFourCharacters()
        {
            text.TextList = text.TextList.Filter(node => node.data.Length >= 4);
        }

        public void ProcessWordsWithMoreThanFourCharacters()
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            text.TextList.ForEach(node => {
                string value = node.data;
                int length = value.Length;

                if (length > 4)
                {
                    newTextList.Append(value.Substring(0, length - 4) + value[length - 1]);
                }
                else
                {
                    newTextList.Append(value);
                }
            });

            text.TextList = newTextList;
        }
    }
}
