using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class ScriptTest : TestBase
    {
        [Test, TestCaseSource("TestCases")]
        public void DivideTest(CommandSet commandSet)
        {
            object currentFlow = Start;

            foreach (var command in commandSet.Commands)
            {

                var method = currentFlow.GetType().GetMethod(command.Name);

                try
                {
                    var parameters = command.Parameters.ToArray();

                    if(parameters.Length == 0)
                    {
                        parameters = null;
                    }

                    currentFlow = method.Invoke(currentFlow, parameters);
                }
                catch (Exception ex)
                {

                    throw new Exception(string.Format("Error while executing command {0}", command.Name), ex);
                }
                
            }
        }

        public IEnumerable TestCases
        {
            get
            {
                return (from fileName in Directory.GetFiles(Configuration.ScriptsPath)
                        let contents = File.ReadAllText(fileName)
                        select new object[] {GetCommand(fileName, contents)})
                        .Cast<object>()
                        .ToList();
            }
        }

        private static CommandSet GetCommand(string fileName, string commands)
        {
            var set = new CommandSet { Name = fileName };

            var lines = commands.Split('\n');

            lines = lines.Select(l => l.Replace("\r", "")).ToArray();

            foreach (var line in lines)
            {
                var commandStrings = line.Split(' ');
               
                var name = commandStrings[0];
                var parameters = commandStrings.Skip(1);
           
                var command = new Command() { Name = name };
                command.Parameters.AddRange(parameters.Cast<object>());

                set.Commands.Add(command);
            }

            return set;
        }

        public class CommandSet
        {
            public string Name { get; set; }
            readonly IList<Command> commands = new List<Command>();

            public IList<Command> Commands
            {
                get { return commands; }
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Command
        {
            readonly List<object> parameters = new List<object>();

            public string Name { get; set; }

            public List<object> Parameters
            {
                get { return parameters; }
            }
        }
    }
}
