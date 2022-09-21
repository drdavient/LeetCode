namespace LeetCode
{
    public static  class SumOfTwoIntegers371
    {
        public static int SumOfTwoIntegers(int a, int b)
        {
            while (b !=0)
            {
                uint carry = (uint)(a & b);
                
                a = a ^ b;
                
                b = (int)(carry << 1);
            }
                
            return a;
        }   
        
    }
}