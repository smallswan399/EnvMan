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
