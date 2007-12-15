/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

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
        ButtonTester btnTestMoveUp = null;
        ButtonTester btnTestMoveDown = null;
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
            varManager.SetEnvironmentVariable(SYS_VAR_NAME, VAR_VALUE, 
                EnvironmentVariableTarget.Machine);
            frmEdit = new FrmEditEnvVar(SYS_VAR_NAME, 
                EnvironmentVariableTarget.Machine);
            dgv = frmEdit.DgView;
            btnTestMoveDown = new ButtonTester( "btnMoveDown", frmEdit.Name );
            btnTestMoveUp = new ButtonTester("btnMoveUp", frmEdit.Name);
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
            varManager.DeleteEnvironmentVariable(SYS_VAR_NAME, 
                EnvironmentVariableTarget.Machine);
        }

        #region Tests
        [SetUp]
        public void SetUp()
        {
            frmEdit.LoadEnvironmentVariableValues(SYS_VAR_NAME, 
                EnvironmentVariableTarget.Machine);
            dgv.CurrentCell = dgv.Rows[2].Cells[1];
        }
        [Test]
        public void TestSaveValue()
        {
            btnTestMoveDown.Click();
            btnTestMoveDown.Click();
            btnTestSave.Click();
            Assert.AreEqual("Val1;Val2;Val4;Val5;Val3;Val6;Val7",
                varManager.GetEnvVariable(SYS_VAR_NAME, EnvironmentVariableTarget.Machine));
            varManager.SetEnvironmentVariable(SYS_VAR_NAME, VAR_VALUE, 
                EnvironmentVariableTarget.Machine);
        }
        #region Move Commands
        [Test]
        public void TestMoveRowDown2UndoRedo ( )
        {
            // Move value down
            btnTestMoveDown.Click();
            btnTestMoveDown.Click();
            Assert.AreEqual( "Val1;Val2;Val4;Val5;Val3;Val6;Val7",
                frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // Undo last move
            btnTestUndo.Click();
            Assert.AreEqual( "Val1;Val2;Val4;Val3;Val5;Val6;Val7",
                frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            // Redo last move
            btnTestRedo.Click();
            Assert.AreEqual( "Val1;Val2;Val4;Val5;Val3;Val6;Val7",
                frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
        }
        [Test]
        public void TestMove135RowsDownUndoRedo ( )
        {
            #region Select rows
            // select row 1
            dgv.Rows[ 0 ].Selected = true;
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            // select row 5
            dgv.Rows[ 4 ].Selected = true;
            #endregion Select rows

            #region Perform Move, Undo, Redo
            btnTestMoveDown.Click();
            Assert.AreEqual( "Val2;Val1;Val4;Val3;Val6;Val5;Val7",
                frmEdit.EnvironmentVariableValue().ToString() );
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            btnTestRedo.Click();
            Assert.AreEqual( "Val2;Val1;Val4;Val3;Val6;Val5;Val7",
                frmEdit.EnvironmentVariableValue().ToString() );
            #endregion Perform Move, Undo, Redo
        }
        [Test]
        public void TestMove357RowsDownUndoRedo ( )
        {
            #region Select rows
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            // select row 5
            dgv.Rows[ 4 ].Selected = true;
            // select row 7
            dgv.Rows[ 6 ].Selected = true;
            #endregion Select rows

            #region Perform Move, Undo, Redo
            btnTestMoveDown.Click();
            string expectedValue = "Val1;Val2;Val4;Val3;Val6;Val5;Val7";
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            btnTestRedo.Click();
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            #endregion Perform Move, Undo, Redo
        }
        [Test]
        public void TestMoveRowUp2Undo2Redo ( )
        {
            // move up twice
            btnTestMoveUp.Click();
            btnTestMoveUp.Click();
            Assert.AreEqual( "Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // undo move row up
            btnTestUndo.Click();
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsFalse( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            // redo move row up
            btnTestRedo.Click();
            Assert.AreEqual( "Val1;Val3;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
        }
        [Test]
        public void TestMoveRows357UpUndoRedo ( )
        {
            #region Select Rows
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            // select row 5
            dgv.Rows[ 4 ].Selected = true;
            // select row 7
            dgv.Rows[ 6 ].Selected = true;
            #endregion
            #region Perform Move, Undo, Redo
            btnTestMoveUp.Click();
            string expectedValue = "Val1;Val3;Val2;Val5;Val4;Val7;Val6";
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            btnTestRedo.Click();
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            #endregion Perform Move, Undo, Redo
        }
        [Test]
        public void TestMoveRows123Up ( )
        {
            #region Select Rows
            // select row 1
            dgv.Rows[ 0 ].Selected = true;
            // select row 2
            dgv.Rows[ 1 ].Selected = true;
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            #endregion
            #region Perform Move, Undo, Redo
            btnTestMoveUp.Click();
            // TODO: Expected Exception
            //string expectedValue = "Val1;Val3;Val2;Val5;Val4;Val7;Val6";
            //Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            #endregion Perform Move, Undo, Redo
        }
        [Test]
        public void TestMoveRowBottomUndoRedo ( )
        {
            btnTestMoveBottom.Click();
            string expectedValue = "Val1;Val2;Val4;Val5;Val6;Val7;Val3";
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // Undo move row top
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsFalse( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            // Redo move row top
            btnTestRedo.Click();
            Assert.AreEqual( expectedValue, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
        }
        [Test]
        public void TestMoveRowTopUndoRedo ( )
        {
            // Move row top
            btnTestMoveTop.Click();
            Assert.AreEqual( "Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // Undo move row top
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsFalse( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            // Redo move row top
            btnTestRedo.Click();
            Assert.AreEqual( "Val3;Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
        }
        #endregion Move Commands
        #region Delete Commands
        [Test]
        public void TestDeleteRowUndoRedo ( )
        {
            // delete row
            btnTestDelete.Click();
            Assert.AreEqual( "Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // undo delete
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsFalse( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            // redo delete
            btnTestRedo.Click();
            Assert.AreEqual( "Val1;Val2;Val4;Val5;Val6;Val7", frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
        }
        [Test]
        public void TestDelete3RowsUndoRedo ( )
        {
            #region Select rows
            // select row 1
            dgv.Rows[ 0 ].Selected = true;
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            // select row 7
            dgv.Rows[ 6 ].Selected = true;
            #endregion Select rows

            #region Perform Delete, Undo, Redo
            // delete row
            btnTestDelete.Click();
            Assert.AreEqual( "Val2;Val4;Val5;Val6;",
                frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            // undo delete
            btnTestUndo.Click();
            Assert.AreEqual( VAR_VALUE, frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsFalse( btnTestUndo.Properties.Enabled );
            Assert.IsTrue( btnTestRedo.Properties.Enabled );
            // redo delete
            btnTestRedo.Click();
            Assert.AreEqual( "Val2;Val4;Val5;Val6;",
                frmEdit.EnvironmentVariableValue().ToString() );
            Assert.IsTrue( btnTestUndo.Properties.Enabled );
            Assert.IsFalse( btnTestRedo.Properties.Enabled );
            #endregion Perform Delete, Undo, Redo
        }
        #endregion Delete Commands
        [Test]
        [Ignore("Need Look at NUnitForms with Open Folder Dialog")]
        public void TestBrowseFolderNewRow()
        {
            btnTestBrowse.Click();
            Assert.AreEqual(@"Val1;Val2;C:\;Val4;Val5;Val6;Val7", 
                frmEdit.EnvironmentVariableValue().ToString());
            Assert.IsTrue(btnTestUndo.Properties.Enabled);
            Assert.IsFalse(btnTestRedo.Properties.Enabled);
        }
        #endregion Tests
    }
}
