using AllGreen.Lib;
using System.Collections.Generic;
using Wox.BaseConverter.Test.AllGreen.Helper;

namespace Wox.BaseConverter.Test.AllGreen.Fixture
{
    public class Url_opened_fixture : FixtureBase<BaseConverterContext>
    {
        public override IEnumerable<object> OnQuery()
        {
            foreach (var url in Context.ApplicationStarter.SystemService.UrlOpened)
            {
                yield return new Result { Url = url };
            }
        }

        public class Result
        {
            public string Url { get; set; }
        }
    }
}