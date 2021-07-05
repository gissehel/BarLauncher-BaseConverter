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
    public class Convert_from_base_7_test : TestBase<BaseConverterContext>
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
            .DoAction(f => f.Append__on_query(" "))
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "Wox-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Append__on_query("7"))
            .DoCheck(f=>f.The_current_query_is(), "base 7")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->BASE2 VALUE", "Convert VALUE expressed in base 7 to base BASE2")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->BASE2 VALUE", "Convert VALUE expressed in base 7 to base BASE2")
            .Check("conv 7->2 VALUE", "Convert VALUE expressed in base 7 to binary")
            .Check("conv 7->10 VALUE", "Convert VALUE expressed in base 7 to decimal")
            .Check("conv 7->16 VALUE", "Convert VALUE expressed in base 7 to hexadecimal")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Append__on_query("3"))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->3 VALUE", "Convert VALUE expressed in base 7 to base 3")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3 ")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Append__on_query("15"))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3 15")
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->3 15 : 110", "[15] expressed in base 7 correspond to [110] in base 3")
            .EndUsing()

            .UsingList<Text_copied_to_clipboard_fixture>()
            .With<Text_copied_to_clipboard_fixture.Result>(f => f.Text)
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAccept(f => f.Wox_is_displayed())
            .DoAction(f => f.Select_line(1))
            .DoReject(f => f.Wox_is_displayed())
            .EndUsing()

            .UsingList<Text_copied_to_clipboard_fixture>()
            .With<Text_copied_to_clipboard_fixture.Result>(f => f.Text)
            .Check("110")
            .EndUsing()

            .EndTest();
    }
}
