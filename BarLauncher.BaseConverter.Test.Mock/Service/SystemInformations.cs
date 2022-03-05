using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Lib.Service;

namespace BarLauncher.BaseConverter.Test.Mock.Service
{
    public class SystemInformationsMock : ISystemInformations
    {
        public string ApplicationName { get; set; }

        public string Version { get; set; }

        public string HomepageUrl { get; set; }

    }
}
