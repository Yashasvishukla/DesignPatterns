namespace ConsoleApp1.LRU_DataStrcture;

public class Lru
{
    
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