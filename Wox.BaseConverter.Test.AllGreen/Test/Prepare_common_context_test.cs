using AllGreen.Lib;
using Wox.BaseConverter.Test.AllGreen.Fixture;
using Wox.BaseConverter.Test.AllGreen.Helper;

namespace Wox.BaseConverter.Test.AllGreen.Test
{
    public class Prepare_common_context_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .Using<SystemInformations_fixture>()

            .DoAction(f => f.The_application_url_is("https://homepage.example.com/wox-baseconverter/"))
            .DoAction(f => f.The_application_verion_is("0.0.0"))

            .EndUsing()

            .Using<Wox_bar_fixture>()

            .DoAction(f => f.Start_the_bar())
            .DoAction(f => f.Display_wox())
            .DoCheck(f => f.The_current_query_is(), "")

            .EndUsing()

            .EndTest();
    }
}