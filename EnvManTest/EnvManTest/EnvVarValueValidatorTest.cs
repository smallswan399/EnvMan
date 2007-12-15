/*
  EnvMan Tests - The Open-Source Windows Environment Variables Manager
  Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using EnvManager;
using NUnit.Framework;

namespace EnvManager.Tests
{
    [TestFixture]
    public class EnvVarValueValidatorTest
    {
        EnvVarValueValidator validator = null;

        [SetUp]
        public void SetUp()
        {
            validator = new EnvVarValueValidator();
        }

        #region Tests
        [Test]
        public void TestFullNumberType()
        {
            EnvironmentValueType type = validator.ValueType("10");

            Assert.AreEqual(EnvironmentValueType.Number, type);
        }

        [Test]
        public void TestFloatNumberType()
        {
            EnvironmentValueType type = validator.ValueType("10.50");

            Assert.AreEqual(EnvironmentValueType.Number, type);
        }

        [Test]
        public void TestFolderType()
        {
            EnvironmentValueType type = validator.ValueType(@"C:\Windows");

            Assert.AreEqual(EnvironmentValueType.Folder, type);
        }

        [Test]
        public void TestErrorType()
        {
            EnvironmentValueType type = validator.ValueType(@"C:\12345");

            Assert.AreEqual(EnvironmentValueType.Error, type);
        }

        [Test]
        public void TestStringType()
        {
            EnvironmentValueType type = validator.ValueType("This is a string value");

            Assert.AreEqual(EnvironmentValueType.String, type);
        }

        [Test]
        public void TestFileType()
        {
            string fileName = @"C:\EnvMan.test";

            // create tmp file for a test
            FileStream file = File.Create(fileName);
            file.Close();

            // Test
            EnvironmentValueType type = validator.ValueType(fileName);

            Assert.AreEqual(EnvironmentValueType.File, type);

            // remove tmp file after completing a test
            File.Delete(fileName);            
        }
        #endregion Tests
    }
}
