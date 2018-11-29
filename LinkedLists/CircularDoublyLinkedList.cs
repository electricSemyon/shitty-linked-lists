using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        LinkedNode<T> head = null;
        public delegate void ForEachLambda(LinkedNode<T> node);
        public delegate bool FilterLambda(LinkedNode<T> node);
        public delegate dynamic ReduceLambda(LinkedNode<T> node, dynamic acc);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> temp = head;

            do
            {
                yield return temp.data;
                temp = temp.nextNode;
            } while (temp != head);
        }

        public T this[int index]
        {
            get
            {
                LinkedNode<T> temp = head;

                for (int i = 0; i < index; i++)
                {
                    if (head.nextNode == null)
                        throw new Exception("Out of bounds");

                    temp = temp.nextNode;
                }

                return temp.data;
            }
            set
            {
                LinkedNode<T> temp = head;

                for (int i = 0; i < index; i++)
                {
                    if (head.nextNode == null)
                        throw new Exception("Out of bounds");

                    temp = temp.nextNode;
                }

                temp.data = value;
            }
        }

        public void Append(T data)
        {
            LinkedNode<T> node = new LinkedNode<T>(data);

            if (head == null)
            {
                head = node;
                head.nextNode = node;
                head.previousNode = node;
            }
            else
            {
                node.previousNode = head.previousNode;
                node.nextNode = head;
                head.previousNode.nextNode = node;
                head.previousNode = node;
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

        override public string ToString()
        {
            string result = "";

            ForEach(node =>
            {
                result += $"{ node.data } -> ";

                if (node.nextNode == head)
                {
                    result += $"{ head.data } (head element)";
                }

                node = node.nextNode;
            });

            return result;
        }
    }
}
