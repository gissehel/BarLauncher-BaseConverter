using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BarLauncher.BaseConverter.Lib.Service;

namespace BarLauncher.BaseConverter.Test.NUnit.Service
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
