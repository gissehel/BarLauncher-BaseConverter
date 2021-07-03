using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wox.BaseConverter.Service;

namespace Wox.BaseConverter.Test.Unit.Service
{

    [TestFixture]    
    public class SystemInformationsTest
    {
        public ISystemInformations SystemInformations { get; set; }

        [SetUp]
        public void SetUp()
        {
            SystemInformations = new SystemInformations();
        }

        [Test]
        public void VersionIsNotNullTest()
        {
            Assert.IsNotNull(SystemInformations.Version);
        }

        [Test]
        public void HomepageIsNotNullTest()
        {
            Assert.IsNotNull(SystemInformations.HomepageUrl);
        }
    }
}
