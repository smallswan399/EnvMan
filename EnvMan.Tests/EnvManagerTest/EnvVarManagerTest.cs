using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using EnvManager;

namespace EnvManager.Tests
{
    [TestFixture]
    public class EnvVarManagerTest
    {
        private string testUserVarName = "TestUserVar1";
        private string testUserVarVal = @"%SystemRoot%\system32\cmd.exe";

        private string testSystemVarName = "TestSystemVar1";
        private string testSystemVarVal = @"%SystemRoot%\system32\cmd.exe";
        
        private EnvVarManager variableManager = new EnvVarManager();

        [SetUp]
        public void Setup()
        {
            variableManager.SetEnvironmentVariable(testUserVarName, testUserVarVal, 
                EnvironmentVariableTarget.User);
            variableManager.SetEnvironmentVariable(testSystemVarName, testSystemVarVal,
                EnvironmentVariableTarget.Machine);
        }

        [TearDown]
        public void TearDown()
        {
            variableManager.DeleteEnvironmentVariable(testUserVarName, EnvironmentVariableTarget.User);
            variableManager.DeleteEnvironmentVariable(testSystemVarName, EnvironmentVariableTarget.Machine);
        }

        [Test]
        public void TestExpandEnvironmentVariable()
        {
            string varVal = @"C:\Windows";
            variableManager.SetEnvironmentVariable("TempDirVar", varVal, EnvironmentVariableTarget.User);
            variableManager.SetEnvironmentVariable("TempExtandedDirVar", @"%TempDirVar%\temp", EnvironmentVariableTarget.User);
            string varExpandedVal = variableManager.ExpandEnvironmentVariable(@"%TempDirVar%\temp");

            variableManager.DeleteEnvironmentVariable("TempDirVar", EnvironmentVariableTarget.User);
            variableManager.DeleteEnvironmentVariable("TempExtandedDirVar", EnvironmentVariableTarget.User);

            Assert.AreEqual(varVal + @"\cmd.exe", varExpandedVal);
        }

        [Test]
        public void TestGetUserEnvironmentVariable()
        {
            string varVal = variableManager.GetEnvironmentVariable(testUserVarName, EnvironmentVariableTarget.User);

            Assert.AreEqual(testUserVarVal, varVal);
        }
    }
}
