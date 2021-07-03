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
    public class Version_test : TestBase<BaseConverterContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context_test>()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query("base ver"))
            .DoAccept(f => f.Wox_is_displayed())
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("version", "Wox-BaseConverter version 0.0.0")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Write_query("base version"))
            .DoAccept(f => f.Wox_is_displayed())
            .EndUsing()

            .UsingList<Wox_results_fixture>()
            .With<Wox_results_fixture.Result>(f => f.Title, f => f.SubTitle)
            .Check("Wox-BaseConverter version 0.0.0", "Select to open project home page (https://homepage.example.com/wox-baseconverter/)")
            .EndUsing()

            .Using<Wox_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoReject(f => f.Wox_is_displayed())
            .EndUsing()

            .UsingList<Url_opened_fixture>()
            .With<Url_opened_fixture.Result>(f=>f.Url)
            .Check("https://homepage.example.com/wox-baseconverter/")
            .EndUsing()

            .EndTest();
    }
}
