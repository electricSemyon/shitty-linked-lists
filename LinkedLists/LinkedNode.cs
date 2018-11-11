using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class LinkedNode<T>
    {
        public LinkedNode<T> previousNode { get; set; }
        public LinkedNode<T> nextNode { get; set; }

        public T data { get; set; }

        public LinkedNode(T data)
        {
            this.data = data;
        }

        public void Append(LinkedNode<T> nodeToAppend)
        {
            nextNode = nodeToAppend;
            nodeToAppend.previousNode = this;
        }

        public void AppendToEnd(LinkedNode<T> nodeToAppend, LinkedNode<T> first)
        {
            if (nextNode == first || nextNode == null) {
                nodeToAppend.nextNode = first;
                Append(nodeToAppend);
            }
            else nextNode.AppendToEnd(nodeToAppend, first);
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
