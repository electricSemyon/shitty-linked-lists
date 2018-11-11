using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class CircularDoublyLinkedList<T>
    {
        LinkedNode<T> head = null;

        public void Append(T data)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                head.AppendToEnd(newNode, head);
            }
        }

        override public string ToString()
        {
            LinkedNode<T> temp = head;
            string result = "";

            do
            {
                result += temp.data.ToString() + " -> ";

                if (temp.nextNode == head) result += "head";

                temp = temp.nextNode;
            } while (temp != head);

            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
