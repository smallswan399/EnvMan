/*
   AUM - Automated Updates Manager Tests
   Copyright (C) 2006-2008 Vlad Setchin <Anastasia.Corporation+AUM@gmail.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using NUnit.Framework;
using AUM.VersionInformation;

namespace AUM.Tests.VersionInformation
{
    [TestFixture]
    public class VersionInfoManagerTest
    {
        private VersionInfo versionInfo = null;
        private VersionInfoManager versionInfoManager = null;

        public VersionInfoManagerTest()
        {
            versionInfoManager = new VersionInfoManager();
            versionInfo = new VersionInfo();
        }

        [SetUp]
        public void Setup()
        {
            versionInfo.AssemblyVersion = "1.3";
            versionInfo.DownloadWebPageAddress = "http://env-man.blogspot.com/2007/04/envman-user-guide.html";
        }

        [Test]
        public void TestSaveVersionInfo()
        {
            versionInfoManager.VersionInformation = versionInfo;
            string fileName = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) 
                + "\\Anastasia_Corporation\\VersionInfo.aum";
            versionInfoManager.Save(fileName);

            Assert.IsTrue( File.Exists( fileName ) );
        }
    }
}
