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
        private CircularDoublyLinkedList<String> TextList;

        public void ReadText(string path)
        {
            try {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
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
            return plainText.Split(new Char[] { ',', '\n', '.' });
        }
    }
}
