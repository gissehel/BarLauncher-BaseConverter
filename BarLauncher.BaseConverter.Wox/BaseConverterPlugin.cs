using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Lib.Service;
using BarLauncher.EasyHelper;
using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Service;
using BarLauncher.EasyHelper.Wox;

namespace BarLauncher.BaseConverter.Wox
{
    public class BaseConverterPlugin : WoxPlugin
    {
        public override IBarLauncherResultFinder PrepareContext()
        {
            var systemInformations = new SystemInformations();
            var baseConvertService = new BaseConvertService();
            var systemService = new SystemService("BarLauncher-BaseConverter");
            var baseResultFinder = new BaseResultFinder(BarLauncherContextService, baseConvertService, systemInformations, systemService);

            return baseResultFinder;
        }
    }
}
