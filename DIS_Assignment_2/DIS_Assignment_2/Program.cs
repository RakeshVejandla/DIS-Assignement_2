using System;
using System.Text;

class Program
{

    static void Main()
    {
        Console.WriteLine("Question 1:");
        int[] nums1 = { 0, 1, 3, 50, 75 };
        int upper = 99, lower = 0;
        IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
        string result = ConvertIListToNestedList(missingRanges);
        Console.WriteLine(result);
        Console.WriteLine();

        Console.WriteLine("Question 2");
        string parenthesis = "()[]{}";
        bool isValidParentheses = IsValid(parenthesis);
        Console.WriteLine(isValidParentheses);
        Console.WriteLine();

        Console.WriteLine("Question 3");
        int[] prices_array = { 7, 1, 5, 3, 6, 4 };
        int max_profit = MaxProfit(prices_array);
        Console.WriteLine(max_profit);
        Console.WriteLine();

        Console.WriteLine("Question 4");
        string s1 = "69";
        bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
        Console.WriteLine(IsStrobogrammaticNumber);
        Console.WriteLine();

        Console.WriteLine("Question 5");
        int[] numbers = { 1, 2, 3, 1, 1, 3 };
        int noOfPairs = NumIdenticalPairs(numbers);
        Console.WriteLine(noOfPairs);
        Console.WriteLine();

        Console.WriteLine("Question 6");
        int[] maximum_numbers = { 3, 2, 1 };
        int third_maximum_number = ThirdMax(maximum_numbers);
        Console.WriteLine(third_maximum_number);
        Console.WriteLine();

        Console.WriteLine("Question 7:");
        string currentState = "++++";
        IList<string> combinations = GeneratePossibleNextMoves(currentState);
        string combinationsString = ConvertIListToArray(combinations);
        Console.WriteLine(combinationsString);
        Console.WriteLine();

        Console.WriteLine("Question 8:");
        string longString = "leetcodeisacommunityforcoders";
        string longStringAfterVowels = RemoveVowels(longString);
        Console.WriteLine(longStringAfterVowels);
        Console.WriteLine();
    }

    public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
    {
        try
        {
            IList<IList<int>> output = new List<IList<int>>();

            // Handle the case of missing ranges before the first element
            if (lower < nums[0])
            {
                output.Add(MakeRange(lower, nums[0] - 1));
            }

            // Handle the case of missing ranges between elements of nums
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] > 1)
                {
                    output.Add(MakeRange(nums[i - 1] + 1, nums[i] - 1));
                }
            }

            // Handle the case of missing ranges after the last element
            if (upper > nums[nums.Length - 1])
            {
                output.Add(MakeRange(nums[nums.Length - 1] + 1, upper));
            }
            return output;
        }
        catch (Exception)
        {
            throw;
        }

        static IList<int> MakeRange(int start, int end)
        {
            return new List<int> { start, end };

        }

    }

    public static bool IsValid(string s)
    {
        try
        {
            Dictionary<char, char> bracketsDictionary = new Dictionary<char, char>{
                    {'{',  '}'},
                    {'(',  ')'},
                    {'[',  ']'},
                };

            Stack<char> result = new Stack<char>();

            foreach (char bracket in s)
            {
                if (bracketsDictionary.ContainsKey(bracket))
                {
                    result.Push(bracket);
                }
                else
                {
                    if (result.Count == 0)
                    {
                        return false;
                    }
                    if (bracketsDictionary[result.Pop()] == bracket)
                    {
                        continue;
                    };
                    return false;
                }
            }
            return result.Count == 0;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public static int MaxProfit(int[] prices)
    {
        try
        {
            int max = 0, min = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                int max1 = prices[i] - min;
                if (max1 > max)
                {
                    max = max1;
                }
            }
            return max;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static bool IsStrobogrammatic(string s)
    {
        try
        {
            Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>{
                    { '0', '0' },
                    { '1', '1' },
                    { '8', '8' },
                    { '6', '9' },
                    { '9', '6' }
                };

            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                char leftChar = s[left];
                char rightChar = s[right];

                if (!strobogrammaticPairs.ContainsKey(leftChar) || strobogrammaticPairs[leftChar] != rightChar)
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static int NumIdenticalPairs(int[] nums)
    {
        try
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();
            int goodPairs = 0;

            foreach (int num in nums)
            {
                if (numCount.ContainsKey(num))
                {
                    // If the number is already in the dictionary, it can form additional good pairs.
                    goodPairs += numCount[num];
                    numCount[num]++;
                }
                else
                {
                    numCount[num] = 1;
                }
            }

            return goodPairs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static int ThirdMax(int[] nums)
    {
        try
        {
            int firstMax = int.MinValue;
            int secondMax = int.MinValue;
            int thirdMax = int.MinValue;

            foreach (int num in nums)
            {
                if (num > firstMax)
                {
                    thirdMax = secondMax;
                    secondMax = firstMax;
                    firstMax = num;
                }
                else if (num < firstMax && num > secondMax)
                {
                    thirdMax = secondMax;
                    secondMax = num;
                }
                else if (num < secondMax && num > thirdMax)
                {
                    thirdMax = num;
                }
            }

            if (thirdMax != int.MinValue)
            {
                return thirdMax;
            }
            else
            {
                return firstMax;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static IList<string> GeneratePossibleNextMoves(string currentState)
    {
        try
        {
            List<string> nextMoves = new List<string>();

            for (int i = 0; i < currentState.Length - 1; i++)
            {
                if (currentState[i] == '+' && currentState[i + 1] == '+')
                {
                    string nextString = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);
                    nextMoves.Add(nextString);
                }
            }
            return nextMoves;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public static string RemoveVowels(string s)
    {
        string vowels = "AEIOUaeiou";

        string output = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.IndexOf(s[i]) == -1)
            {
                output += s[i];
            }
        }
        return output;
    }


    static string ConvertIListToNestedList(IList<IList<int>> input)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("["); // Add the opening square bracket for the outer list

        for (int i = 0; i < input.Count; i++)
        {
            IList<int> innerList = input[i];
            sb.Append("[" + string.Join(",", innerList) + "]");

            // Add a comma unless it's the last inner list
            if (i < input.Count - 1)
            {
                sb.Append(",");
            }
        }

        sb.Append("]"); // Add the closing square bracket for the outer list

        return sb.ToString();
    }

    static string ConvertIListToArray(IList<string> input)
    {
        // Create an array to hold the strings in input
        string[] strArray = new string[input.Count];

        for (int i = 0; i < input.Count; i++)
        {
            strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
        }

        // Join the strings in strArray with commas and enclose them in square brackets
        string result = "[" + string.Join(",", strArray) + "]";

        return result;
    }
}




