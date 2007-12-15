using System;
using System.Collections.Generic;
using System.Text;

namespace EnvManager.Commands
{
    public class CommandException : Exception
    {
        public CommandException(string message)
            : base(message)
        {

        }
    }
}
