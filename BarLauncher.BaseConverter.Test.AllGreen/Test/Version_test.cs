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
    public class Version_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query("base ver"))
            .DoAccept(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("version", "BarLauncher-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Write_query("base version"))
            .DoAccept(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .UsingList<Bar_launcher_results_fixture>()
            .With<Bar_launcher_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("BarLauncher-BaseConverter version 0.0.0", "Select to open project home page (https://homepage.example.com/barlauncher-baseconverter/)")
            .EndUsing()

            .Using<Bar_launcher_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoReject(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .UsingList<Url_opened_fixture>()
            .With<Url_opened_fixture.Result>(f=>f.Url)
            .Check("https://homepage.example.com/barlauncher-baseconverter/")
            .EndUsing()

            .EndTest();
    }
}
