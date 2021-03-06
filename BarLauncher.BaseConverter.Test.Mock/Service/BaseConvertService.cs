using BarLauncher.BaseConverter.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.BaseConverter.Test.Mock.Service
{
    public class BaseConvertServiceMock : IBaseConvertService
    {
        public Func<string, int, int, string> OnConvert { get; set; }

        public string Convert(string value, int baseOrigin, int baseResult)
        {
            if (OnConvert != null)
            {
                return OnConvert(value, baseOrigin, baseResult);
            }
            return null;
        }
    }
}
