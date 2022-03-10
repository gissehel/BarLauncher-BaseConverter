using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Test.Mock.Service;
using BarLauncher.BaseConverter.Lib.Service;
using BarLauncher.EasyHelper;
using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Test.Mock.Service;

namespace BarLauncher.BaseConverter.Test.AllGreen.Helper
{
    public class ApplicationStarter
    {
        private string TestName { get; set; }

        private string testPath = null;
        public string TestPath => testPath ?? (testPath = GetApplicationDataPath());

        public BarLauncherContextServiceMock BarLauncherContextService { get; set; }

        public QueryServiceMock QueryService { get; set; }

        public IBarLauncherResultFinder BaseResultFinder { get; set; }

        public SystemServiceMock SystemService { get; set; }
        public SystemInformationsMock SystemInformations { get; set; }

        public void Init(string testName)
        {
            var queryService = new QueryServiceMock();
            var barLauncherContextService = new BarLauncherContextServiceMock(queryService);
            var systemService = new SystemServiceMock();
            var baseConvertServer = new BaseConvertService();
            var systemInformations = new SystemInformationsMock();

            var baseResultFinder = new BaseResultFinder(barLauncherContextService, baseConvertServer, systemInformations, systemService);

            BarLauncherContextService = barLauncherContextService;
            QueryService = queryService;
            BaseResultFinder = baseResultFinder;
            SystemService = systemService;
            SystemInformations = systemInformations;

            BarLauncherContextService.AddQueryFetcher("base", BaseResultFinder);
        }


        public void Start()
        {
            BaseResultFinder.Init();
        }

        private static string GetThisAssemblyDirectory()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var thisAssemblyCodeBase = assembly.CodeBase;
            var thisAssemblyDirectory = Path.GetDirectoryName(new Uri(thisAssemblyCodeBase).LocalPath);

            return thisAssemblyDirectory;
        }

        private string GetApplicationDataPath()
        {
            var thisAssemblyDirectory = GetThisAssemblyDirectory();
            var path = Path.Combine(Path.Combine(thisAssemblyDirectory, "AllGreen"), "AG_{0:yyyyMMdd-HHmmss-fff}_{1}".FormatWith(DateTime.Now, TestName));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
