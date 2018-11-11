using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class TextProcessor
    {
        public static string GetFirstWordWithTwoSameLetters(Text text)
        {
            string result = null;

            text.TextList.ForEach(node =>
            {
                if (node.data.ToList<char>().GroupBy(n => n).Any(c => c.Count() > 1))
                    result = node.data;
            });

            return result;
        }

        public static Text DeleteStringEntries(Text text, string entry)
        {
            CircularDoublyLinkedList<string> oldTextList = text.TextList;
            CircularDoublyLinkedList<string> newTextList = new CircularDoublyLinkedList<string>();

            oldTextList.ForEach(node =>
            {
                if (node.data != entry) newTextList.Append(node.data);
            });

            text.TextList = newTextList;

            return text;
        }
    }
}
