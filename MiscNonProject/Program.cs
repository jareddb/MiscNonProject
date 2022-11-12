using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
//using DataStructuresI;

namespace MiscNonProjectConsole{

    class Program {

        static void Main(string[] args) {

            var host = CreateDefaultBuilder().Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var executor = provider.GetRequiredService<Executor>();

            executor.ExecuteCommand(args);

            host.Run();
        }

        static IHostBuilder CreateDefaultBuilder() {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app => {
                    var settings = app.AddJsonFile("appsettings.json").Build();
                })
                .ConfigureLogging((hostingContext, loggingBuilder) => {
                    //loggingBuilder.ClearProviders();
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("logging"));
                    loggingBuilder.AddSimpleConsole(options => {
                        options.IncludeScopes = true;
                    });
                    loggingBuilder.AddEventLog();
                    loggingBuilder.AddDebug();
                })
                .ConfigureServices(services => {
                    services.AddLogging();
                    services.AddTransient<Executor>();
                });
            
        }

    }

    internal class Executor {

        IConfiguration _config;
        ILogger<Executor> _logger;

        public Executor(IConfiguration config, ILogger<Executor> logger) {
            _config = config;
            _logger = logger;
        }

        public void ExecuteCommand(string[] args) {
            Console.WriteLine("");

            if (args.Length == 0){
                //>>>>>SET VARIABLES HERE IF DEBUGGING IN VS STUDIO OR CALLING WITH 0 ARGS<<<<<
                args = new string[3];
                args[0] = "PracticeProblems";
                args[1] = "DataStructuresI";
                args[2] = "ValidSudoku";
            }
            else if(args.Length != 3) {
                _logger.LogError($"You must pass in three parameters, the assembly name, the namespace name and the class name");
                throw new ArgumentException();
            }

            var assName = args[0];
            var namesp = args[1];
            var className = args[2];

            _logger.LogInformation($"Running Tests For:{Environment.NewLine}{Environment.NewLine}" +
                $"Assembly:  {assName}{Environment.NewLine}" +
                $"Namespace: {namesp}{Environment.NewLine}" +
                $"Class:     {className}{Environment.NewLine}");

            //Assembly.GetAssembly("ContainsDuplicate");

            Assembly assembly = Assembly.Load(assName);
            Type type = assembly.GetType($"{namesp}.{className}");
            if(type != null) {
                object scenarioObj = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod("RunScenarios");
                method.Invoke(scenarioObj, new object[] {_config, _logger});
            } else { _logger.LogError($"ERROR: Invalid Namespace or Class Name"); throw new ArgumentException(); }

            _logger.LogInformation($"Selected scenario successfully run{Environment.NewLine}");

            System.Threading.Thread.Sleep(500);
            System.Environment.Exit(0);
        }

    }


}