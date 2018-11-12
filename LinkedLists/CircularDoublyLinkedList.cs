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
        public delegate dynamic ReduceLambda(LinkedNode<T> node, dynamic acc);

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

        public dynamic Reduce(ReduceLambda f, dynamic initialAcc)
        {
            var acc = initialAcc;

            ForEach(node => acc = f(node, acc));

            return acc;
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

        public int GetLength()
        {
            return Reduce((node, acc) => acc + 1, 0);
        } 

        override public string ToString()
        {
            string result = "";

            ForEach(node =>
            {
                result += $"{ node.data } -> ";

                if (node.nextNode == head)
                {
                    result += node.data;
                }

                node = node.nextNode;
            });

            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
