using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wox.BaseConverter.Mock.Service;
using Wox.BaseConverter.Service;
using Wox.EasyHelper;
using Wox.EasyHelper.Core.Service;
using Wox.EasyHelper.Test.Mock.Service;

namespace Wox.BaseConverter.Test.AllGreen.Helper
{
    public class ApplicationStarter
    {
        private string TestName { get; set; }
        public string TestPath => GetApplicationDataPath();

        public WoxContextServiceMock WoxContextService { get; set; }

        public QueryServiceMock QueryService { get; set; }

        public IWoxResultFinder WoxBaseResultFinder { get; set; }

        public SystemServiceMock SystemService { get; set; }
        public SystemInformationsMock SystemInformations { get; set; }

        public void Init(string testName)
        {
            var queryService = new QueryServiceMock();
            var woxContextService = new WoxContextServiceMock(queryService);
            var systemService = new SystemServiceMock();
            var baseConvertServer = new BaseConvertService();
            var systemInformations = new SystemInformationsMock();

            var woxBaseResultFinder = new WoxBaseResultFinder(woxContextService, baseConvertServer, systemInformations, systemService);

            WoxContextService = woxContextService;
            QueryService = queryService;
            WoxBaseResultFinder = woxBaseResultFinder;
            SystemService = systemService;
            SystemInformations = systemInformations;

            WoxContextService.AddQueryFetcher("base", WoxBaseResultFinder);
        }


        public void Start()
        {
            WoxBaseResultFinder.Init();
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
