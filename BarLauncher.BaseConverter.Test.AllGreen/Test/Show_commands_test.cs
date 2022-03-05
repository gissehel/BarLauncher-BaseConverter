using AllGreen.Lib;
using BarLauncher.BaseConverter.Test.AllGreen.Fixture;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;
using BarLauncher.BaseConverter.Test.AllGreen.Test;

namespace BarLauncher.BaseConverter.Test.AllGreen.Test
{
    public class Show_commands_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "BarLauncher-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base n"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "BarLauncher-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base er"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("version", "BarLauncher-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 16"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 16->"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .Check("conv 16->2 VALUE", "Convert VALUE expressed in hexadecimal to binary")
            .Check("conv 16->10 VALUE", "Convert VALUE expressed in hexadecimal to decimal")
            .EndUsing()

            .EndTest();
    }
}