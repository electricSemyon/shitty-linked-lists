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
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
