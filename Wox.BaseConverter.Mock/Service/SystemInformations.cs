using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.BaseConverter.Service;

namespace Wox.BaseConverter.Mock.Service
{
    public class SystemInformationsMock : ISystemInformations
    {
        public string Version { get; set; }

        public string HomepageUrl { get; set; }
    }
}
