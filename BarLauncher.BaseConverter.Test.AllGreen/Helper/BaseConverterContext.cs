using AllGreen.Lib.Core;
using AllGreen.Lib.Core.DomainModel.Script;
using AllGreen.Lib.Core.DomainModel.ScriptResult;
using AllGreen.Lib.DomainModel;
using AllGreen.Lib.DomainModel.ScriptResult;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.EasyHelper;

namespace BarLauncher.BaseConverter.Test.AllGreen.Helper
{
    public class BaseConverterContext : IContext<BaseConverterContext>
    {
        public ITestScript<BaseConverterContext> TestScript { get; set; }
        public ITestScriptResult<BaseConverterContext> TestScriptResult { get; set; }

        public ApplicationStarter ApplicationStarter { get; set; }
        public void OnTestStart()
        {
            ApplicationStarter = new ApplicationStarter();
            ApplicationStarter.Init(TestScript.Name);
        }

        public void OnTestStop()
        {
            var testScriptResult = TestScriptResult as TestScriptResult<BaseConverterContext>;
            var path = Path.Combine(ApplicationStarter.TestPath, "{0}.agout".FormatWith(testScriptResult.TestScript.Name));
            using (var writer = new StreamWriter(path, false, new UTF8Encoding(false)))
            {
                writer.Write(testScriptResult.GetPipedName(options: PipedNameOptions.Canonical));
            }
        }
    }
}
