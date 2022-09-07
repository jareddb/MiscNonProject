using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler {

    #region P1
    /// <summary>
    /// Multiples of 3 or 5  : Calculate the sum of all numbers underneath an integer that are multiples of 3 or 5
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// https://projecteuler.net/problem=1
    /// </summary>
    public class P1 {

        List<int> inputs;

        public P1() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(1000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private int DoWork(int limit) {
            int sum = 0;
            for (int i = 0; i < limit; i++) {
                if (i % 3 == 0 || i % 5 == 0) {
                    sum += i;
                }
            }
            return sum;
        }

    }
    #endregion

    #region P2
    /// <summary>
    /// Even Fibonacci numbers
    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// https://projecteuler.net/problem=2
    /// </summary>
    public class P2 {

        List<int> inputs;

        public P2() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(4000000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private int DoWork(int limit) {
            int sum = 2; int prev2 = 1; int prev1 = 2; int curr = 3; int tempCurr = 0;
            if (limit == 2) return 2;
            if (limit <= curr) return 0;
            while (curr <= limit) {
                if (curr % 2 == 0) sum += curr;
                tempCurr = curr;
                curr = curr + prev1;
                prev2 = prev1;
                prev1 = tempCurr;
            }
            return sum;
        }

    }
    #endregion

    #region P3
    /// <summary>
    /// Largest Prime Factor
    /// What is the largest prime factor of the number 600851475143 ?
    /// https://projecteuler.net/problem=3
    /// </summary>
    public class P3 {

        List<long> inputs;

        public P3() {
            inputs = new List<long>();
            inputs.Add(13195);
            inputs.Add(600851475143);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private long DoWork(long target) {
            long largestPrime = 0;
            for (long i = 1;  i < target; i++) {
                if (target % i == 0) {
                    bool isPrime = true;
                    for (long j = 2; j < i; j++) {
                        if (i % j == 0) {
                            isPrime = false;
                        }
                    }
                    if (isPrime) largestPrime = i;
                }
            }
            return largestPrime;

        }

    }
    #endregion

    #region P4
    /// <summary>
    /// Largest Palindrome Product
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// https://projecteuler.net/problem=4
    /// </summary>
    public class P4 {

        List<int> inputs;

        public P4() {
            inputs = new List<int>();
            inputs.Add(99);
            inputs.Add(999);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private int DoWork(int maxFactor) {
            List<int> candidates = new List<int>();
            for(int i = maxFactor; i > 1; i--) {
                for(int j = maxFactor; j > 1; j--) {
                    int product = i * j;
                    bool isPalindrome = IsPalindrome(product);
                    if (isPalindrome) {
                        candidates.Add(product);
                    }
                }
            }
            return candidates.Max();
        }

        private static bool IsPalindrome(int num) {
            int tempValue = num;
            int reverse = 0;
            while (tempValue > 0) {
                reverse = reverse * 10 + tempValue % 10;
                tempValue = tempValue / 10;
            }
            return reverse == num;
        }
    }
    #endregion

    #region P5
    /// <summary>
    /// Smallest Multiple
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// https://projecteuler.net/problem=5
    /// </summary>
    public class P5 {

        List<int> inputs;

        public P5() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(20);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int maxRange) {
            for(int i = maxRange; i < int.MaxValue; i++) {
                bool isDivisible = true;
                for (int j = 2; j <= maxRange; j++) {
                    if(!(i % j == 0)) {
                        isDivisible = false;
                        continue;
                    }
                }
                if (isDivisible) return i;
            }
            return 0;
        }

    }
    #endregion


}
