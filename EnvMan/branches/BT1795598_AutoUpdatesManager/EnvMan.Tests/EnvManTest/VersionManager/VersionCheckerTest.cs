/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envman-dev@googlegroups.com>

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

using EnvMan.VersionManager;
using EnvMan.VersionManager.VersionInformation;
using NUnit.Framework;

namespace EnvMan.Tests.VersionManager
{
    [TestFixture]
    public class VersionCheckerTest
    {
        private VersionChecker versionChecker = null;
        VersionInfo versionInfo = new VersionInfo();

        public VersionCheckerTest()
        {
            versionChecker = new VersionChecker(Properties.Resources.ProgramICO);
        }

        [SetUp]
        public void Setup()
        {
            versionInfo.AssemblyVersion = new Version(1, 3);
            versionInfo.DownloadWebPageAddress = "";
        }

        [Test]
        public void TestDownloadFile()
        {
            Uri address = new Uri( "http://env-man.sourceforge.net/img/FrmMain.JPG" );
            string localFileNamePath = "MainForm.jpg";
            Assert.IsTrue(versionChecker.DownloadFile(address, localFileNamePath));
        }
        // TODO: work with these tests
        /// <summary>
        /// Tests the Auto Check for a new version.
        /// </summary>
        [Test]
        public void TestCheckVersionAutoNew()
        {
            versionInfo.AssemblyVersion = new Version(1, 2);
            versionChecker.CheckVersion( versionInfo );
        }

        /// <summary>
        /// Tests the Auto Check for latest (current) version.
        /// </summary>
        [Test]
        public void TestCheckVersionAutoLatest ( )
        {
            versionChecker.CheckVersion( versionInfo );
        }

        /// <summary>
        /// Tests the manual check for latest (current) version.
        /// </summary>
        [Test]
        public void TestCheckVersionManualLatest()
        {
            versionChecker.CheckVersion( versionInfo );
        }

        /// <summary>
        /// Tests the manual check for new version.
        /// </summary>
        [Test]
        public void TestCheckVersionManualNew ( )
        {
            versionChecker.CheckVersion( versionInfo );
        }
    }
}
