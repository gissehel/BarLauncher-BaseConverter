using AllGreen.Lib;
using Wox.BaseConverter.Test.AllGreen.Fixture;
using Wox.BaseConverter.Test.AllGreen.Helper;
using Wox.BaseConverter.Test.AllGreen.Test;

namespace Wox.BaseConverter.Test.AllGreen.Test
{
    public class Show_commands_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "Wox-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base n"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "Wox-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base er"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("version", "Wox-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 16"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 16->"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .Check("conv 16->2 VALUE", "Convert VALUE expressed in hexadecimal to binary")
            .Check("conv 16->10 VALUE", "Convert VALUE expressed in hexadecimal to decimal")
            .EndUsing()

            .EndTest();
    }
}