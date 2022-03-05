using AllGreen.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;

namespace BarLauncher.BaseConverter.Test.AllGreen.Fixture
{
    public class SystemInformations_fixture : FixtureBase<BaseConverterContext>
    {
        public void The_application_name_is(string applicationName)
        {
            Context.ApplicationStarter.SystemInformations.ApplicationName = applicationName;
        }

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
