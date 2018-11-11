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
            return plainText.Split(new Char[] { ',', '\n', '.', ' ' });
        }
    }
}
