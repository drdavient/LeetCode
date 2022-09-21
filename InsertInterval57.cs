// https://leetcode.com/problems/insert-interval/
namespace LeetCode;

// You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
//
//     Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).
//
// Return intervals after the insertion.
//
//  
//
//     Example 1:
//
// Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
// Output: [[1,5],[6,9]]
// Example 2:
//
// Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
// Output: [[1,2],[3,10],[12,16]]
// Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
//  
//
// Constraints:
//
// 0 <= intervals.length <= 104
// intervals[i].length == 2
// 0 <= starti <= endi <= 105
// intervals is sorted by starti in ascending order.
//     newInterval.length == 2
// 0 <= start <= end <= 105
// [[1,3],[6,9]]
// [2,5]

public class InsertInterval57
{
    public int[][] Insert(int[][] intervals, int[] newInterval) 
    {
        for (int i = 0; i < intervals.Length; i++)
        {
            if (newInterval[0] > intervals[i][1]) continue; // newInterval starts after interval i ends -> we dont overlap
            // newInterval either intersects or precedes this interval
            if (newInterval[1] < intervals[i][0]) // newInterval ends before interval i begins
            {
                // insert newInterval before i
                return InsertAtIndex(intervals, newInterval, i);
            }
            
            // we intersect 
            
            // if (newInterval[1] > intervals[i][1]) // we consume the existing interval
            // {
            //     intervals[i] = newInterval;
            //     return intervals;
            // }
            //
            // Count number of intervals we collide with and merge them
            for (int j = i; j < intervals.Length; j++)
            {
                if (newInterval[1] > intervals[j][1] && j+1 < intervals.Length && newInterval[1] >= intervals[j+1][0])  continue; // we consume this one
                

                return MergeIntervals(intervals, newInterval, i, j);

            }
            
            
        }

        int[][] result = intervals == null ? new int[1][]:intervals;
        return InsertAtIndex(result, newInterval, result.Length);
    }

    private int[][] MergeIntervals(int[][] intervals, int[] newInterval, int i, int j)
    {
        int[] mergedInterval =
        {
            newInterval[0] < intervals[i][0] ? newInterval[0] : intervals[i][0],
            newInterval[1] > intervals[j][1] ? newInterval[1] : intervals[j][1]
        };
        int removing = j - i;
        int[][] newIntervals = new int[intervals.Length - removing][];
        for (int k = 0; k < newIntervals.Length; k++)
        {
            if (k < i)
                newIntervals[k] = intervals[k];
            if (k == i)
                newIntervals[k] = mergedInterval;
            if (k > i)
                newIntervals[k] = intervals[k+removing];
        }

        return newIntervals;

    }

    public int[][] InsertAtIndex(int[][] intervals, int[] newInterval, int index)
    {
        int[][] newIntervals = new int[intervals.Length + 1][];

        for (int i = 0, j = 0; j < newIntervals.Length; i++ , j++)
        {
            if (j == index)
            {
                newIntervals[i] = newInterval;
                i--;
            }
            else
            {
                newIntervals[j] = intervals[i];    
            }
        }

        return newIntervals;
    }
}