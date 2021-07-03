using AllGreen.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.BaseConverter.Test.AllGreen.Fixture;
using Wox.BaseConverter.Test.AllGreen.Helper;

namespace Wox.BaseConverter.Test.AllGreen.Test
{
    public class Convert_errors_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 8->1 17"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Error : The radix must be >= 2 and <= 36")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base 8->2 19"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Error : Character [9] is invalid in base 8")
            .EndUsing()


            .EndTest();

    }
}
