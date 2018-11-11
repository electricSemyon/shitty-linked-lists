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
        public delegate void ForEachLambda(LinkedNode<T> node);
        public delegate bool FilterLambda(LinkedNode<T> node);

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

        public void ForEach(ForEachLambda cb)
        {
            LinkedNode<T> temp = head;

            do
            {
                cb(temp);
                temp = temp.nextNode;
            } while (temp != head);
        }

        public CircularDoublyLinkedList<T> Filter(FilterLambda predicate)
        {
            CircularDoublyLinkedList<T> newList = new CircularDoublyLinkedList<T>();

            ForEach(node =>
            {
                if (predicate(node)) newList.Append(node.data);
            });

            return newList;
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
