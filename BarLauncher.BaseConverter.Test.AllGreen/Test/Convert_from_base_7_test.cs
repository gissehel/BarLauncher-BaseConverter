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
    public class Convert_from_base_7_test : TestBase<BaseConverterContext>
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
            .DoAction(f => f.Append__on_query(" "))
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2")
            .Check("version", "BarLauncher-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Append__on_query("7"))
            .DoCheck(f=>f.The_current_query_is(), "base 7")
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->BASE2 VALUE", "Convert VALUE expressed in base 7 to base BASE2")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->")
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->BASE2 VALUE", "Convert VALUE expressed in base 7 to base BASE2")
            .Check("conv 7->2 VALUE", "Convert VALUE expressed in base 7 to binary")
            .Check("conv 7->10 VALUE", "Convert VALUE expressed in base 7 to decimal")
            .Check("conv 7->16 VALUE", "Convert VALUE expressed in base 7 to hexadecimal")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Append__on_query("3"))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3")
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->3 VALUE", "Convert VALUE expressed in base 7 to base 3")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3 ")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Append__on_query("15"))
            .DoCheck(f => f.The_current_query_is(), "base conv 7->3 15")
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("conv 7->3 15 : 110", "[15] expressed in base 7 correspond to [110] in base 3")
            .EndUsing()

            .UsingList<Text_copied_to_clipboard_fixture>()
            .With<Text_copied_to_clipboard_fixture.Result>(f => f.Text)
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAccept(f => f.Bar_launcher_is_displayed())
            .DoAction(f => f.Select_line(1))
            .DoReject(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .UsingList<Text_copied_to_clipboard_fixture>()
            .With<Text_copied_to_clipboard_fixture.Result>(f => f.Text)
            .Check("110")
            .EndUsing()

            .EndTest();
    }
}
