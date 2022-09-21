namespace LeetCode;

public class ClimbingStairs70
{
    // N Steps to the top
    // Take 1 or 2 steps

    public static int ClimbStairs(int n)
    {
        Node node = new Node();
        return node.CountStepsCaching(0,n);
     //   return node.Count;

    }

  
} 
public class Node
{
    private  int _count = 0;

    public int Count
    {
        get => _count;
        private set => _count = value;
    }

    public  void CountStepsBruteForce(int steps, int stepsRemaing)
    {
        stepsRemaing -= steps;
        if (stepsRemaing > 0 )  CountStepsBruteForce(1, stepsRemaing);
        if (stepsRemaing > 1)  CountStepsBruteForce(2, stepsRemaing);


        if (stepsRemaing == 0)
        {
            Count++;
        }
    }

    public Dictionary<int, int> StepCounts;

    public Node()
    {
        StepCounts = new Dictionary<int, int>();
    }

    public int CountStepsCaching(int steps, int stepsRemaing)
    {
        int stepsAfterThis = stepsRemaing - steps;
        if (stepsAfterThis == 0) return 1;
        
        if (StepCounts.TryGetValue(stepsAfterThis, out int result)) return result;
        
      
        
        
        int leaves1=0, leaves2=0;
        if (stepsRemaing > 0)
        {
            leaves1 = CountStepsCaching(1, stepsAfterThis);
        }

        if (stepsRemaing > 1)
        {
            leaves2 = CountStepsCaching(2, stepsAfterThis);
        }
        StepCounts.Add(stepsAfterThis, leaves1+leaves2);
        return leaves1+leaves2;

    }


}