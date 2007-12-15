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

using NUnit.Framework;
using EnvManager.Commands;

namespace EnvManager.Tests.Commands
{
    [TestFixture]
    public class DgvDeleteCommandTest
    {
        private DataGridView dgv = null;
        private DgvTestDataHandler testDataHanlder = null;
        private DgvDeleteCommand deleteCommand = null;
        private DgvHandler dgvHandler = null;
        SortedList<int, DgvRowInfo> rowInfoList = null;

        public DgvDeleteCommandTest()
        {
            rowInfoList = new SortedList<int, DgvRowInfo>();
            dgv = new DataGridView();
            testDataHanlder = new DgvTestDataHandler(ref dgv);
            dgvHandler = testDataHanlder.DgvHanlderData;
        }

        [SetUp]
        public void Setup()
        {
            dgv.Rows.Clear();
            dgvHandler.AddRow( "VarVal1" );
            dgvHandler.AddRow( "VarVal2" );
            dgvHandler.AddRow( "VarVal3" );
            dgvHandler.AddRow( "VarVal4" );
            dgvHandler.AddRow( "VarVal5" );
            dgvHandler.AddRow( "VarVal6" );
            dgvHandler.AddRow( "VarVal7" );
        }

        [TearDown]
        public void TearDown()
        {
            deleteCommand = null;
        }

        /// <summary>
        /// Tests the simulation deletion of Rows 1, 3, 5 with delete button and undo redo.
        /// </summary>
        [Test]
        public void TestDelete135WithDeleteButtonUndoRedo()
        {
            #region Select rows
            // select row 1
            dgv.Rows[ 0 ].Selected = true;
            // select row 3
            dgv.Rows[ 2 ].Selected = true;
            // select row 5
            dgv.Rows[ 4 ].Selected = true;
            #endregion Select rows
            deleteCommand = new DgvDeleteCommand( dgvHandler );
            deleteCommand.Execute();

            // check that rows are deleted
            Assert.IsTrue( !dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );

            deleteCommand.Undo();

            // Check that Rows are not deleted
            Assert.IsTrue( dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );

            deleteCommand.Redo();

            // check that rows are deleted
            Assert.IsTrue( !dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );
        }

        /// <summary>
        /// Tests the simulation deletion of Rows 1, 3, 5 with delete key and undo redo.
        /// </summary>
        [Test]
        public void TestDelete135WithDeleteKeyUndoRedo()
        {
            #region Select rows
            // select row 1
            DgvRowInfo rowInfo0 = new DgvRowInfo();
            rowInfo0.CurrentRowIndex = 0;
            rowInfoList.Add( 0, rowInfo0 );
            dgv.Rows[ 0 ].Visible = false;

            // select row 3
            DgvRowInfo rowInfo2 = new DgvRowInfo();
            rowInfo2.CurrentRowIndex = 2;
            rowInfoList.Add( 2, rowInfo2 );
            dgv.Rows[ 2 ].Visible = false;

            // select row 5
            DgvRowInfo rowInfo4 = new DgvRowInfo();
            rowInfo4.CurrentRowIndex = 4;
            rowInfoList.Add( 4, rowInfo4 );
            dgv.Rows[ 4 ].Visible = false;
            #endregion Select rows

            deleteCommand = new DgvDeleteCommand( dgvHandler, rowInfoList );
            deleteCommand.Execute();

            // check that rows are deleted
            Assert.IsTrue( !dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );

            deleteCommand.Undo();

            // Check that Rows are not deleted
            Assert.IsTrue( dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );

            deleteCommand.Redo();

            // check that rows are deleted
            Assert.IsTrue( !dgv.Rows[ 0 ].Visible );
            Assert.IsTrue( dgv.Rows[ 1 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 2 ].Visible );
            Assert.IsTrue( dgv.Rows[ 3 ].Visible );
            Assert.IsTrue( !dgv.Rows[ 4 ].Visible );
            Assert.IsTrue( dgv.Rows[ 5 ].Visible );
            Assert.IsTrue( dgv.Rows[ 6 ].Visible );
        }
    }
}
