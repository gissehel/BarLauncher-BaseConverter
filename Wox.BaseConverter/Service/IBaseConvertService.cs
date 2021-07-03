using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.BaseConverter.Service
{
    public interface IBaseConvertService
    {
        string Convert(string value, int baseOrigin, int baseResult);
    }
}
