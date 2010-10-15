using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Envman.VersionManager.VersionInformation;

namespace Envman.Tests.VersionManager.VersionInformation
{
    [TestFixture]
    public class VersionInfoTest
    {
        [Test]
        public void TestVersionFormatter1_4RC1()
        {
            string versionString = VersionInfo.VersionFormatter(new Version(1, 4, 0, 1));

            Assert.AreEqual("V1.4 RC1", versionString);
        }

        [Test]
        public void TestVersionFormatter1_4()
        {
            string versionString = VersionInfo.VersionFormatter(new Version(1, 4, 0, 0));

            Assert.AreEqual("V1.4", versionString);
        }
    }
}
