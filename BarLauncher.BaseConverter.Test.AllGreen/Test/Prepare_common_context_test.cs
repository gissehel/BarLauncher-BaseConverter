using AllGreen.Lib;
using BarLauncher.BaseConverter.Test.AllGreen.Fixture;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;

namespace BarLauncher.BaseConverter.Test.AllGreen.Test
{
    public class Prepare_common_context_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .Using<SystemInformations_fixture>()

            .DoAction(f => f.The_application_name_is("BarLauncher-BaseConverter"))
            .DoAction(f => f.The_application_url_is("https://homepage.example.com/barlauncher-baseconverter/"))
            .DoAction(f => f.The_application_verion_is("0.0.0"))

            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()

            .DoAction(f => f.Start_the_bar())
            .DoAction(f => f.Display_bar_launcher())
            .DoCheck(f => f.The_current_query_is(), "")

            .EndUsing()

            .EndTest();
    }
}