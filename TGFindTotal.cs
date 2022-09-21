

public class TGFindTotal
{
    public static int find_total( int[] my_numbers ) {
        int sum = 0;
        for (int i =0; i < my_numbers.Length; i ++)
        {
           
            if (my_numbers[i] == 8)
            {
                sum += 5;
            }
            else
            {
                sum +=  my_numbers[i] % 2 == 0? 1 : 3;
            }
        }
        return sum;
    }

}