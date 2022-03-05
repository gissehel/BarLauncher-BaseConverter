using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarLauncher.BaseConverter.Lib.Service
{
    public interface ISystemInformations
    {
        string ApplicationName { get; }

        // The version of the current assembly
        string Version { get; }

        string HomepageUrl { get; }
    }
}
