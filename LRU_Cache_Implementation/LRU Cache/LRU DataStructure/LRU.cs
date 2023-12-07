namespace ConsoleApp1.LRU_DataStructure;

public class Lru
{
    private int cap = 0;
    private ListNode head = new(0, 0, null, null);
    private ListNode tail = new(0, 0, null, null);
    public Lru(int capacity)
    {
        cap = capacity;
        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key)
    {
        return -1;
    }

    public void Put(int key, int value)
    {
        
    }


    public void AddToHead(int key, int value)
    {
        ListNode node = new ListNode(key, value, head, head.Next);
        head.Next.Prev = node;
        head.Next = node;
    }

    public void AddToTail(int key, int value)
    {
        ListNode node = new ListNode(key, value, tail.Prev, tail);
        tail.Prev.Next = node;
        tail.Prev = node;
    }

    public void Remove(ListNode node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
    
    
    
}



public class ListNode
{
    public int Key;
    public int Value;
    public ListNode Prev;
    public ListNode Next;
    

    public ListNode(int key, int val, ListNode prev, ListNode next)
    {
        Key = key;
        Value = val;
        Prev = prev;
        Next = next;
    }
}