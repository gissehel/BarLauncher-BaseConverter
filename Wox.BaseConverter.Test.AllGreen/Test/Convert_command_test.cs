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
    public class Convert_command_test : TestBase<BaseConverterContext>
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
            .DoAction(f => f.Write_query(@"base con"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base conv"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("conv 2->BASE2 VALUE", "Convert VALUE expressed in binary to base BASE2")
            .Check("conv 10->BASE2 VALUE", "Convert VALUE expressed in decimal to base BASE2")
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query(@"base con"))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv ")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("conv 2->BASE2 VALUE", "Convert VALUE expressed in binary to base BASE2")
            .Check("conv 10->BASE2 VALUE", "Convert VALUE expressed in decimal to base BASE2")
            .Check("conv 16->BASE2 VALUE", "Convert VALUE expressed in hexadecimal to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv ")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(2))
            .DoCheck(f => f.The_current_query_is(), "base conv 2->")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 2->BASE2 VALUE", "Convert VALUE expressed in binary to base BASE2")
            .Check("conv 2->10 VALUE", "Convert VALUE expressed in binary to decimal")
            .Check("conv 2->16 VALUE", "Convert VALUE expressed in binary to hexadecimal")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv 2->")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 2->BASE2 VALUE", "Convert VALUE expressed in binary to base BASE2")
            .Check("conv 2->10 VALUE", "Convert VALUE expressed in binary to decimal")
            .Check("conv 2->16 VALUE", "Convert VALUE expressed in binary to hexadecimal")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(2))
            .DoCheck(f => f.The_current_query_is(), "base conv 2->10 ")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 2->10 VALUE", "Convert VALUE expressed in binary to decimal")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Append__on_query(@"101"))
            .DoCheck(f => f.The_current_query_is(), "base conv 2->10 101")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 2->10 101 : 5", "[101] expressed in binary correspond to [5] in decimal")
            .EndUsing()

            .EndTest();
    }
}
