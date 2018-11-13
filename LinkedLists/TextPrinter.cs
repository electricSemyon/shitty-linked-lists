using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class TextPrinter
    {
        private Text text;

        public TextPrinter(Text text)
        {
            this.text = text;
        }

        public void Print()
        {
            const int CHARACTERS_PER_PIXEL = 5;

            int textLength = text.TextList.GetLength();
            int windowWidth = Console.WindowWidth;

            text.TextList.ForEach(word =>
            {

            })

        }
    }
}
