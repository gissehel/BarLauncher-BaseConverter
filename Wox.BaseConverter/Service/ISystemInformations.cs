using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.BaseConverter.Service
{
    public interface ISystemInformations
    {
        // The version of Wox.BaseConvert
        string Version { get; }

        string HomepageUrl { get; }
    }
}
