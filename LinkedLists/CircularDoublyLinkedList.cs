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
        public delegate void ForEachCalback(LinkedNode<T> node);

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

        public void ForEach(ForEachCalback cb)
        {
            LinkedNode<T> temp = head;

            do
            {
                cb(temp);
                temp = temp.nextNode;
            } while (temp != head);
        }

        override public string ToString()
        {
            string result = "";

            this.ForEach(node =>
            {
                result += GetNodeString(node);

                if (node.nextNode == head)
                {
                    result += GetNodeString(head, true);
                }

                node = node.nextNode;
            });

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
