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
using System.Drawing;
using System.Windows.Forms;

namespace EnvManager.Handlers
{
    public class DgvEditCommand : DgvModifyValueCommand
    {
        public DgvEditCommand(DgvHandler dgvHandler)
            : base(dgvHandler)
        {
            commandName = "New Value";
        }
        public DgvEditCommand(DgvHandler dgvHandler, DataGridViewRow row)
            : base(dgvHandler)
        {
            commandName = "Edit Value";
            currentRow = CloneRow(row);
            currentRowIndex = row.Index;
        }
    }
}
