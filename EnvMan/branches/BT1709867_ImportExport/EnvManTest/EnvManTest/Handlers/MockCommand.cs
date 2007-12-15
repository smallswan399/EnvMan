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
            // To be 100% in code coverage
            Execute();
        }
    }
}
