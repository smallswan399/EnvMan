/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>

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
    public class DgvMoveToTopCommand : DgvCommand
    {
        public DgvMoveToTopCommand(DgvHandler dgvHandler)
            : base(dgvHandler)
        {
            commandName = "Move Value to Top";
        }

        public override void Execute()
        {
            currentRowIndex = dgvHandler.CurrentRowIndex;
            newRowIndex = 0;
            Redo();
        }
    }
}
