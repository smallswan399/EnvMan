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
        const string REDO_STRING = "Redo ";
        const string UNDO_STRING = "Undo ";
        const string COMMAND_NAME1 = "Command1";
        UndoRedoCommandList commandsList = null;
        MockCommand command1 = null;
            
        [SetUp]
        public void SetUp()
        {
            commandsList = new UndoRedoCommandList();
            command1 = new MockCommand();
            command1.CommandName = COMMAND_NAME1;
        }

        [Test]
        public void AddTest()
        {
            commandsList.Add(command1);

            Assert.IsTrue(commandsList.CanUndo);
            Assert.IsFalse(commandsList.CanRedo);
            Assert.AreEqual(commandsList.UndoMsg, UNDO_STRING + COMMAND_NAME1);
        }

        [Test]
        public void AddUndoTest()
        {
            commandsList.Add(command1);
            commandsList.Undo();
            Assert.IsFalse(commandsList.CanUndo);
            Assert.IsTrue(commandsList.CanRedo);
            Assert.AreEqual(commandsList.RedoMsg, REDO_STRING + COMMAND_NAME1);
        }
    }
}
