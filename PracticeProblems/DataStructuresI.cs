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



        //TODO: Fix the output so it"s readable
        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                var arr = DoWork(input.mat, input.r, input.c).ToString();
                result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList())); //Not working properly, either write code to print the contents of a jagged array, or use breakpoints and locals to see output
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

    #region PascalsTriangle

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/pascals-triangle
    /// </summary>
    public class PascalsTriangle {

        List<int> inputs;


        public PascalsTriangle() {
            inputs = new List<int>();
            inputs.Add(5);
            inputs.Add(1);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private IList<IList<int>> DoWork(int numRows) {
            IList<IList<int>> result = new List<IList<int>>() { new List<int>() { 1 } };

            for (int i = 2; i <= numRows; i++) {
                var row = new List<int>();
                row.Add(1);
                    for(int j = 1; j < i-1; j++) {
                        row.Add(result[i-2][j-1] + result[i-2][j]);
                    }
                row.Add(1);
                result.Add(row);
            }

            return result;
        }
    }
    #endregion

    #region ValidSudoku

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/valid-sudoku
    /// </summary>
    public class ValidSudoku {

        List<char[][]> inputs;

        public ValidSudoku() {
            inputs = new List<char[][]>();
            char[] list01 = new char[9] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
            char[] list02 = new char[9] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            char[] list03 = new char[9] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            char[] list04 = new char[9] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            char[] list05 = new char[9] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            char[] list06 = new char[9] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            char[] list07 = new char[9] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            char[] list08 = new char[9] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            char[] list09 = new char[9] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
            inputs.Add(new char[][] { list01, list02, list03, list04, list05, list06, list07, list08, list09 });

            char[] list11 = new char[9] { '8', '3', '.', '.', '7', '.', '.', '.', '.' };
            char[] list12 = new char[9] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            char[] list13 = new char[9] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            char[] list14 = new char[9] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            char[] list15 = new char[9] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            char[] list16 = new char[9] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            char[] list17 = new char[9] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            char[] list18 = new char[9] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            char[] list19 = new char[9] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
            inputs.Add(new char[][] { list11, list12, list13, list14, list15, list16, list17, list18, list19 });

        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(char[][] input) {
            var board = input; bool isValid = true;

            bool containsDup(List<char> nums) {
                var dupes = nums.GroupBy(x => x).Where(x => x.Count() > 1);
                bool distinct = dupes.Count() < 1 ? false : true;
                return distinct;
            }


            //for each array in the jagged array, check for non-period duplicates
            board.ToList().ForEach(a => { if (containsDup(a.ToList().FindAll(x => x != '.'))) isValid = false; });

            //for each position 0-8 for all 9 jagged arrays, check for non-period duplicates
            List<List<char>> invList = new List<List<char>>();
            for( int i = 0; i < 9; i++) {
                invList.Add(new List<char>() { 
                    board[0][i],
                    board[1][i],
                    board[2][i],
                    board[3][i],
                    board[4][i],
                    board[5][i],
                    board[6][i],
                    board[7][i],
                    board[8][i],
                });
            }
            invList.ForEach(a => { if (containsDup(a.ToList().FindAll(x => x != '.'))) isValid = false; });

            //find a way to split the arrays into 3x3 squares then check each for duplicates
            List<List<char>> squaresList = new List<List<char>>();
            for(int i = 0; i < 9; i += 3) {
                for(int j = 0; j < 9; j += 3) {
                    squaresList.Add(new List<char>() {
                    board[i][j],
                    board[i+1][j],
                    board[i+2][j],
                    board[i][j+1],
                    board[i+1][j+1],
                    board[i+2][j+1],
                    board[i][j+2],
                    board[i+1][j+2],
                    board[i+2][j+2],
                });
                }
            }
            squaresList.ForEach(a => { if (containsDup(a.ToList().FindAll(x => x != '.'))) isValid = false; });


            //If no duplicates are found in any of the three above scenarios, return true. Otherwise return false
            return isValid;
        }
        private bool containsDup(List<char> nums) {
            var dupes = nums.GroupBy(x => x).Where(x => x.Count() > 1);
            bool distinct = dupes.Count() < 1 ? false : true;
            return distinct;
        }

    }
    #endregion

    #region SearchA2DMatrix

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/search-a-2d-matrix
    /// </summary>
    public class SearchA2DMatrix {

        List<Inputs> inputs;

        private class Inputs {
            public int[][] Matrix { get; set; }
            public int Target { get; set; }
        }

        public SearchA2DMatrix() {
            inputs = new List<Inputs>();
            var input = new Inputs();
            int[] list01 = new int[4] { 1, 3, 5, 7 };
            int[] list02 = new int[4] { 10, 11, 16, 20 };
            int[] list03 = new int[4] { 23, 30, 34, 60 };
            input.Matrix = new int[][] { list01, list02, list03};
            input.Target = 3;
            inputs.Add(input);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            var matrix = input.Matrix;var target = input.Target;

            var index = matrix.SelectMany(x => x).ToList().BinarySearch(target);
            return index < 0 ? false : true;
        }
    }
    #endregion

    #region FirstUniqueCharacterInAString

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/first-unique-character-in-a-string
    /// </summary>
    public class FirstUniqueCharacterInAString {

        List<string> inputs;

        public FirstUniqueCharacterInAString() {
            inputs = new List<string>();
            inputs.Add("leetcode");
            inputs.Add("loveleetcode");
            inputs.Add("aabb");
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(string s) {
            var nodupe = s.GroupBy(x => x).Where(x => x.Count() == 1).ToList();
            if (nodupe.Count < 1) return -1;
            var index = s.IndexOf(Convert.ToChar(nodupe[0].Key));
            return index;
        }
    }
    #endregion

    #region RansomNote

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class RansomNote {

        List<Inputs> inputs;

        private class Inputs {
            public string ransomNote { get; set; }
            public string magazine { get; set; }
        }

        public RansomNote() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() { ransomNote = "a", magazine = "b" });
            inputs.Add(new Inputs() { ransomNote = "aa", magazine = "ab" });
            inputs.Add(new Inputs() { ransomNote = "aa", magazine = "aab" });
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(Inputs input) {
            string ransomNote = input.ransomNote; string magazine = input.magazine;
            var ransomGroupings = ransomNote.GroupBy(x => x).ToList();
            var magazineGroupings = magazine.GroupBy(x => x).ToList();
            foreach(var ranChar in ransomGroupings) {
                var magChar = magazineGroupings.FirstOrDefault(x => x.Key == ranChar.Key);
                if (magChar is null || ranChar.Count() > magChar.Count()) return false;
            }
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

    #region BinaryTreePreorderTraversal

    /// <summary>
    /// https://leetcode.com/problems/binary-tree-preorder-traversal
    /// </summary>
    public class BinaryTreePreorderTraversal {

        List<TreeNode> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public BinaryTreePreorderTraversal() {
            inputs = new List<TreeNode>();
            inputs.Add( new TreeNode(1) );
            inputs[0].right = new TreeNode(2);
            inputs[0].right.left = new TreeNode(3);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                var arr = DoWork(input).ToList();
                result.Add(string.Join(", ", arr.Select(x => x.ToString()).ToList()));
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private IList<int> DoWork(TreeNode input) {
            var result = new List<int>();

            if (input is null) return result;

            void recurse(TreeNode node) {
                if (node is null) return;
                result.Add(node.val);
                recurse(node.left);
                recurse(node.right);
            }

            recurse(input);

            return result;
        }
    }
    #endregion

    #region MaximumDepthOfBinaryTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class MaximumDepthOfBinaryTree {

        List<TreeNode> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public MaximumDepthOfBinaryTree() {
            inputs = new List<TreeNode>();

            inputs.Add(new TreeNode(3));
            inputs[0].right = new TreeNode(20);
            inputs[0].left = new TreeNode(9);
            inputs[0].right.left = new TreeNode(15);
            inputs[0].right.right = new TreeNode(7);

            inputs.Add(new TreeNode(1));
            inputs[1].right = new TreeNode(2);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(TreeNode input) {
            if (input is null) return 0;
            return Math.Max(DoWork(input.left), DoWork(input.right)) + 1;
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

    #region InsertIntoABinarySearchTree

    /// <summary>
    /// https://leetcode.com/problems/insert-into-a-binary-search-tree
    /// </summary>
    public class InsertIntoABinarySearchTreee {

        List<Inputs> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Inputs {
            public TreeNode tree { get; set; }
            public int val { get; set; }
        }

        public InsertIntoABinarySearchTreee() {
            inputs = new List<Inputs>();

            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    4,
                    new TreeNode(
                        2,
                        new TreeNode(1),
                        new TreeNode(3)
                        ),
                    new TreeNode(7)
                ),
                val = 5
            });
            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    40,
                    new TreeNode(
                        20,
                        new TreeNode(10),
                        new TreeNode(30)
                        ),
                    new TreeNode(
                        60,
                        new TreeNode(50),
                        new TreeNode(70)
                        )
                ),
                val = 25
            });

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

    #region SearchInABinarySearchTree

    /// <summary>
    /// https://leetcode.com/problems/search-in-a-binary-search-tree
    /// </summary>
    public class SearchInABinarySearchTree {

        List<Inputs> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Inputs {
            public TreeNode tree { get; set; }
            public int val { get; set; }
        }

        public SearchInABinarySearchTree() {
            inputs = new List<Inputs>();

            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    4,
                    new TreeNode(
                        2,
                        new TreeNode(1),
                        new TreeNode(3)
                        ),
                    new TreeNode(7)
                ),
                val = 2
            });
            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    4,
                    new TreeNode(
                        2,
                        new TreeNode(1),
                        new TreeNode(3)
                        ),
                    new TreeNode(7)
                ),
                val = 5
            });
                
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private TreeNode DoWork(Inputs input) {
            TreeNode root = input.tree;
            int val = input.val;
            TreeNode returnNode = null;

            void recurse(TreeNode node) {
                if (node is null) return;
                if (node.val == val) returnNode = node;
                if(node.val > val) recurse(node.left);
                if (node.val < val) recurse(node.right);
            }
            recurse(root);

            return returnNode;
        }
    }
    #endregion

    #region InvertBinaryTree

    /// <summary>
    /// https://leetcode.com/problems/invert-binary-tree
    /// </summary>
    public class InvertBinaryTree {

        List<Inputs> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Inputs {
            public TreeNode tree { get; set; }
            //public int val { get; set; }
        }

        public InvertBinaryTree() {
            inputs = new List<Inputs>();

            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    4,
                    new TreeNode(
                        2,
                        new TreeNode(1),
                        new TreeNode(3)
                        ),
                    new TreeNode(7)
                ),
                //val = 5
            });
            inputs.Add(new Inputs() {
                tree = new TreeNode(
                    40,
                    new TreeNode(
                        20,
                        new TreeNode(10),
                        new TreeNode(30)
                        ),
                    new TreeNode(
                        60,
                        new TreeNode(50),
                        new TreeNode(70)
                        )
                ),
                //val = 25
            });

        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private TreeNode DoWork(Inputs input) {
            TreeNode root = input.tree;
            if (root is null) return null;

            void recurse(TreeNode node) {
                if (node is null) return;

                var tmp = node.right;
                node.right = node.left;
                node.left = tmp;

                recurse(node.left);
                recurse(node.right);
            }
            recurse(root);

            return root;
        }
    }
    #endregion

    #region ValidateBinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/template_problem
    /// </summary>
    public class ValidateBinarySearchTree {

        List<TreeNode> inputs;

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Inputs {
            public TreeNode tree { get; set; }
            //public int val { get; set; }
        }

        public ValidateBinarySearchTree() {
            inputs = new List<TreeNode>();

            inputs.Add(new TreeNode(5));
            inputs[0].right = new TreeNode(4);
            inputs[0].left = new TreeNode(1);
            inputs[0].right.left = new TreeNode(3);
            inputs[0].right.right = new TreeNode(6);

            inputs.Add(new TreeNode(2));
            inputs[1].right = new TreeNode(3);
            inputs[1].left = new TreeNode(1);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private bool DoWork(TreeNode root) {
            bool isValid = true;
            long max = long.MinValue;

            void recurse(TreeNode node) {
                if (node is null) return;
                recurse(node.left);
                if (node.val <= max) isValid = false;
                max = node.val;
                recurse(node.right);
            }

            recurse(root);
            return isValid;
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

    #region LowestCommonAncestorOfABinarySearchTree

    /// <summary>
    /// Template Class for a LeetCode problem. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// Put URL to problem in below summary line:
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
    /// </summary>
    public class LowestCommonAncestorOfABinarySearchTree {

        List<Input> inputs;

        public class Input {
            public TreeNode node;
            public int p;
            public int q;

            public Input (TreeNode Node, int P, int Q) {
                node = Node;
                p = P;
                q = Q;
            }
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public LowestCommonAncestorOfABinarySearchTree() {
            inputs = new List<Input>();

            inputs.Add(new Input(new TreeNode(3), 5, 1));
            inputs[0].node.left = new TreeNode(5);
            inputs[0].node.right = new TreeNode(1);
            inputs[0].node.left.left = new TreeNode(6);
            inputs[0].node.left.right = new TreeNode(2);
            inputs[0].node.right.left = new TreeNode(0);
            inputs[0].node.right.right = new TreeNode(8);
            inputs[0].node.left.right.left = new TreeNode(7);
            inputs[0].node.left.right.right = new TreeNode(4);

            inputs.Add(new Input(new TreeNode(2), 1, 37));
            inputs[1].node.left = new TreeNode(7);
            inputs[1].node.right = new TreeNode(1);
            inputs[1].node.right.left = new TreeNode(9);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(Input input) {
            var root = input.node; var p = input.p; var q = input.q;

            TreeNode recurse(TreeNode node, int p, int q) {
                if (node.val == p || node.val == q || node is null) return node;

                TreeNode l = node.left is null ? null : recurse(node.left, p, q);
                TreeNode r = node.right is null ? null : recurse(node.right, p, q);

                return l != null && r != null ? node : l != null ? l : r;
            }

            var value = recurse(root, p, q).val;
            return value;
        }
    }
    #endregion

}