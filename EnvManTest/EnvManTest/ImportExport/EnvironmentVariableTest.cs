using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using EnvManager.ImportExport;
using NUnit.Framework;

namespace EnvManager.Tests.ImportExport
{
    [TestFixture]
    public class EnvironmentVariableTest
    {
        private const string VAR_NAME = "TestVarName";
        private const string Var1 = "Val1";
        private const string Var2 = "Val2";
        private const string Var3 = "Val3";
        private string varValues = Var1 +";" + Var2 +";" + Var3;
        private EnvironmentVariable envVar = new EnvironmentVariable();

        [Test]
        public void TestVarName()
        {
            envVar.VarName = VAR_NAME;
            Assert.AreEqual( VAR_NAME, envVar.VarName );
        }

        [Test]
        public void TestVarValues()
        {
            envVar.VarValues = varValues;
            List<string> varValuesList = envVar.VarValuesList;

            Assert.AreEqual( Var1, varValuesList[ 0 ] );
            Assert.AreEqual( Var2, varValuesList[ 1 ] );
            Assert.AreEqual( Var3, varValuesList[ 2 ] );

        }
    }
}
