/*
   AUM - Automated Updates Manager Tests
   Copyright (C) 2006-2008 Vlad Setchin <auto.updates.mng@gmail.com>

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

using AUM;
using AUM.VersionInformation;
using NUnit.Framework;

namespace AUM.Tests
{
    [TestFixture]
    public class VersionCheckerTest
    {
        private VersionChecker versionChecker = null;

        public VersionCheckerTest()
        {
            versionChecker = new VersionChecker(Properties.Resources.ProgramICO);
        }

        [Test]
        public void TestDownloadFile()
        {
            Uri address = new Uri( "http://env-man.sourceforge.net/img/FrmEdit.png" );
            string localFileNamePath = "EditForm.png";
            versionChecker.DownloadFile(address, localFileNamePath);
        }

        [Test]
        public void TestCheckVersionAutoNew()
        {
            VersionInfo versionInfo = new VersionInfo();
            versionInfo.AssemblyVersion = "1.2";
            versionInfo.DownloadWebPageAddress = "";

            versionChecker.CheckVersion( versionInfo, false);
        }

        [Test]
        public void TestCheckVersionAutoLatest ( )
        {
            VersionInfo versionInfo = new VersionInfo();
            versionInfo.AssemblyVersion = "1.3";
            versionInfo.DownloadWebPageAddress = "";

            versionChecker.CheckVersion( versionInfo, false );
        }

        [Test]
        public void TestCheckVersionManualLatest()
        {
            VersionInfo versionInfo = new VersionInfo();
            versionInfo.AssemblyVersion = "1.3";
            versionInfo.DownloadWebPageAddress = "";

            versionChecker.CheckVersion( versionInfo, true);
        }

        [Test]
        public void TestCheckVersionManualNew ( )
        {
            VersionInfo versionInfo = new VersionInfo();
            versionInfo.AssemblyVersion = "1.2";
            versionInfo.DownloadWebPageAddress = "";

            versionChecker.CheckVersion( versionInfo, true );
        }
    }
}
