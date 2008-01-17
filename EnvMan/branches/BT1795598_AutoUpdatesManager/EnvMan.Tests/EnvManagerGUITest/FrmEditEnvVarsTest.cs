/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <Anastasia.Corporation+EnvMan@gmail.com>

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

using EnvManager;
using NUnit.Framework;
using NUnit.Extensions.Forms;

namespace EnvManager.Tests.GUI
{
    [TestFixture]
    public class FrmEditEnvVarsTest
    {
        #region Controls
        DataGridView dgv = null;
        FrmEditEnvVar frmEdit = null;
        ButtonTester btnTestUp = null;
        ButtonTester btnTestDown = null;
        ButtonTester btnTestMoveBottom = null;
        ButtonTester btnTestMoveTop = null;
        ButtonTester btnTestSave = null;
        ButtonTester btnTestUndo = null;
        ButtonTester btnTestRedo = null;
        ButtonTester btnTestDelete = null;
        ButtonTester btnTestBrowse = null;
        #endregion Controls

        #region Test Data
        const string SYS_VAR_NAME = "SysTestVariable";
        //const string USER_VAR_NAME = "UserTestVariable";
        const string VAR_VALUE = "Val1;Val2;Val3;Val4;Val5;Val6;Val7";
        EnvVarManager varManager = null; 
        #endregion Test Data

        public FrmEditEnvVarsTest()
        {
            varManager = new EnvVarManager();
            varManager.SetEnvironmentVariable(SYS_VAR_NAME, VAR_VALUE, EnvironmentVariableTarget.Machine);
            frmEdit = new FrmEditEnvVar(SYS_VAR_NAME, EnvironmentVariableTarget.Machine);
            dgv = frmEdit.DgView;
            btnTestDown = new ButtonTester( "btnMoveDown", frmEdit.Name );
            btnTestUp = new ButtonTester("btnMoveUp", frmEdit.Name);
            btnTestSave = new ButtonTester( "btnSave", frmEdit.Name );
            btnTestMoveBottom = new ButtonTester("btnMoveBottom", frmEdit.Name);
            btnTestMoveTop = new ButtonTester("btnMoveTop", frmEdit.Name);
            btnTestUndo = new ButtonTester( "btnUndo", frmEdit.Name );
            btnTestRedo = new ButtonTester( "btnRedo", frmEdit.Name );
            btnTestDelete = new ButtonTester("btnDelete", frmEdit.Name);
            btnTestBrowse = new ButtonTester("btnBrowse", frmEdit.Name);
            frmEdit.Show();
        }
        ~FrmEditEnvVarsTest()
        {
            frmEdit.Dispose();
            varManager.DeleteEnvironmentVariable(SYS_VAR_NAME, EnvironmentVariableTarget.Machine);
        }

        #region Tests
        [SetUp]
        public void SetUp()
        {
            frmEdit.LoadEnvironmentVariableValues(SYS_VAR_NAME, EnvironmentVariableTarget.Machine);
            dgv.CurrentCell = dgv.Rows[2].Cells[1];
        }
        [Test]
        public void TestSaveValue()
        {
            btnTestDown.Click();
            btnTestDown.Click();
            btnTestSave.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val3;Val6;Val7",
                varManager.GetEnvVariable(SYS_VAR_NAME, EnvironmentVariableTarget.Machine));
            varManager.SetEnvironmentVariable(SYS_VAR_NAME, VAR_VALUE, EnvironmentVariableTarget.Machine);
        }
        [Test]
        public void TestMoveRowDown2UndoRedo()
        {
            // Move value down
            btnTestDown.Click();
            btnTestDown.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val3;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
            // Undo last move
            btnTestUndo.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val3;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            // Redo last move
            btnTestRedo.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val3;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        [Test]
        public void TestMoveRowUp2Undo2Redo()
        {
            // move up twice
            btnTestUp.Click();
            btnTestUp.Click();
            Assert.AreEqual("Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
            // undo move row up
            btnTestUndo.Click();
            btnTestUndo.Click();
            Assert.AreEqual(VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsFalse(btnTestUndo.Properties.Enabled);
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
            // redo move row up
            btnTestRedo.Click();
            Assert.AreEqual("Val1;Val3;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
        }
        [Test]
        public void TestMoveRowBottomUndoRedo()
        {
            btnTestMoveBottom.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val6;Val7;Val3", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
            // Undo move row top
            btnTestUndo.Click();
            Assert.AreEqual(VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsFalse(btnTestUndo.Properties.Enabled);
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
            // Redo move row top
            btnTestRedo.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val6;Val7;Val3", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        [Test]
        public void TestMoveRowTopUndoRedo()
        {
            // Move row top
            btnTestMoveTop.Click();
            Assert.AreEqual("Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
            // Undo move row top
            btnTestUndo.Click();
            Assert.AreEqual(VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsFalse(btnTestUndo.Properties.Enabled);
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
            // Redo move row top
            btnTestRedo.Click();
            Assert.AreEqual("Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        [Test]
        public void TestDeleteRowUndoRedo()
        {
            // delete row
            btnTestDelete.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
            // undo delete
            btnTestUndo.Click();
            Assert.AreEqual(VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsFalse(btnTestUndo.Properties.Enabled);
            Assert.IsTrue(btnTestRedo.Properties.Enabled);
            // redo delete
            btnTestRedo.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        [Test]
        public void TestBrowseFolderNewRow()
        {
            btnTestBrowse.Click();
            Assert.AreEqual(@"Val1;Val2;C:\;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        #endregion Tests
    }
}
