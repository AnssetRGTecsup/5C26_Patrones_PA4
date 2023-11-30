using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularDoubleLinkedList<T>
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
        if (head == null)
        {
            Node newNode = new Node(value);
            head = newNode;
            head.Next = head;
            head.Previous = head;
            length++;
        }
        else
        {
            Node newNode = new Node(value);

            Node endNode = head;
            while (endNode.Next != head)
            {
                endNode = endNode.Next;
            }
            endNode.Next = newNode;
            newNode.Previous = endNode;

            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            length++;
        }
    }
    public void AddNodeAtEnd(T value)
    {
        Node endNode = GetLastNode();

        Node newNode = new Node(value);
        endNode.Next = newNode;
        newNode.Previous = endNode;

        newNode.Next = head;
        head.Previous = newNode;
        length++;
    }
    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNodeAtStart(value);
        }
        else if (position == length - 1)
        {
            AddNodeAtEnd(value);
        }
        else if (position >= length)
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

            Node nextNode = tmp.Next;

            Node newNode = new Node(value);

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
        Node endNode = GetLastNode();
        endNode.Value = value;
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
            while (iterator < position)
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
        return GetLastNode().Value;
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
        Node endNode = GetLastNode();

        head = head.Next;
        endNode.Next = head;
        head.Next = endNode;
        length--;
    }
    public void DeleteAtEnd()
    {
        Node tmp = head;
        while (tmp.Next.Next != head)
        {
            tmp = tmp.Next;
        }
        Node endNode = tmp.Next;
        endNode.Next = null;
        head.Previous = null;

        tmp.Next = head;
        head.Previous = tmp;
        length--;
    }
    public void DeleteAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == length - 1)
        {
            DeleteAtEnd();
        }
        else if (position >= length)
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

            Node nodeToDelete = tmp.Next;
            tmp.Next = nodeToDelete.Next;
            nodeToDelete.Next.Previous = tmp;

            nodeToDelete.Next = null;
            nodeToDelete.Previous = null;

            length--;
        }
    }
    private Node GetLastNode()
    {
        Node endNode = head;

        while (endNode.Next != head)
        {
            endNode = endNode.Next;
        }
        return endNode;
    }
    public void PrintAllNodes()
    {
        Node tmp = head;
        while (tmp.Next != head)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Debug.Log(tmp.Value + " ");
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
        return GetCurrentNode(value).Previous.Value;
    }
    public T PrintNextNode(T value)
    {
        return GetCurrentNode(value).Next.Value;
    }
}
