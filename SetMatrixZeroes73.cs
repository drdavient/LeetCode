namespace LeetCode;
/// <summary>
/// Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
//
// You must do it in place.
//
//  
//
//     Example 1:
//
//
// Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
// Output: [[1,0,1],[0,0,0],[1,0,1]]
// Example 2:
//
//
// Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
// Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
//  
//
// Constraints:
//
// m == matrix.length
// n == matrix[0].length
// 1 <= m, n <= 200
//     -231 <= matrix[i][j] <= 231 - 1
//  
//
// Follow up:
//
// A straightforward solution using O(mn) space is probably a bad idea.
//     A simple improvement uses O(m + n) space, but still not the best solution.
//     Could you devise a constant space solution?
/// </summary>
public class SetMatrixZeroes73
{
    public void SetZeroesNM(int[][] matrix) 
    {
        bool [][] zero = new bool[matrix.Length][];
        
        for(int i=0; i < matrix.Length;i++)
        {
            zero[i] = new bool[matrix[i].Length];
            for (int j = 0; j < matrix[i].Length; j++)
            {
                zero[i][j] = matrix[i][j] == 0;
            }
        }

        for (int i = 0; i < zero.Length; i++)
        {
            for (int j = 0; j < zero[i].Length; j++)
            {
                if(zero[i][j]) ZeroRowColumn(i,j, matrix);
            }
        }
    }
    
    public void SetZeroesRecursive(int[][] matrix) 
    {
        //rows
        CheckAllCells(0,0, matrix);
        Console.WriteLine("Hello");
    }

    void CheckAllCells(int row, int column, int[][]matrix)
    {
        bool zeroed = RowIsZero(row, matrix) || ColumnIsZero(column, matrix);

        int r=row;
        int c=column;
        if (column < matrix[row].Length-1) c ++;
        else if (row < matrix.Length - 1) 
        { 
            r++;
            c = 0;
        }

        if(row != r || column != c) CheckAllCells(r, c, matrix);
        
        matrix[row][column] = zeroed ? 0 : matrix[row][column];
    }
    // bool CheckRowCell( bool rowIsZero, bool columnIsZero, int row, int column, int[][] matrix)
    // {
    //     if (column < matrix[row].Length)
    //         rowIsZero = CheckRowCell(rowIsZero || matrix[row][column] == 0, row, column + 1, matrix);
    //     if (row < matrix.Length)
    //         
    // }

    public void SetZeroesOOne(int[][] matrix)
    {
        bool firstColIsZero = false;
        bool firstRowIsZero = false;
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                
                if (matrix[row][col] == 0)
                {
                    if (col == 0) firstColIsZero = true;
                    if (row == 0) firstRowIsZero = true;
                    
                    matrix[row][0] = 0;
                    matrix[0][col] = 0;
                }
            }
        }

        
        for (int row = 1; row < matrix.Length; row++)
        {
            for (int col = 1; col < matrix[row].Length; col++)
            {
                if (matrix[row][0] == 0 || matrix[0][col] == 0)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        if (firstRowIsZero)
        { 
            for (int col = 0; col < matrix[0].Length; col++)
            {
                matrix[0][col] = 0;
            }
            
        }
        if (firstColIsZero)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][0] = 0;
            }
        }
    }

    bool RowIsZero(int row, int[][] matrix)
    {
        for (int i = 0; i < matrix[row].Length; i++)
        {
            if (matrix[row][i] == 0) return true;
        }

        return false;
    }

    bool ColumnIsZero(int column, int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][column] == 0) return true;
        }

        return false;
    }
    
    public void ZeroRowColumn(int row, int column, int[][] matrix)
    {
        for (int i = 0; i < matrix[0].Length; i++)
        {
            matrix[row][i] = 0;
        }
        
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][column] = 0;
        }
    }
}
