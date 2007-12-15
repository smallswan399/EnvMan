using System;
using System.Collections.Generic;
using System.Text;

using EnvManager.Handlers;

namespace EnvManager.Tests.Handlers
{
    public class MockCommand : ICommand
    {
        private string commandName;

        public string CommandName
        {
            get { return commandName; }
            set { commandName = value; }
        }

        public void Execute()
        {

        }
        public void Undo()
        {

        }
        public void Redo()
        {

        }
    }
}
