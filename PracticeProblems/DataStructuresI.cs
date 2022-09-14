using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataStructuresI {

    #region Template

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class Template {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public Template() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3,3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    #region ContainsDuplicate

    /// <summary>
    /// For an inputted int array, returns a bool true if there are any duplicated integers in the list 
    /// https://leetcode.com/problems/contains-duplicate
    /// </summary>
    public class ContainsDuplicate {

        List<int[]> inputs;
        public ContainsDuplicate() {
            inputs = new List<int[]>();
            inputs.Add(new[] { 0,1,2,0 });
            inputs.Add(new[] { 1,2,3,4 });
            inputs.Add(new[] { -1, -1, 10, 10 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(int[] nums) {
            var dupes = nums.GroupBy(x => x).Where(x => x.Count() > 1);
            bool distinct = dupes.Count() < 1 ? false : true;
            return distinct;
        }
    }
    #endregion

    #region MaxSubArray

    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    /// https://leetcode.com/problems/maximum-subarray/
    /// </summary>
    public class MaxSubArray {

        List<int[]> inputs;

        public MaxSubArray() {
            inputs = new List<int[]>();
            inputs.Add(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            inputs.Add(new[] { 1 });
            inputs.Add(new[] { 5, 4, -1, 7, 8 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {

            List<string> result = new List<string>();

            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int[] nums) {
            int sum = 0;
            int bestSum = int.MinValue;
            for (int i = 0; i < nums.Length; i++) {
                sum += nums[i];
                bestSum = Math.Max(bestSum, sum);
                if (sum < 0) sum = 0;
            }
            return bestSum;
        }
    }
    #endregion

    #region TwoSum

    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public class TwoSum {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public TwoSum() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                var arr = DoWork(input.Nums, input.Target).ToList();
                result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList()));
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        public int[] DoWork(int[] nums, int target) {
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) {
                int complement = target - nums[i];
                if (numDict.ContainsKey(complement) && numDict[complement] != i)
                    return new int[] { numDict[complement], i };
                if (!numDict.ContainsKey(nums[i])) numDict.Add(nums[i], i);
            }
            return null;
        }
    }

    #endregion

    #region MergeSortedArray

    /// <summary>
    /// MergeSortedArray Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. Put URL to problem in below summary line:
    /// https://leetcode.com/problems/merge-sorted-array/
    /// </summary>

    //You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
    //Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    //The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

    //public class MergeSortedArray {

    //    List<Inputs> inputs;

    //    private class Inputs {
    //        public int[] Nums1 { get; set; }
    //        public int m { get; set; }
    //        public int[] Nums2 { get; set; }
    //        public int n { get; set; }
    //    }


    //    public MergeSortedArray() {
    //        inputs = new List<Inputs>();
    //        inputs.Add(new Inputs() { Nums1 = new[] { 1, 2, 3, 0, 0, 0 }, m = 9, Nums2 = new[] { 2, 5, 6 }, n = 3 });
    //        inputs.Add(new Inputs() { Nums1 = new[] { 1 }, m = 6, Nums2 = new int[0], n = 0 });
    //        inputs.Add(new Inputs() { Nums1 = new[] { 0 }, m = 6, Nums2 = new[] { 1 }, n = 1 });
    //    }

    //    public void RunScenarios(IConfiguration config, ILogger logger) {
    //        List<string> result = new List<string>();
    //        foreach (var input in inputs) {
    //            var arr = DoWork(input).ToList();
    //            result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList()));
    //        }
    //        logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
    //    }

    //    private int[] DoWork(Inputs input) {
    //        if (input.m == 0) {
    //            input.Nums2.CopyTo(input.Nums1, 0);
    //            return input.Nums1;
    //        } else if (input.n == 0) {
    //            return input.Nums1;
    //        }
    //        int currentElement = input.m + input.n - 1;
    //        int currentNums1 = input.m - 1;
    //        int currentNums2 = input.n - 1;
    //        while (currentNums2 >= 0) {
    //            if (currentNums1 >= 0 && input.Nums1[currentNums1] > input.Nums2[currentNums2]) {
    //                input.Nums1[currentElement--] = input.Nums1[currentNums1--];
    //            } else {
    //                input.Nums1[currentElement--] = input.Nums2[currentNums2--];
    //            }
    //        }
    //        return input.Nums1;
    //    }
    //}
    #endregion

    #region IntersectionOfTwoArraysII

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. Put URL to problem in below summary line:
    /// https://leetcode.com/problems/intersection-of-two-arrays-ii
    /// </summary>
    public class IntersectionOfTwoArraysII {

        List<Inputs> inputs;

        private class Inputs {
            public int[] Nums1 { get; set; }
            public int[] Nums2 { get; set; }
        }

        public IntersectionOfTwoArraysII() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums1 = new[] { 1, 2, 2, 1 }, Nums2 = new[] { 2, 2 } });
            inputs.Add(new Inputs() { Nums1 = new[] { 4, 9, 5 }, Nums2 = new[] { 9, 4, 9, 8, 4 } });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                var arr = DoWork(input).ToList();
                result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList()));
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int[] DoWork(Inputs input) {
            List<int> intList = new List<int>();
            Dictionary<int, int> intDict = new Dictionary<int, int>();
            foreach (int num in input.Nums1) {
                if (!intDict.ContainsKey(num)) {
                    intDict.Add(num, 1);
                } else {
                    intDict[num] += 1;
                }
            }
            foreach (int num in input.Nums2) {
                if (intDict.ContainsKey(num) && intDict[num] > 0) {
                    intDict[num] -= 1;
                    intList.Add(num);
                }
            }
            return intList.ToArray();
        }
    }
    #endregion

    #region BestTimeToBuyAndSellStock
    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. Put URL to problem in below summary line:
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock
    /// </summary>
    public class BestTimeToBuyAndSellStock {

        List<int[]> inputs;

        public BestTimeToBuyAndSellStock() {
            inputs = new List<int[]>();
            inputs.Add(new[] { 7, 1, 5, 3, 6, 4 });
            inputs.Add(new[] { 7, 6, 4, 3, 1 });

        }



        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int[] prices) {
            if (prices == null || prices.Length == 0)
                return 0;
            int[] res = new int[prices.Length];
            int diff = -prices[0];
            for (int i = 1; i < prices.Length; i++) {
                res[i] = Math.Max(res[i - 1], prices[i] + diff);
                diff = Math.Max(diff, -prices[i]);
            }
            return res[prices.Length - 1];
        }

    }

    #endregion

    //TODO: In Progress
    #region ReshapeTheMatrix
    /// <summary>
    /// You are given an m x n matrix mat and two integers r and c representing the number of rows and the number of columns of the wanted reshaped matrix.
    /// The reshaped matrix should be filled with all the elements of the original matrix in the same row-traversing order as they were.
    /// If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
    /// https://leetcode.com/problems/reshape-the-matrix
    /// </summary>
    public class ReshapeTheMatrix {

        List<Inputs> inputs;

        private class Inputs {
            public int[][] mat { get; set; } //the matrix to reshape
            public int r { get; set; } //Desired number of rows in new matrix
            public int c { get; set; } //Desired number of columns in new matrix
        }

        public ReshapeTheMatrix() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { mat = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }
            , r = 1, c = 4 });
            inputs.Add(new Inputs() { mat = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }
            , r = 2, c = 4 });

        }



        //TODO: Fix the output so it's readable
        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                var arr = DoWork(input.mat, input.r, input.c).ToString();
                result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList()));
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int[][] DoWork(int[][] mat, int r, int c) {
            
            if(mat.Length * mat[0].Length != r * c) {
                return mat;
            } else {
                int[][] newArr = new int[r][];
                for(int i = 0; i < r; i++) { 
                    newArr[i] = new int[c];
                }
                int iteration = 0;
                for(int i = 0; i < mat.Length; i++) {
                    for(int j = 0; j < mat[0].Length; j++) {
                        int k = (int)Math.Floor((double)(iteration / c));
                        int l = iteration % c;
                        newArr[k][l] = mat[i][j];
                        iteration++;
                    }
                }
                return newArr;
            }

        }

    }

    #endregion

    //TODO
    #region PascalsTriangle

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class PascalsTriangle {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public PascalsTriangle() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ValidSudoku

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ValidSudoku {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ValidSudoku() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region SearchA2DMatrix

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class SearchA2DMatrix {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public SearchA2DMatrix() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region FirstUniqueCharacterInAString

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class FirstUniqueCharacterInAString {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public FirstUniqueCharacterInAString() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region RansomNote

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class RansomNote {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public RansomNote() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ValidAnagram

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ValidAnagram {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ValidAnagram() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region LinkedListCycle

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class LinkedListCycle {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public LinkedListCycle() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region MergeTwoSortedLists

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class MergeTwoSortedLists {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public MergeTwoSortedLists() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region RemoveLinkedListElements

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class RemoveLinkedListElements {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public RemoveLinkedListElements() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ReverseLinkedList

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ReverseLinkedList {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ReverseLinkedList() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region RemoveDuplicatesFromSortedList

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class RemoveDuplicatesFromSortedList {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public RemoveDuplicatesFromSortedList() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ValidParenthesis

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ValidParenthesis {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ValidParenthesis() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ImplementQueueUsingStacks

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ImplementQueueUsingStacks {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ImplementQueueUsingStacks() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region BinaryTreePreorderTraversal

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class BinaryTreePreorderTraversal {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public BinaryTreePreorderTraversal() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region MaximumDepthOfBinaryTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class MaximumDepthOfBinaryTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public MaximumDepthOfBinaryTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region SymmetricTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class SymmetricTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public SymmetricTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region InvertBinaryTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class InvertBinaryTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public InvertBinaryTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region PathSum

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class PathSum {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public PathSum() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region SearchInABinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class SearchInABinarySearchTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public SearchInABinarySearchTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region InsertIntoABinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class InsertIntoABinarySearchTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public InsertIntoABinarySearchTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region ValidateBinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ValidateBinarySearchTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public ValidateBinarySearchTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region TwoSumIVInputIsABST

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class TwoSumIVInputIsABST {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public TwoSumIVInputIsABST() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

    //TODO
    #region LowestCommonAncestorOfABinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class LowestCommonAncestorOfABinarySearchTree {

        List<Inputs> inputs;

        private class Inputs {
            public int[]? Nums { get; set; }
            public int Target { get; set; }
        }

        public LowestCommonAncestorOfABinarySearchTree() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { Nums = new[] { 2, 7, 11, 15 }, Target = 9 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 2, 4 }, Target = 6 });
            inputs.Add(new Inputs() { Nums = new[] { 3, 3 }, Target = 6 });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            return true;
        }
    }
    #endregion

}