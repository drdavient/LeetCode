using System.Collections;

namespace LeetCode;

public class ListNode 
{ 
    public int val;
    public ListNode next;
    
    public ListNode(int val=0, ListNode next=null) 
    { 
        this.val = val;
        this.next = next;
    }
}
public class ReverseLinkedList206
{
    public  ListNode ReverseList(ListNode head)
    {
        ListNode reverse = head ==null ? null: new ListNode(head.val);
        while (head !=null && head.next != null)
        {
            ListNode prev = new ListNode(head.next.val);
            prev.next = reverse;
            reverse = prev;
            head = head.next;
        }

        return reverse;

    }
}

// public class Solution
// {
//     public ListNode ReverseList(ListNode head)
//     {
//         
//     }
// }