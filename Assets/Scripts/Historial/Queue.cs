using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Queue<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T t)
        {
            Value = t;
            Next = null;
            Previous = null;
        }
    }
    public Node head;
    public Node tail;
    public int length = 0;
    public void Enqueue(T value)
    {
        if (head == null)
        {
            Node newNode = new Node(value);
            head = newNode;
            tail = newNode;
            length++;
        }
        else
        {
            Node newNode = new Node(value);
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
            length++;
        }
    }
    public void Dequeue()
    {
        if (length > 0)
        {
            Node newHead = head.Next;
            newHead.Previous = null;
            head.Next = null;
            head = newHead;
            length--;
        }
        else
        {
            Console.WriteLine("La cola está vacia");
        }
    }
    public T GetNodeValueAtStart()
    {
        return head.Value;
    }
    public T GetNodeValueAtEnd()
    {
        return tail.Value;
    }
    public T GetNodeValueAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeValueAtStart();
        }
        else if (position == length - 1)
        {
            return GetNodeValueAtEnd();
        }
        else if (position >= length)
        {
            Debug.Log("No existe un nodo en esa posición.");
            throw new NullReferenceException();
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator++;
            }
            return tmp.Value;
        }
    }
}
