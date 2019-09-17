using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConcepts.OOPS
{
    static class LinkedListSample
    {
        public static LinkedList<int> createLinkedList(int[] arr)
        {

            return new LinkedList<int>(arr);
        }

        public static void reverseLinkedList(LinkedList<int> linkedList)
        {
            //var currentNode = linkedList.First;
            //LinkedListNode<int> previousNode = null;
            //var newLinkedList = new LinkedList<int>();

            //while (currentNode != null)
            //{
            //    var nextNode = currentNode.Next;
            //    currentNode.Next = previousNode;

            //    previousNode = currentNode;
            //    currentNode = nextNode;
            //}

            //return previousNode;



        }
    }

    public class CustomLinkedListNode
    {
        public CustomLinkedListNode(int value = 0)
        {
            data = value;
            next = null;
        }

        public int data { set; get; }
        public CustomLinkedListNode next { set; get; }


        public CustomLinkedListNode InsertNext(int value)
        {
            CustomLinkedListNode node = new CustomLinkedListNode(value);

            if (this.next == null)
            {
                // Easy to handle
                node.next = null; // already set in constructor
                this.next = node;
            }
            else
            {
                // Insert in the middle
                CustomLinkedListNode temp = this.next;
                node.next = temp;
                this.next = node;
            }
            return node;
        }
    }
}
