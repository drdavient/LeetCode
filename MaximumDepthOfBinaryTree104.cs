namespace LeetCode;


 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

public class MaximumDepthOfBinaryTree104
{
    
    

    public int MaxDepthRecursive(TreeNode root)
    {
        return MaxDepth(root, 0);
    }

    private int MaxDepth(TreeNode root, int depth)
    {
        if (root == null) return depth;
        depth++;
        int left = MaxDepth(root.left, depth);
        int right = MaxDepth(root.right, depth);
        return left > right ? left : right;
    }

   
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        
        Queue<TreeNode> nodes = new Queue<TreeNode>();
        int depth = 0;
        nodes.Enqueue(root);
        nodes.Enqueue(null);

        while (nodes.Count > 0)
        {
            TreeNode current = nodes.Dequeue();

            if (current != null)
            {
                if (current.left != null) nodes.Enqueue(current.left);
                if (current.right != null)nodes.Enqueue(current.right);
            }
            
            if(current == null)
            {
                depth++;
                if (nodes.Count > 0)
                {
                    nodes.Enqueue(null);
                }
            }
            
            
        }

        return depth;
    }
}