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
