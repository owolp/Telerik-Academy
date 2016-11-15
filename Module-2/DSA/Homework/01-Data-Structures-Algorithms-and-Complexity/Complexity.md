# Data Structures, Algorithms and Complexity Homework

1. **What is the expected running time of the following C# code?**

Answer: The expected running time is `n2`.

Explanation: The first loop ends on n and for each n there is a while loop from 0 to n-1.
Because -1 is a constant the answer is n*n or `n2`

```csharp
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else
                end--;
    }
    return count;
}
```

2. **What is the expected running time of the following C# code?**

Answer: `n*m`

Explanation: The first loop ends on n. In the worst case scenario every matrix element might have even number.
So the if enters the second for loop which ends on m.

```csharp
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```

3. **(*) What is the expected running time of the following C# code?**

Answer: `n*m`

Explanation: The first for loop ends on m. The recursion will be called n-1. We eliminate the 1 as it is a constant.
The result is `n*m`

```cs
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++)
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1))
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```