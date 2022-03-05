using AllGreen.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Test.AllGreen.Fixture;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;

namespace BarLauncher.BaseConverter.Test.AllGreen.Test
{
    public class Convert_errors_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 8->1 17"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Error : The radix must be >= 2 and <= 36")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 8->2 19"))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Error : Character [9] is invalid in base 8")
            .EndUsing()


            .EndTest();

    }
}
