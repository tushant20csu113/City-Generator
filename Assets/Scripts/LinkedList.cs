using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkedList : MonoBehaviour
{
    public void Ques()
    {
        LinkedList list = new LinkedList();
        //10
        for (int i = 10; i >= 1; i--)
        {
            list.PushNode(i);
            // list.PrintNode();     
        }
        list.PrintMiddle();
        /*
                //20
                for (int i = 20; i >= 1; i--)
                {
                    list.PushNode(i);
                    list.PrintNode();
                    list.PrintMiddle();
                }

                //50
                for (int i = 50; i >= 1; i--)
                {
                    list.PushNode(i);
                    list.PrintNode();
                    list.PrintMiddle();
                }
        */
    }

    class Node // Creating new node
    {
        public int data;

        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    Node head;

    //Method to add node
    //Head(newNode) -> (Original Head) ->null(whatever)
    public void PushNode(int data)
    {
        Node newNode = new Node(data); // initialise
        newNode.next = head;
        head = newNode;
    }

    //Print elements in the list
    public void PrintNode()
    {
        Node temp = head;
        while (temp != null)
        {
            Debug.Log(temp.data + "->");
            temp = temp.next;
        }
        Debug.Log("Null" + "\n");
    }

    //Find Length of the list
    public int GetLength()
    {
        int length = 0;
        Node temp = head;
        while (temp != null)
        {
            length++;
            temp = temp.next;
        }
        return length;
    }

    //Printing the middle element of the list.
    public void PrintMiddle()
    {
        if (head != null)
        {
            int length = GetLength();
            Node temp = head;
            int middle = length / 2;

            while (middle != 0)
            {
                temp = temp.next;
                middle--;
            }
            Debug.Log("Middle element is " + temp.data + "  \n");
        }
    }
    private void Start()
    {
        Ques();
    }
}