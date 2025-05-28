class Result
{
    public static void miniMaxSum(List<int> arr)
    {
        long totalSum = arr.Sum(x => (long)x);
        long min = totalSum - arr.Max();
        long max = totalSum - arr.Min();

        Console.WriteLine(string.Format("{0} {1}", min, max));
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
