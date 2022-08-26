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
            public int[] Nums { get; set; }
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

}