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

using EnvManager.Handlers;
using NUnit.Framework;

namespace EnvManager.Tests.Handlers
{
    [TestFixture]
    public class UndoRedoCommandListTest
    {
        #region Variables
        const string REDO_STRING = "Redo ";
        const string UNDO_STRING = "Undo ";
        const string COMMAND_NAME1 = "Command1";
        const string COMMAND_NAME2 = "Command2";
        const string COMMAND_NAME3 = "Command3";
        UndoRedoCommandList commandsList = null;
        MockCommand command1 = null;
        MockCommand command2 = null;
        MockCommand command3 = null;
        #endregion Variables

        #region Setup Teardown
        [SetUp]
        public void SetUp()
        {
            commandsList = new UndoRedoCommandList();

            command1 = new MockCommand();
            command1.CommandName = COMMAND_NAME1;

            command2 = new MockCommand();
            command2.CommandName = COMMAND_NAME2;

            command3 = new MockCommand();
            command3.CommandName = COMMAND_NAME3;
        }
        #endregion Setup Teardown

        #region Tests
        [Test]
        public void TestAdd()
        {
            commandsList.Add(command1);

            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsFalse(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME1);
        }
        [Test]
        public void TestAddUndo()
        {
            commandsList.Add(command1);
            UndoCommand(1);
            Assert.IsFalse(commandsList.CanUndo);
            Assert.IsTrue(commandsList.CanRedo);
            Assert.AreEqual(commandsList.RedoMsg, REDO_STRING + COMMAND_NAME1);
        }
        [Test]
        public void TestAddUndoAdd()
        {
            commandsList.Add(command1);
            UndoCommand(1);
            commandsList.Add(command2);
            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsFalse(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME2);
        }
        [Test]
        public void TestAddx2Undo()
        {
            commandsList.Add(command1);
            commandsList.Add(command2);
            UndoCommand(1);
            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsTrue(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME1);
            Assert.AreEqual(commandsList.RedoMsg, REDO_STRING + COMMAND_NAME2);
        }
        [Test]
        public void TestAddx2UndoAdd()
        {
            commandsList.Add(command1);
            commandsList.Add(command2);
            UndoCommand(1);
            commandsList.Add(command3);
            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsFalse(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME3);
        }
        [Test]
        public void TestAddx3Undox3()
        {
            commandsList.Add(command1);
            commandsList.Add(command2);
            commandsList.Add(command3);
            UndoCommand(3);
            Assert.IsFalse(commandsList.CanUndo);
            Assert.IsTrue(commandsList.CanRedo);
            Assert.AreEqual(commandsList.RedoMsg, REDO_STRING + COMMAND_NAME1);
        }
        [Test]
        public void TestAddx3Undox3Redox3()
        {
            commandsList.Add(command1);
            commandsList.Add(command2);
            commandsList.Add(command3);
            UndoCommand(3);
            RedoCommand(3);
            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsFalse(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME3);
        } 
        #endregion Tests

        #region Tool functions
        private void UndoCommand(int numActions)
        {
            for(int i = 0; i < numActions; i++)
            {
                commandsList.Undo();
            }
        }
        private void RedoCommand(int numActions)
        {
            for (int i = 0; i < numActions; i++)
            {
                commandsList.Redo();
            }
        }
        #endregion Tool functions
    }
}
