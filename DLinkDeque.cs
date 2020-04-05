using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace assignment1
{
    // Create a class that inherits from Deque and uses a doubly linked list
   
   public class Node
    {

        //The node will have three components
        //1.Data, 2.PreviousLink, 3.NextLink
        private int _data;

        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Node _next;

        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }

        private Node _previous;
        public Node Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
        //this is a constructor to build a new node with the data
        public Node(int data)
        {
            Data = data;
        }


    }


    class MyDeque : Deque
    {

        public Node head;
        public Node First
        {
            get { return head; }

        }
        public Node tail;

        public Node Last
        {
            get { return tail; }
        }

        public int Length { get; private set; }


        public override int Size { get => Length; }


        public override void Unshift(int data)
        {

            Node newNode = new Node(data);
            newNode.Next = head;

            if (head == null)
            {
                tail = newNode;
            }
            else
            {
                head.Previous = newNode;

            }
            head = newNode;
            Length++;


        }

        //removes an item from the front of deque

        public override void Push(int data)
        {
            Node newNode = new Node(data);
            if (tail == null)
            {
                head = newNode;
            }
            else
            {//Connect the final nodes
                newNode.Previous = tail;
                tail.Next = newNode;
            }
            //set new tail
            tail = newNode;
            Length++;
        }

        public override int Pop()
        {
            int DeletedV = tail.Data;
            if (tail != null)
            {
                tail = tail.Previous;
                if (tail == null)
                {
                    head = null;
                }
                Length--;
            }
            return DeletedV;
        }


        public override int Shift()
        {
            int val = head.Data;
            if (head != null)
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }

                Length--;
            }
            return val;
        }


        public IEnumerable GetEnumeratorReverse()
        {
            Node current = tail;
            while (current != null)
            {
                yield return current;
                current = current.Previous;

            }
        }


        public override void Clear()
        {

            int _Length = Length;

            for (int i = 0; i < _Length; i++)
            {
                if (head != null)
                {
                    head = head.Next;
                    if (head == null)
                    {
                        tail = null;
                    }

                    Length--;
                }
            }

        }


        public override DequeEnumerator GetEnumerator()
        {
            
             return new ArraySeqEnumerator(head);

        }


    }

    public class ArraySeqEnumerator : DequeEnumerator
    {

        public Node current;
        public Node C;
        public int count=1;
       


        public ArraySeqEnumerator(Node ND)
        {
            current = ND;
            C= current;
            
        }

        public override bool MoveNext()
        {
            if (count == 1)
            {
                count++;
                return (current != null);
            }
            else
            {
                current = current.Next;
                return (current != null);
            }
           
        }

        public override void Reset()
        {
            current = C;
        }
       
        public override int Current
        {
            get
            {
                
                    return current.Data;
             
            }
           
        }

    }
	
   class Program
    {

        static void Main(string[] args)
        {

        }
    }

}