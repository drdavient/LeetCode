// int[] input1 = { 6, 1, 3, 2, 4, 7 };
// Input: prices = [7,1,5,3,6,4]
// Output: 5
// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
//     Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

// int[] input2 = {7,6,4,3,1};

// int[] input1 = {0,1,3,7,6,4,3,1};
// int[] input1 = {6,1,3,2,4,7};
// Input: prices = [7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transactions are done and the max profit = 0.


// 1 <= prices.length <= 10^5
// 0 <= prices[i] <= 10^4




// Console.WriteLine($"Input 1 Profit is {new BestTimeToBuyAndSellStock(input1).CalculateProfitBruteForce()}");
// Console.WriteLine($"Input 1 Profit is {new BestTimeToBuyAndSellStock(input1).CalculateProfitSinglePass()}");
// Console.WriteLine($"Input 2 Profit is {new ProfitCalculator(input2).CalculateProfit()}");
// Console.WriteLine($"Input 3 Profit is {new ProfitCalculator(input3).CalculateProfit()}");
//Console.WriteLine($"Input 4 Profit is {new ProfitCalculator(input4).CalculateProfit()}");

namespace LeetCode;

public class BestTimeToBuyAndSellStock
{
    private readonly int[] _prices;

    public BestTimeToBuyAndSellStock(int[] prices)
    {
        _prices = prices;
    }

    public int CalculateProfitSinglePass()
    {
        int maxProfit=0;
        int minPrice = int.MaxValue;
        
        for (int i = 0; i < _prices.Length; i++)
        {
            if (_prices[i] < minPrice)
            {
                minPrice = _prices[i];
            }
            else if (_prices[i] - minPrice > maxProfit)
            {
                maxProfit = _prices[i] - minPrice;
            } 
        }

        return maxProfit;
    }
    
    public int CalculateProfitBruteForce()
    {
        int highIndex = 0;
        var profitWindows = new List<(int lowIndex, int highIndex)>();
        while (highIndex < _prices.Length - 1)
        {
            var lowIndex = profitWindows.Count == 0 ? 0 : profitWindows.Last().highIndex + 1 ;
            profitWindows.Add(GetNextLowHIghPair(lowIndex));
            highIndex = profitWindows.Last().highIndex;
        }   
    
        if (profitWindows.Count == 0) return 0;
        {
            var profit = 0;
            foreach (var profitWindow in profitWindows)
            {
                if(GetProfit(profitWindow) > profit)
                {
                    profit = GetProfit(profitWindow);
                }
            }

            return profit;
        }
    }

    private (int lowIndex, int highIndex) GetNextLowHIghPair(int lowIndex)
    {
        int highIndex = GetHighestIndexToRight(lowIndex);
        lowIndex = GetLowestIndexBefore(lowIndex, highIndex);
        return (lowIndex, highIndex);
    }

    int GetHighestIndexToRight(int index)
    {
        for (int i = index; i < _prices.Length; i++)
        {
            if (_prices[i] >= _prices[index])
            {
                index = i;
            }
        }

        return index;
    }

    int GetProfit((int indexLow, int indexHigh) profitWindow)
    {
        return GetProfit(profitWindow.indexLow, profitWindow.indexHigh);
    }
    
    int GetProfit(int indexLow, int indexHigh)
    {
        if (indexHigh < 0 || indexHigh >= _prices.Length)
        {
            Console.WriteLine($"{nameof(indexHigh)} ({indexHigh}) outside range"); 
            return 0;
        }

        if (indexLow < 0 || indexLow >= _prices.Length)
        {
            Console.WriteLine($"{nameof(indexHigh)} ({indexHigh}) outside range"); return 0;
        }
        
        return _prices[indexHigh] - _prices[indexLow] > 0 ? _prices[indexHigh] - _prices[indexLow] :0;
    }

    int GetLowestIndexBefore (int currentIndex,  int limit)
    {   
        int minIndex = currentIndex;
    
        for (int i = currentIndex; i<_prices.Length && i < limit; i++)
        {
            if (_prices[i] <= _prices[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;
    }
}