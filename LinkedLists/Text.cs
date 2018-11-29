using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinkedLists
{
    class Text
    {
        public CircularDoublyLinkedList<String> TextList { get; set; }

        public void ReadText(string path)
        {
            TextList = new CircularDoublyLinkedList<string>();

            try {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    String[] words = SplitTextBySeparator(line);

                    foreach(string word in words)
                    {
                        TextList.Append(word);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public string[] SplitTextBySeparator(string plainText)
        {
            Char[] separators = new Char[] { '\n', '.', ' ' };

            return plainText
                .Split(separators)
                .Where(element =>  element.Length > 0)
                .Select(element => element.Trim())
                .ToArray();
        }

        public void Print()
        {
            int WORDS_PER_LINE = 4;

            for(int i = 0; i < TextList.Count(); i++)
            {
                Console.Write(TextList[i] + " ");

                if (i % WORDS_PER_LINE == 0 && i != 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
