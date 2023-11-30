using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkedList<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    private Node head;
    private int length = 0;
    public void AddNodeAtStart(T value)
    {
        if (head != null)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        else if (head == null)
        {
            Node newNode = new Node(value);
            head = newNode;
        }
        length++;
    }
    public void AddNodeAtEnd(T value)
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        Node newNode = new Node(value);
        tmp.Next = newNode;
        newNode.Previous = tmp;
        length++;
    }
    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNodeAtStart(value);
        }
        else if (position == length)
        {
            AddNodeAtEnd(value);
        }
        else if (position > length)
        {
            Debug.Log("Esa posición no existe.");
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                tmp = tmp.Next;
                iterator++;
            }
            Node newNode = new Node(value);
            Node nextNode = tmp.Next;

            tmp.Next = newNode;
            newNode.Previous = tmp;

            newNode.Next = nextNode;
            nextNode.Previous = newNode;

            length++;
        }
    }
    public void ModifyAtStart(T value)
    {
        head.Value = value;
    }
    public void ModifyAtEnd(T value)
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        tmp.Value = value;
    }
    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == length - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position >= length)
        {
            Debug.Log("No existe esa posición.");
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                tmp = tmp.Next;
                iterator++;
            }
            tmp.Value = value;
        }
    }
    public T GetNodeValueAtStart()
    {
        return head.Value;
    }
    public T GetNodeValueAtEnd()
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        return tmp.Value;
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
    public void DeleteAtStart()
    {
        Node newHead = head.Next;
        head.Next = null;
        head = newHead;
        head.Previous = null;
        length--;
    }
    public void DeleteAtEnd()
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        Node previous = tmp.Previous;
        previous.Next = null;
        tmp.Previous = null;
        length--;
    }
    public void DeleteAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == length)
        {
            DeleteAtEnd();
        }
        else if (position > length)
        {
            Debug.Log("Esa posición no exiswte.");
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

            Node previous = tmp.Previous;
            Node next = tmp.Next;

            previous.Next = next;
            tmp.Previous = null;

            next.Previous = previous;
            tmp.Next = null;

            length--;
        }
    }
    public void PrintAllNodes()
    {
        Node tmp = head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
    }
    private Node GetCurrentNode(T value)
    {
        Node currentNode = head;
        dynamic node = value;

        while (currentNode.Next != head)
        {
            if (currentNode.Value == node)
            {
                break;
            }
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
    public T PrintPreviousNode(T value)
    {
        if (GetCurrentNode(value).Previous == null)
        {
            return GetCurrentNode(value).Value;
        }
        else
        {
            return GetCurrentNode(value).Previous.Value;
        }
    }
    public T PrintNextNode(T value)
    {
        if (GetCurrentNode(value).Next == null)
        {
            return GetCurrentNode(value).Value;
        }
        else
        {
            return GetCurrentNode(value).Next.Value;
        }
    }
}

