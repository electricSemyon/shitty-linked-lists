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

        public TextProcessor DeleteStringEntries(string entry)
        {
            text.TextList.Filter(node => node.data != entry);

            return this;
        }

        public TextProcessor OmitWordsWithLetterDuplicates(string entry)
        {
            text.TextList.Filter(node => !HasWordSameTwoLetters(node.data));

            return this;
        }

        public TextProcessor RemoveOrs()
        {
            text.TextList.Filter(node => node.data != "or");

            return this;
        }

        public TextProcessor InsertOrs()
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            text.TextList.ForEach(node => {
                newTextList.Append(node.data);
                newTextList.Append("or");
            });

            text.TextList = newTextList;

            return this;
        }

        public TextProcessor RemoveWordsWithLessThanFourCharacters()
        {
            text.TextList = text.TextList.Filter(node => node.data.Length >= 4);

            return this;
        }

        public TextProcessor ProcessWordsWithMoreThanNCharacters(int n)
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            text.TextList.ForEach(node => {
                string value = node.data;
                int length = value.Length;

                if (length > n)
                {
                    newTextList.Append(value.Substring(0, length - n) + value[length - 1]);
                }
                else
                {
                    newTextList.Append(value);
                }
            });

            text.TextList = newTextList;

            return this;
        }
    }
}
