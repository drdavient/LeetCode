using System.IO.Compression;
using Newtonsoft.Json;

namespace LeetCode;
 
public  class MergeKSortedLists23
{
    public class  ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static ListNode? MergeKLists(string lists)
    {
        int[][]bob = JsonConvert.DeserializeObject<int[][]>("[[1,4,5],[1,3,4],[2,6]]");
        ListNode[] listNodes = new ListNode[bob.Length];
        ListNode[] listNodesHead = new ListNode[bob.Length];
        
        // for (var i = 0; i < bob.Length; i++)
        // {
        //     for (int k = 0; k < bob[i].Length; k++)
        //     {
        //         listNodes
        //     }

        IsCharacter(lists, 0, '[',true);
        for (var index = 0; index < lists.Substring(1, lists.Length - 2).Length; index++)
        {
            var character = lists.Substring(1, lists.Length - 2)[index];
            if (IsCharacter(lists, index, '['))
            {
                // new List
            }
           // else if (IsCharacter())
                
        }

        IsCharacter(lists, lists.Length-1, ']',true);

        return null;
    }

    private static bool IsCharacter(string lists, int position, char expected, bool throwException=false)
    {
        if (lists[position] != expected)
        {
            if(throwException) throw new ArgumentException($"at position {position} expected {expected}, got {lists[position]}");
            return false;
        }

        return true;
    }

    public static ListNode? MergeKLists(ListNode?[] lists)
    {
        ListNode? mergedList = null;
        ListNode? listNode = null;
        int[] indexes = new int [lists.Length];
        int lowest = int.MaxValue;
        int floor = int.MinValue;
        int lowestIndex = 0;
        bool elementsRemain = true;
        
        while (elementsRemain)
        {
            elementsRemain = false;
            lowest = int.MaxValue;
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null && lists[i].val < lowest)
                {
                    elementsRemain = true;
                    lowestIndex = i;
                    lowest = lists[i].val;
                }
            }
            listNode = new ListNode(lists[lowestIndex].val, null);
            lists[lowestIndex] = lists[lowestIndex].next;
            if (mergedList == null) mergedList = listNode;
        }
       
        return mergedList;
    }
    
    
        
}