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

using EnvManager.Handlers;
using NUnit.Framework;

namespace EnvManager.Tests
{
    [TestFixture]
    public class EditVarNameCommandTest
    {
        TextBox txtBox = null;
        EditVarNameCommand editVarNameCommand = null;
        const string VAR_NAME = "Var Name";
        const string NEW_VAR_NAME = "New Var Name";

        [SetUp]
        public void SetUp ( )
        {
            txtBox = new TextBox();
            txtBox.Text = VAR_NAME;
            editVarNameCommand = new EditVarNameCommand(txtBox);
        }

        [TearDown]
        public void TearDown ( )
        {
            txtBox.Dispose();
        }

        [Test]
        public void TestUndoEdit()
        {
            txtBox.Text = NEW_VAR_NAME;
            editVarNameCommand.NewVarName = NEW_VAR_NAME;
            Assert.AreNotEqual( editVarNameCommand.CurrentVarName, txtBox.Text );
            editVarNameCommand.Undo();
            Assert.AreEqual( editVarNameCommand.CurrentVarName, txtBox.Text );
        }

        [Test]
        public void TestUndoRedoEdit()
        {
            txtBox.Text = NEW_VAR_NAME;
            editVarNameCommand.NewVarName = NEW_VAR_NAME;
            Assert.AreNotEqual( editVarNameCommand.CurrentVarName, txtBox.Text );
            editVarNameCommand.Undo();
            Assert.AreEqual( editVarNameCommand.CurrentVarName, txtBox.Text );
            editVarNameCommand.Redo();
            Assert.AreNotEqual( editVarNameCommand.CurrentVarName, txtBox.Text );
        }
    }
}
