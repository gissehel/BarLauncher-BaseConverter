using AllGreen.Lib;
using AllGreen.Lib.Core.Engine.Service;
using AllGreen.Lib.DomainModel.Script;
using AllGreen.Lib.Engine.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;
using BarLauncher.EasyHelper;

namespace BarLauncher.BaseConverter.Test.AllGreen
{
    public class AllGreenTests
    {
        private static ITestRunnerService _testRunnerService = null;
        private static ITestRunnerService TestRunnerService => _testRunnerService ?? (_testRunnerService = new TestRunnerService());

        private static Dictionary<string, TestScript<BaseConverterContext>> GetTestScripts()
        {
            var testScripts = new Dictionary<string, TestScript<BaseConverterContext>>();
            var allRunnableTestScripts = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(TestBase<BaseConverterContext>)))
                .Select(t => (Activator.CreateInstance(t) as TestBase<BaseConverterContext>).GetTestScript())
                .Where(s => s != null)
                .Where(s => s.IsRunnable)
                ;

            foreach (var testScript in allRunnableTestScripts)
            {
                testScripts[testScript.Name] = testScript;
            }
            return testScripts;
        }

        private static Dictionary<string, TestScript<BaseConverterContext>> _testScripts = null;
        private static Dictionary<string, TestScript<BaseConverterContext>> TestScripts => _testScripts ?? (_testScripts = GetTestScripts());

        private static IEnumerable<string> GetTestScriptNames() => TestScripts.Keys.OrderBy(name => name);

        [TestCaseSource(nameof(GetTestScriptNames))]
        public void Run(string name)
        {
            if (TestScripts.ContainsKey(name))
            {
                RunTest(TestScripts[name]);
            }
            else
            {
                Assert.Fail("Don't know [{0}] as a test name !".FormatWith(name));
            }
        }

        private void RunTest(TestScript<BaseConverterContext> testScript)
        {
            var result = TestRunnerService.RunTest(testScript);

            Assert.IsNotNull(result, "The test returned a null result. Is the test runnable ?");
            Assert.IsTrue(result.Success, result.PipedName);
        }
    }
}