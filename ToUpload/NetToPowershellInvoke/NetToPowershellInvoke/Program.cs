using System;
using System.Configuration;
using System.Management.Automation;

namespace NetToPowershellInvoke
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize PowerShell engine
                var shell = PowerShell.Create();

                string scriptToInvoke = ConfigurationManager.AppSettings["ScriptPath"].ToString();
                string pathToDotnetNewConfig = ConfigurationManager.AppSettings["PathToDotnetNewConfig"].ToString();
                string solutionName = ConfigurationManager.AppSettings["NewSolutionName"].ToString();
                string friendlyName = ConfigurationManager.AppSettings["NewFriendlyName"].ToString();
                string projectOutput = ConfigurationManager.AppSettings["NewProjectOutputPath"].ToString();
                string additionalParamsKey = ConfigurationManager.AppSettings["AddKey"].ToString();
                string additionalParamsVal = ConfigurationManager.AppSettings["AddValue"].ToString();

                // Add the script to the PowerShell object
                shell.Commands.AddScript(scriptToInvoke + " -PathToConfig " + pathToDotnetNewConfig + " -SolutionName " + solutionName + " -FriendlyName " + friendlyName + " -OutputPath " + projectOutput + " -AddKey " + "'" + additionalParamsKey + "'" + " -AddValue " + "'" + additionalParamsVal + "'");

                // Execute the script
                var results = shell.Invoke();
                if (results.Count > 0)
                {
                    Console.WriteLine("Successfully Created Project {0}", solutionName);
                }
                else
                {
                    Console.WriteLine("Error Occured while creating Solution");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error Occured");
            }
            Console.ReadLine();
        }
    }
}