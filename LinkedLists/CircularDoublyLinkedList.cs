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
                head.previousNode = newNode;
                head.AppendToEnd(newNode, head);
            }
        }

        override public string ToString()
        {
            LinkedNode<T> temp = head;
            string result = "";

            do
            {
                result += GetNodeString(temp);

                if (temp.nextNode == head)
                {
                    result += GetNodeString(head, true);
                }

                temp = temp.nextNode;

            } while (temp != head);

            return result;
        }

        private string GetNodeString(LinkedNode<T> node, bool isLast = false)
        {
            return $"[" +
                   $"data: { node.data.ToString() } " +
                   $"] { (isLast ? "" : "-> ") }" +
                   $"";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
