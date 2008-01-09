/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envmng@gmail.com>

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

namespace EnvManager.Handlers
{
    public class DgvDeleteCommand : DgvCommand
    {
        DataGridViewRow row = null;

        public DgvDeleteCommand(DgvHandler dgvHandler) 
            : base(dgvHandler)
        {
            Init();
        }
        public DgvDeleteCommand ( DgvHandler dgvHandler, DataGridViewRow row )
            : base( dgvHandler )
        {
            Init();
            this.row = row;
            this.currentRowIndex = row.Index;
        }
        private void Init()
        {
            this.commandName = "Delete Value";
        }
        public override void Execute()
        {
            // execute only when row is not set, i.e. not deleted
            if ( row == null )
            {
                currentRowIndex = dgvHandler.CurrentRowIndex;
                row = dgvHandler.CurrentRow( currentRowIndex );
                Redo();
            }
        }
        public override void Undo()
        {
            dgvHandler.InsertRow( currentRowIndex, row );
        }
        public override void Redo()
        {
            dgvHandler.DeleteRow( currentRowIndex );
        }
    }
}
