using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.BaseConverter.Service;
using Wox.EasyHelper;
using Wox.EasyHelper.Core.Service;
using Wox.EasyHelper.Service;

namespace Wox.BaseConverter
{
    public class BaseConverterPlugin : WoxPlugin
    {
        public override IWoxResultFinder PrepareContext()
        {
            var systemInformations = new SystemInformations();
            var baseConvertService = new BaseConvertService();
            var systemService = new SystemService("Wox.BaseConverter");
            var woxBaseResultFinder = new WoxBaseResultFinder(WoxContextService, baseConvertService, systemInformations, systemService);

            return woxBaseResultFinder;
        }
    }
}
