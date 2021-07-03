using AllGreen.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.BaseConverter.Test.AllGreen.Helper;

namespace Wox.BaseConverter.Test.AllGreen.Fixture
{
    public class SystemInformations_fixture : FixtureBase<BaseConverterContext>
    {
        public void The_application_verion_is(string version)
        {
            Context.ApplicationStarter.SystemInformations.Version = version;
        }

        public void The_application_url_is(string url)
        {
            Context.ApplicationStarter.SystemInformations.HomepageUrl = url;
        }

    }
}
