using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler {
    //Project Euler's general format has a sample input (with an answer), then the question input. As such, most classes here have two inputs, the first to calibrate, and the second outputting the requested answer

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

    #region P6
    /// <summary>
    /// Sum Square Difference
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// https://projecteuler.net/problem=6
    /// </summary>
    public class P6 {

        List<int> inputs;

        public P6() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(100);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private double DoWork(int maxRange) {
            double sumSquares = 0;
            for (int i = 1; i <= maxRange; i++) {
                sumSquares += Math.Pow((double)i, 2);
            }
            double squareOfSum = Math.Pow((double)(maxRange * (maxRange + 1)) / 2, 2);
            return squareOfSum - sumSquares;
        }
        
    }
    #endregion

    #region P7
    /// <summary>
    /// 10001st prime
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13. What is the 10,001st prime number?
    /// https://projecteuler.net/problem=7
    /// </summary>
    public class P7 {

        List<int> inputs;

        public P7() {
            inputs = new List<int>();
            inputs.Add(6);
            inputs.Add(10001);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private double DoWork(int primeIndex) {
            int numOfPrimes = 0; long i = 1;
            while (numOfPrimes < primeIndex) {
                i++;
                if (IsPrime(i)) numOfPrimes++;
            }
            return i;
        }

        private static bool IsPrime(long candidate) {
            if ((candidate & 1) == 0) {
                if (candidate == 2) {
                    return true;
                } else {
                    return false;
                }
            }
            for (int i = 3; (i * i) <= candidate; i += 2) {
                if ((candidate % i) == 0) {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
    #endregion

    #region P8
    /// <summary>
    /// Largest product in a series
    /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
    /// https://projecteuler.net/problem=8
    /// </summary>
    public class P8 {

        List<int> inputs;
        string series;

        public P8() {
            inputs = new List<int>();
            inputs.Add(4);
            inputs.Add(13);
            series = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private double DoWork(int maxRange) {
            long maxProduct = 0;
            for(int i = 0; i < series.Length - maxRange; i++) {
                long substringProduct = GetStringProduct(series.Substring(i, maxRange));
                if(substringProduct > maxProduct) maxProduct = substringProduct;
            }
            return maxProduct;
        }
        

        private static long GetStringProduct(string numSeries) {
            long product = 1;
            for (int i = 0; i < numSeries.Length; i++) {
                product = product * (long) Int32.Parse(numSeries[i].ToString());
            }
            return product;
        }

    }
    #endregion

    #region P9
    /// <summary>
    /// Special Pythagorean Triplet
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
    /// https://projecteuler.net/problem=9
    /// </summary>
    public class P9 {

        List<int> inputs;

        public P9() {
            inputs = new List<int>();
            inputs.Add(12);
            inputs.Add(1000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int sum) {
            for(int a = 0; a < sum/3; a++) {
                for(int b = 0; b < sum/2; b++) {
                    int c = sum - b - a;
                    if(a*a + b*b == c * c) {
                        return a * b * c;
                    }
                }
            }
            return 0;
        }

    }
    #endregion

    #region P10
    /// <summary>
    /// Summation of Primes
    /// Find the sum of all the primes below two million.
    /// https://projecteuler.net/problem=10
    /// </summary>
    public class P10 {

        List<int> inputs;

        public P10() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(2000000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int limit) {
            long sum = 0;
            for(long i = 0; i <limit; i++) {
                if (IsPrime(i)) sum += i;
            }
            return sum;
        }

        private static bool IsPrime(long candidate) {
            if ((candidate & 1) == 0) {
                if (candidate == 2) {
                    return true;
                } else {
                    return false;
                }
            }
            for (int i = 3; (i * i) <= candidate; i += 2) {
                if ((candidate % i) == 0) {
                    return false;
                }
            }
            return candidate != 1;
        }

    }
    #endregion

    #region P11
    /// <summary>
    /// Largest Product in a Grid
    /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
    /// https://projecteuler.net/problem=11
    /// </summary>
    public class P11 {

        List<int> inputs;

        int[][] arr ;

        public P11() {
            inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(4);

            arr = new int[][] {
                new int[]{ 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                new int[] {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                new int[] {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                new int[] {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                new int[] {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                new int[] {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                new int[] {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                new int[] {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                new int[] {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                new int[] {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                new int[] {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                new int[] {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                new int[] {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                new int[] {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                new int[] {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                new int[] {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                new int[] {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                new int[] {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                new int[] {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                new int[] {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int numStringLen) {

            int height = arr.Count();
            int width = arr[0].Count();
            Point[] directions = new[] { new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(-1, 1) };

            var comboArr =
                (from y in Enumerable.Range(0, height)
                 from x in Enumerable.Range(0, width)
                 from direction in directions
                 let points = Enumerable.Range(0, numStringLen).Select(i => new Point(x + i * direction.X, y + i * direction.Y)).ToArray()
                 where points.All(i => i.X >= 0 && i.X < width && i.Y < height)
                 let combo = points.Select(i => arr[i.Y][i.X]).ToArray()
                 select combo).ToArray();

            long maxProd = comboArr.Max((x) => x.Aggregate(1, (a, b) => a * b));

            return maxProd;

        }

    }
    #endregion

    #region P12
    /// <summary>
    /// Highly divisible triangular number
    /// What is the value of the first triangle number to have over five hundred divisors?
    /// https://projecteuler.net/problem=12
    /// </summary>
    public class P12 {

        List<int> inputs;

        public P12() {
            inputs = new List<int>();
            inputs.Add(5);
            inputs.Add(500);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private int DoWork(int numOfDivisors) {
            int triIndex = 1; int numOfFactors = 0; int triNum;
            do {
                var triArray = Enumerable.Range(1, triIndex).ToArray();
                triNum = triArray.Aggregate(0, (a, b) => a + b);
                numOfFactors = GetFactors(triNum);
                triIndex++;
            } while (numOfFactors < numOfDivisors);
            return triNum;
        }

        private int GetFactors(int number) {
            int nod = 0; 
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 1; i <= sqrt; i++) {
                if (number % i == 0) {
                    nod += 2;
                }
            }
            if (sqrt * sqrt == number) {
                nod--;
            }
            return nod;
        }

        //static IEnumerable<int> GetFactors(int n) {
        //    return from a in Enumerable.Range(1, n)
        //           where n % a == 0
        //           select a;
        //}

    }
    #endregion

    #region P13
    /// <summary>
    /// Large Sum
    /// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
    /// https://projecteuler.net/problem=13
    /// </summary>
    public class P13 {

        List<int> inputs;
        List<BigInteger> arr;

        public P13() {
            inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(10);

            arr = new List<BigInteger>();
            arr.Add(BigInteger.Parse("37107287533902102798797998220837590246510135740250"));
            arr.Add(BigInteger.Parse("46376937677490009712648124896970078050417018260538"));
            arr.Add(BigInteger.Parse("74324986199524741059474233309513058123726617309629"));
            arr.Add(BigInteger.Parse("91942213363574161572522430563301811072406154908250"));
            arr.Add(BigInteger.Parse("23067588207539346171171980310421047513778063246676"));
            arr.Add(BigInteger.Parse("89261670696623633820136378418383684178734361726757"));
            arr.Add(BigInteger.Parse("28112879812849979408065481931592621691275889832738"));
            arr.Add(BigInteger.Parse("44274228917432520321923589422876796487670272189318"));
            arr.Add(BigInteger.Parse("47451445736001306439091167216856844588711603153276"));
            arr.Add(BigInteger.Parse("70386486105843025439939619828917593665686757934951"));
            arr.Add(BigInteger.Parse("62176457141856560629502157223196586755079324193331"));
            arr.Add(BigInteger.Parse("64906352462741904929101432445813822663347944758178"));
            arr.Add(BigInteger.Parse("92575867718337217661963751590579239728245598838407"));
            arr.Add(BigInteger.Parse("58203565325359399008402633568948830189458628227828"));
            arr.Add(BigInteger.Parse("80181199384826282014278194139940567587151170094390"));
            arr.Add(BigInteger.Parse("35398664372827112653829987240784473053190104293586"));
            arr.Add(BigInteger.Parse("86515506006295864861532075273371959191420517255829"));
            arr.Add(BigInteger.Parse("71693888707715466499115593487603532921714970056938"));
            arr.Add(BigInteger.Parse("54370070576826684624621495650076471787294438377604"));
            arr.Add(BigInteger.Parse("53282654108756828443191190634694037855217779295145"));
            arr.Add(BigInteger.Parse("36123272525000296071075082563815656710885258350721"));
            arr.Add(BigInteger.Parse("45876576172410976447339110607218265236877223636045"));
            arr.Add(BigInteger.Parse("17423706905851860660448207621209813287860733969412"));
            arr.Add(BigInteger.Parse("81142660418086830619328460811191061556940512689692"));
            arr.Add(BigInteger.Parse("51934325451728388641918047049293215058642563049483"));
            arr.Add(BigInteger.Parse("62467221648435076201727918039944693004732956340691"));
            arr.Add(BigInteger.Parse("15732444386908125794514089057706229429197107928209"));
            arr.Add(BigInteger.Parse("55037687525678773091862540744969844508330393682126"));
            arr.Add(BigInteger.Parse("18336384825330154686196124348767681297534375946515"));
            arr.Add(BigInteger.Parse("80386287592878490201521685554828717201219257766954"));
            arr.Add(BigInteger.Parse("78182833757993103614740356856449095527097864797581"));
            arr.Add(BigInteger.Parse("16726320100436897842553539920931837441497806860984"));
            arr.Add(BigInteger.Parse("48403098129077791799088218795327364475675590848030"));
            arr.Add(BigInteger.Parse("87086987551392711854517078544161852424320693150332"));
            arr.Add(BigInteger.Parse("59959406895756536782107074926966537676326235447210"));
            arr.Add(BigInteger.Parse("69793950679652694742597709739166693763042633987085"));
            arr.Add(BigInteger.Parse("41052684708299085211399427365734116182760315001271"));
            arr.Add(BigInteger.Parse("65378607361501080857009149939512557028198746004375"));
            arr.Add(BigInteger.Parse("35829035317434717326932123578154982629742552737307"));
            arr.Add(BigInteger.Parse("94953759765105305946966067683156574377167401875275"));
            arr.Add(BigInteger.Parse("88902802571733229619176668713819931811048770190271"));
            arr.Add(BigInteger.Parse("25267680276078003013678680992525463401061632866526"));
            arr.Add(BigInteger.Parse("36270218540497705585629946580636237993140746255962"));
            arr.Add(BigInteger.Parse("24074486908231174977792365466257246923322810917141"));
            arr.Add(BigInteger.Parse("91430288197103288597806669760892938638285025333403"));
            arr.Add(BigInteger.Parse("34413065578016127815921815005561868836468420090470"));
            arr.Add(BigInteger.Parse("23053081172816430487623791969842487255036638784583"));
            arr.Add(BigInteger.Parse("11487696932154902810424020138335124462181441773470"));
            arr.Add(BigInteger.Parse("63783299490636259666498587618221225225512486764533"));
            arr.Add(BigInteger.Parse("67720186971698544312419572409913959008952310058822"));
            arr.Add(BigInteger.Parse("95548255300263520781532296796249481641953868218774"));
            arr.Add(BigInteger.Parse("76085327132285723110424803456124867697064507995236"));
            arr.Add(BigInteger.Parse("37774242535411291684276865538926205024910326572967"));
            arr.Add(BigInteger.Parse("23701913275725675285653248258265463092207058596522"));
            arr.Add(BigInteger.Parse("29798860272258331913126375147341994889534765745501"));
            arr.Add(BigInteger.Parse("18495701454879288984856827726077713721403798879715"));
            arr.Add(BigInteger.Parse("38298203783031473527721580348144513491373226651381"));
            arr.Add(BigInteger.Parse("34829543829199918180278916522431027392251122869539"));
            arr.Add(BigInteger.Parse("40957953066405232632538044100059654939159879593635"));
            arr.Add(BigInteger.Parse("29746152185502371307642255121183693803580388584903"));
            arr.Add(BigInteger.Parse("41698116222072977186158236678424689157993532961922"));
            arr.Add(BigInteger.Parse("62467957194401269043877107275048102390895523597457"));
            arr.Add(BigInteger.Parse("23189706772547915061505504953922979530901129967519"));
            arr.Add(BigInteger.Parse("86188088225875314529584099251203829009407770775672"));
            arr.Add(BigInteger.Parse("11306739708304724483816533873502340845647058077308"));
            arr.Add(BigInteger.Parse("82959174767140363198008187129011875491310547126581"));
            arr.Add(BigInteger.Parse("97623331044818386269515456334926366572897563400500"));
            arr.Add(BigInteger.Parse("42846280183517070527831839425882145521227251250327"));
            arr.Add(BigInteger.Parse("55121603546981200581762165212827652751691296897789"));
            arr.Add(BigInteger.Parse("32238195734329339946437501907836945765883352399886"));
            arr.Add(BigInteger.Parse("75506164965184775180738168837861091527357929701337"));
            arr.Add(BigInteger.Parse("62177842752192623401942399639168044983993173312731"));
            arr.Add(BigInteger.Parse("32924185707147349566916674687634660915035914677504"));
            arr.Add(BigInteger.Parse("99518671430235219628894890102423325116913619626622"));
            arr.Add(BigInteger.Parse("73267460800591547471830798392868535206946944540724"));
            arr.Add(BigInteger.Parse("76841822524674417161514036427982273348055556214818"));
            arr.Add(BigInteger.Parse("97142617910342598647204516893989422179826088076852"));
            arr.Add(BigInteger.Parse("87783646182799346313767754307809363333018982642090"));
            arr.Add(BigInteger.Parse("10848802521674670883215120185883543223812876952786"));
            arr.Add(BigInteger.Parse("71329612474782464538636993009049310363619763878039"));
            arr.Add(BigInteger.Parse("62184073572399794223406235393808339651327408011116"));
            arr.Add(BigInteger.Parse("66627891981488087797941876876144230030984490851411"));
            arr.Add(BigInteger.Parse("60661826293682836764744779239180335110989069790714"));
            arr.Add(BigInteger.Parse("85786944089552990653640447425576083659976645795096"));
            arr.Add(BigInteger.Parse("66024396409905389607120198219976047599490197230297"));
            arr.Add(BigInteger.Parse("64913982680032973156037120041377903785566085089252"));
            arr.Add(BigInteger.Parse("16730939319872750275468906903707539413042652315011"));
            arr.Add(BigInteger.Parse("94809377245048795150954100921645863754710598436791"));
            arr.Add(BigInteger.Parse("78639167021187492431995700641917969777599028300699"));
            arr.Add(BigInteger.Parse("15368713711936614952811305876380278410754449733078"));
            arr.Add(BigInteger.Parse("40789923115535562561142322423255033685442488917353"));
            arr.Add(BigInteger.Parse("44889911501440648020369068063960672322193204149535"));
            arr.Add(BigInteger.Parse("41503128880339536053299340368006977710650566631954"));
            arr.Add(BigInteger.Parse("81234880673210146739058568557934581403627822703280"));
            arr.Add(BigInteger.Parse("82616570773948327592232845941706525094512325230608"));
            arr.Add(BigInteger.Parse("22918802058777319719839450180888072429661980811197"));
            arr.Add(BigInteger.Parse("77158542502016545090413245809786882778948721859617"));
            arr.Add(BigInteger.Parse("72107838435069186155435662884062257473692284509516"));
            arr.Add(BigInteger.Parse("20849603980134001723930671666823555245252804609722"));
            arr.Add(BigInteger.Parse("53503534226472524250874054075591789781264330331690"));

        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }


        private string DoWork(int numPlaces) {
            BigInteger result = new BigInteger(0);
            foreach (var bInt in arr) {
                result += bInt;
            }
            return result.ToString().Substring(0,numPlaces);
        }

    }
    #endregion

    #region P14
    /// <summary>
    /// Longest Collatz sequence
    /// Which starting number, under one million, produces the longest chain?
    /// https://projecteuler.net/problem=14
    /// </summary>
    public class P14 {

        List<int> inputs;

        public P14() {
            inputs = new List<int>();
            inputs.Add(13);
            inputs.Add(1000000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int limit) {
            int maxSeqStartNum = 0; int maxSeqLength = 0;
            for (int i = 2; i < limit; i++) {
                var retSeqSize = IterateCollatzSequence(i);
                if(retSeqSize.Count > maxSeqLength) {
                    Console.WriteLine($"New max number found: {i} causes a Collatz Sequence of length {retSeqSize.Count} ");
                    maxSeqStartNum = i;
                    maxSeqLength = retSeqSize.Count;
                }
            }
            return maxSeqStartNum;
        }

        private static List<long> IterateCollatzSequence(int startNum) {
            List<long> sequenceArr = new List<long>();
            sequenceArr.Add(startNum);
            long currNum = startNum;
            do {
                if(currNum % 2 == 0) {
                    currNum = currNum / 2;
                } else {
                    currNum = (currNum * 3) + 1;
                }
                sequenceArr.Add(currNum);
                if (currNum < 1) Console.WriteLine("break");
            } while (currNum != 1);
            return sequenceArr;
        }

    }
    #endregion

    #region P15
    /// <summary>
    /// Lattice paths
    /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner. How many such routes are there through a 20×20 grid?
    /// https://projecteuler.net/problem=15
    /// </summary>
    public class P15 {

        List<int> inputs;

        public P15() {
            inputs = new List<int>();
            inputs.Add(2);
            inputs.Add(20);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int gridsize) {

            long[,] gridArr = new long[gridsize+1, gridsize+1];
            for(int i = 0; i <= gridsize; i++) {
                gridArr[i, gridsize] = 1;
                gridArr[gridsize, i] = 1;
            }
            for(int i = gridsize-1; i>= 0; i--) {
                for(int j = gridsize-1; j>=0; j--) {
                    gridArr[i,j] = gridArr[i,j+1] + gridArr[i+1,j];
                }
            }
            return gridArr[0, 0];
        }

    }
    #endregion

    #region P16
    /// <summary>
    /// Power digit sum
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26. What is the sum of the digits of the number 2^1000?
    /// https://projecteuler.net/problem=16
    /// </summary>
    public class P16 {

        List<int> inputs;

        public P16() {
            inputs = new List<int>();
            inputs.Add(15);
            inputs.Add(1000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int power) {
            BigInteger expo = (BigInteger)Math.Pow(2, power);
            string expoString = expo.ToString();
            int expoSum = 0;
            for(int i = 0; i < expoString.Length; i++) {
                expoSum += Int32.Parse(expoString[i].ToString());
            }
            return expoSum;
        }

    }
    #endregion

    #region P17
    /// <summary>
    /// Number letter counts
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    /// https://projecteuler.net/problem=17
    /// </summary>
    public class P17 {

        List<int> inputs;

        public P17() {
            inputs = new List<int>();
            inputs.Add(5);
            inputs.Add(99);
            inputs.Add(1000);
            inputs.Add(9999);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        //Only currently handles numbers to 9999, would need more code to go over
        private int DoWork(int limit) {
            int resultSum = 0;
            for (int num = 1; num <= limit; num++) {
                string result = string.Empty;
                var thou = (int)Math.Abs((num / 1000) % 100);
                if (thou > 0) result += SpellTheDigit(thou) + "thousand";
                var hun = (int)Math.Abs((num / 100) % 10);
                if (hun > 0) result += SpellTheDigit(hun) + "hundred";
                var teen = num % 100;
                if (teen != 0 && (thou > 0 || hun > 0)) result += "and";
                result += SpellTheTeen(teen);
                var single = num % 10;
                if (single > 0 && !(teen > 9 && teen < 20)) result += SpellTheDigit(single);
                //Console.WriteLine(result + result.Length);
                resultSum += result.Length;
            }
            return resultSum;
        }

        private string SpellTheDigit(int digit) {
            return  digit switch {
                0 => "zero",
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                7 => "seven",
                8 => "eight",
                9 => "nine",
                _ => ""
            };
        }

        private string SpellTheTeen(int teen) {
            return teen switch {
                10 => "ten",
                11 => "eleven",
                12 => "twelve",
                13 => "thirteen",
                14 => "fourteen",
                15 => "fifteen",
                16 => "sixteen",
                17 => "seventeen",
                18 => "eighteen",
                19 => "nineteen",
                >= 20 and < 30 => "twenty",
                >= 30 and < 40 => "thirty",
                >= 40 and < 50 => "forty",
                >= 50 and < 60 => "fifty",
                >= 60 and < 70 => "sixty",
                >= 70 and < 80 => "seventy",
                >= 80 and < 90 => "eighty",
                >= 90 and < 100 => "ninety",
                _ => ""
            };
        }

    }
    #endregion

    #region P18
    /// <summary>
    /// Maximum path sum I
    /// Find the maximum total from top to bottom of the triangle
    /// https://projecteuler.net/problem=18
    /// </summary>
    public class P18 {

        //List<int> inputs;
        int[][,] inputs;

        public P18() {
            inputs = new int[][,] {
                new int[4,4] {
                    {3,0,0,0},
                    {7,4,0,0},
                    {2,4,6,0},
                    {8,5,9,3}
                },
                new int[15,15] {
                    {75,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {95,64,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {17,47,82,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {18,35,87,10,0,0,0,0,0,0,0,0,0,0,0 },
                    {20,04,82,47,65,0,0,0,0,0,0,0,0,0,0 },
                    {19,01,23,75,03,34,0,0,0,0,0,0,0,0,0 },
                    {88,02,77,73,07,63,67,0,0,0,0,0,0,0,0 },
                    {99,65,04,28,06,16,70,92,0,0,0,0,0,0,0 },
                    {41,41,26,56,83,40,80,70,33,0,0,0,0,0,0 },
                    {41,48,72,33,47,32,37,16,94,29,0,0,0,0,0 },
                    {53,71,44,65,25,43,91,52,97,51,14,0,0,0,0 },
                    {70,11,33,28,77,73,17,78,39,68,17,57,0,0,0 },
                    {91,71,52,38,17,14,91,43,58,50,27,29,48,0,0 },
                    {63,66,04,68,89,53,67,30,73,16,69,87,40,31,0 },
                    {04,62,98,27,23,09,70,98,73,93,38,53,60,04,23 }
                }
            };
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private long DoWork(int[,] tree) {
            int x = 0; int y = 0;
            
            //Need to iterate through all items on the next to bottom row
            //For each number on the next to bottom row, find the largest sum that connects to it below and add that to itself
            //repeat on the row above, until row 0 is reached
            //Return the value of row 0

            for(int i = tree.GetLength(0) - 2; i >= 0; i--) {
                for(int j = 0; j < tree.GetLength(1)-1; j++) {
                    int y2 = 0;
                    int y1 = tree[i+1, j];
                    try { y2 = tree[i+1, j+1]; } catch { y1 = 0; }
                    tree[i, j] = tree[i, j] + Math.Max(y1, y2);
                }
            }


            return tree[0,0];
        }

    }
    #endregion

    #region P19
    /// <summary>
    /// Counting Sundays
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// https://projecteuler.net/problem=19
    /// </summary>
    public class P19 {

        List<int> inputs;

        public P19() {
            inputs = new List<int>();
            inputs.Add(2000);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int maxYear) {
            int sundays = 0;

            for (int year = 1901; year <= maxYear; year++) {
                for (int month = 1; month <= 12; month++) {
                    if ((new DateTime(year, month, 1)).DayOfWeek == DayOfWeek.Sunday) {
                        sundays++;
                    }
                }
            }
            return sundays;
        }
    }
    #endregion


    #region P20
    /// <summary>
    /// Factorial Digit Sum
    /// Find the sum of the digits in the number 100!
    /// https://projecteuler.net/problem=20
    /// </summary>
    public class P20 {

        List<int> inputs;

        public P20() {
            inputs = new List<int>();
            inputs.Add(10);
            inputs.Add(100);
        }

        public void RunScenarios(IConfiguration config, ILogger logger) {
            List<string> result = new List<string>();
            foreach (var input in inputs) {
                result.Add(DoWork(input).ToString());
            }
            logger.LogInformation($"Test Results:{Environment.NewLine}{string.Join($"{Environment.NewLine}", result)}{Environment.NewLine}");
        }

        private int DoWork(int factInt) {
            BigInteger factorial = factInt;

            for(int i = factInt - 1; i > 0; i--) {
                factorial *= i;
            }
            string factString = factorial.ToString();

            int sum = 0;
            for (int i = 0; i < factString.Length; i++) {
                sum += int.Parse(factString[i].ToString());
            }
            return sum;
        }
    }
    #endregion

}
