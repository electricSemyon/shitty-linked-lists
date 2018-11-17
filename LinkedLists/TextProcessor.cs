using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class TextProcessor
    {
        public Text Text { get; }

        public TextProcessor(Text text)
        {
            this.Text = text;
        }

        private static bool HasWordSameTwoLetters(string word)
        {
            return word.ToList<char>().GroupBy(n => n).Any(c => c.Count() > 1);
        }

        public TextProcessor OmitWordsWithLetterDuplicates()
        {
            Text.TextList.Filter(node => !HasWordSameTwoLetters(node.data));

            return this;
        }

        public TextProcessor RemoveOrs()
        {
            Text.TextList.Filter(node => node.data != "or");

            return this;
        }

        public TextProcessor InsertOrs()
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            Text.TextList.ForEach(node => {
                newTextList.Append(node.data);
                newTextList.Append("or");
            });

            Text.TextList = newTextList;

            return this;
        }

        public TextProcessor RemoveWordsWithLessThanNCharacters(int n)
        {
            Text.TextList = Text.TextList.Filter(node => node.data.Length >= n);

            return this;
        }

        public TextProcessor ProcessWordsWithMoreThanNCharacters(int n)
        {
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            Text.TextList.ForEach(node => {
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

            Text.TextList = newTextList;

            return this;
        }
    }
}
