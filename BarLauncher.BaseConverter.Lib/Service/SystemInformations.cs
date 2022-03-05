using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BarLauncher.BaseConverter.Lib.Service
{
    public class SystemInformations : ISystemInformations
    {
        public string ApplicationName => "BarLauncher-BaseConverter";

        public string Version => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

        public string HomepageUrl => "https://github.com/gissehel/BarLauncher-BaseConverter";
    }
}
