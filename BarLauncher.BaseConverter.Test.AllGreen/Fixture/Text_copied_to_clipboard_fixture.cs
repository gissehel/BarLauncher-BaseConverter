using AllGreen.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.BaseConverter.Test.AllGreen.Helper;

namespace BarLauncher.BaseConverter.Test.AllGreen.Fixture
{
    public class Text_copied_to_clipboard_fixture : FixtureBase<BaseConverterContext>
    {
        public override IEnumerable<object> OnQuery()
        {
            foreach (var text in Context.ApplicationStarter.SystemService.TextCopiedToClipboard)
            {
                yield return new Result { Text = text };
            }
        }

        public class Result
        {
            public string Text { get; set; }
        }
    }
}
