using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews {


    #region Template
    /// <summary>
    /// Template Class for an interview question. Use the below formatting to create your solution, test it against a number of inputs and output results to the console. 
    /// </summary>
    public class Template {

        List<Inputs> inputs;
        private class Inputs {

        }

        public Template() {
            inputs = new List<Inputs>();
            inputs.Add(new Inputs() {  });
            inputs.Add(new Inputs() {  });
            inputs.Add(new Inputs() {  });
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
