using System.Collections;

namespace Assignment_6._3._1;

public class LinkedListQueue<T> : IEnumerable<T>
{
    
    private class Node // class to create a node in the linked list
    {
        public T Data { get; set; } // generic type so we can store any type of data in the linked list node
        public Node? Next { get; set; } // reference to the next node in the linked list
        public Node(T data) // constructor to create a node of a generic type in the linked list
        {
            Data = data;
            Next = null;
        }
    }
    
    private Node? _head; // this node will be the head of the queue
    private Node? _tail; // this node is the tail of the queue
    private int _count; //backing field for the count of the number of items in the queue

    public int Count => _count; // keep the count of the number of items in the queue
    public bool IsEmpty => _count == 0;

    public LinkedListQueue() // constructor to ensure we have a head and tail. 
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public void Enqueue(T item) //takes in generic type and adds it to the queue
    {
        Node newNode = new Node(item);
        
        if (IsEmpty) // if the queue is empty, then the head and tail will be the same node
        {
            _head = newNode;
            _tail = newNode;
        }
        else // if the queue is not empty, then the tail will be the new node and the new node will be the next node (end of queue) of the tail
        {
            _tail!.Next = newNode; // set the next node of the tail to the new node
            _tail = newNode; // assign the new node as the tail
        }
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty || _head == null) // can't remove something that doesn't exist
        {
            throw new InvalidOperationException("Queue is empty");
        }

        if (_head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T data = _head.Data; // store the data of the head node in a variable
        _head = _head.Next; // set the head to the next node from the head
        _count--;
        
        if (IsEmpty)
        {
            _tail = null;
        }
        return data; //this was the head node's data we want to dequeue
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}