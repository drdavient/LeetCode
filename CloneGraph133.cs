//https://leetcode.com/problems/clone-graph/
//
//namespace CloneGraph133;




// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{

    public Dictionary<int, Node> clonedNodes = new Dictionary<int, Node>();
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;
        Node clonedNeighbour = null;
        Node nodeClone = new Node(node.val);
        clonedNodes.Add(nodeClone.val, nodeClone);
        if (node.neighbors == null) return nodeClone;
        foreach (var neighbour in node.neighbors)
        {
            if (!clonedNodes.TryGetValue(neighbour.val, out clonedNeighbour))
            {
                nodeClone.neighbors.Add(CloneGraph(neighbour));
                
            }
            else
            {
                nodeClone.neighbors.Add(clonedNeighbour);
            }
           
            
        }

        return nodeClone;
    }
}