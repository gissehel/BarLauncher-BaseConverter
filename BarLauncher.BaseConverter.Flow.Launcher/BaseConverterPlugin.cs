using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Lib.Service;
using BarLauncher.EasyHelper;
using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Service;
using BarLauncher.EasyHelper.Flow.Launcher;
using BarLauncher.EasyHelper.Flow.Launcher.Service;

namespace BarLauncher.BaseConverter.Flow.Launcher
{
    public class BaseConverterPlugin : FlowLauncherPlugin
    {
        public override IBarLauncherResultFinder PrepareContext()
        {
            var systemInformations = new SystemInformations();
            var baseConvertService = new BaseConvertService();
            var systemService = new FlowLauncherSystemService("BarLauncher-BaseConverter", BarLauncherContextService as BarLauncherContextService);
            var baseResultFinder = new BaseResultFinder(BarLauncherContextService, baseConvertService, systemInformations, systemService);

            return baseResultFinder;
        }
    }
}
