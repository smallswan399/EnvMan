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
using System.Windows.Forms;

namespace EnvManager.Commands
{
    public class DgvMoveUpCommand : DgvCommand
    {
        public DgvMoveUpCommand(DgvHandler dgvHandler) 
            : base(dgvHandler)
        {
            commandName = "Move Value Up";
        }

        #region Actions
        public override void Execute()
        {
            rowInfoList = new SortedList<int, DgvRowInfo>();
            foreach ( DataGridViewRow row in dgvHandler.SelectedRows )
            {
                DgvRowInfo rowInfo = new DgvRowInfo( row.Index, row.Index - 1 );
                rowInfoList.Add( row.Index, rowInfo );
            }
            ValidateList();

            Redo();
        }
        /// <summary>
        /// Validates the list for valid moves.
        /// </summary>
        private void ValidateList ( )
        {
            // TODO: Make a copy of IList into array or another List
            int rowIndex = -1; // Top Row
            IList<int> keyList = rowInfoList.Keys;
            int invalidRowsCount = 0;
            DgvRowInfo rowInfo;

            for ( int i = 0; i < keyList.Count; i++ )
            {
                rowInfo = rowInfoList[ keyList[ i ] ];
                if ( rowInfo.NewRowIndex <= rowIndex )
                {
                    rowIndex = rowInfo.CurrentRowIndex;
                    rowInfo.IsValid = false;
                    rowInfoList.RemoveAt( keyList[ i ] );
                    rowInfoList.Add( rowInfo.CurrentRowIndex, rowInfo );
                    invalidRowsCount++;
                }
            }

            if ( rowInfoList.Count == invalidRowsCount )
            {
                throw new CommandException( "No values were moved." );
            }
        }
        #endregion Actions
    }
}
