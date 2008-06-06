using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using EnvManager;

namespace EnvMan.Tests
{
    [TestFixture]
    public class FrmAboutTest
    {
        private FrmAbout aboutForm = null;

        public FrmAboutTest()
        {
            aboutForm = new FrmAbout();
        }

        [Test]
        public void TestPackageVersion()
        {
            string packageVersion = aboutForm.PackageVersion;
        }
    }
}
