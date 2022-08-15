using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Human person1;
    Police person2;
    Node human,police;
    // Start is called before the first frame update
    void Start()
    {
        person1 = new Human();
        person2 = new Police();
        human = new Node() { data = person1.GetPosition() };
        police = new Node() { data = person2.GetPosition() };
        human.next = police;
        police.next = null;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        Node temp = human;
        while(temp.next!=null)
        {
            temp.data.LookAt(temp.next.data.position);
            if((temp.data.position- temp.next.data.position).magnitude>0.1f)
            temp.data.Translate(0, 0, 5f * Time.deltaTime);
            temp = temp.next;
        }

    }
    public class Node
    {
        public Transform data;
        public Node next;
    }
}
