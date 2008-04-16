/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envman-dev@googlegroups.com>

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

namespace EnvManager.Handlers
{
    public class DgvCommand : ICommand
    {
        protected string commandName = "";
        protected DgvHandler dgvHandler = null;
        protected int currentRowIndex = 0;
        protected int newRowIndex = 0;

        public DgvCommand(DgvHandler dgvHandler)
        {
            this.dgvHandler = dgvHandler;
        }
        public virtual string CommandName
        {
            get
            {
                return commandName;
            }
        }
        public virtual void Execute()
        {

        }

        public virtual void Undo()
        {
            dgvHandler.MoveRow(newRowIndex, currentRowIndex);
        }

        public virtual void Redo()
        {
            dgvHandler.MoveRow(currentRowIndex, newRowIndex);
        }
    }
}
