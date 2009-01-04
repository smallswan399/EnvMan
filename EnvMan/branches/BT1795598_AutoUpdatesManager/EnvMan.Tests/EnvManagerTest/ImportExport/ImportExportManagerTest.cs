/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>

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
using System.IO;

using EnvManager.ImportExport;
using NUnit.Framework;

namespace EnvManager.Tests.ImportExport
{
    [TestFixture]
    public class ImportExportManagerTest
    {
        string fileName = @"C:\EnvVarTest.env";
        ImportExportManager importExportManager = new ImportExportManager();
        EnvironmentVariable envVar = new EnvironmentVariable();

        ~ImportExportManagerTest()
        {
            if(File.Exists(fileName))
            {
                File.Delete( fileName );
            }
        }

        [SetUp]
        public void SetUp ( )
        {
            envVar.VarName = "TestVar";
            envVar.VarValues = "Val1;Val2;Val3";
        }
        [Test]
        public void TestSave()
        {   
            importExportManager.EnvVariable = envVar;
            importExportManager.Save( fileName );
            Assert.IsTrue( File.Exists( fileName ) );
        }
        [Test]
        public void TestLoad()
        {
            TestSave();
            importExportManager.Load(fileName);
            Assert.AreEqual( envVar.VarName, importExportManager.EnvVariable.VarName );
            Assert.AreEqual( envVar.VarValuesList[ 0 ], importExportManager.EnvVariable.VarValuesList[ 0 ] );
            Assert.AreEqual( envVar.VarValuesList[ 1 ], importExportManager.EnvVariable.VarValuesList[ 1 ] );
            Assert.AreEqual( envVar.VarValuesList[ 2 ], importExportManager.EnvVariable.VarValuesList[ 2 ] );
        }
    }
}
