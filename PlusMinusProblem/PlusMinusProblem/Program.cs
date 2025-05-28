class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        decimal positive = 0;
        decimal negative = 0;
        decimal zeroed = 0;

        foreach (int val in arr)
        {
            if (val > 0)
                positive++;
            else if (val < 0)
                negative++;
            else
                zeroed++;
        }
        Console.WriteLine(positive / arr.Count);
        Console.WriteLine(negative / arr.Count);
        Console.WriteLine(zeroed / arr.Count);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
