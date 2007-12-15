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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EnvManager.Commands
{
    /// <summary>
    /// Responsible for Redo, Undo of moving values down.
    /// </summary>
    public class DgvMoveDownCommand : DgvCommand
    {
        public DgvMoveDownCommand(DgvHandler dgvHandler) 
            : base(dgvHandler)
        {
            commandName = "Move Value Down";
        }

        #region Actions
        /// <summary>
        /// Saves selected values and calls validate for valid moves.
        /// </summary>
        public override void Execute()
        {
            rowInfoList = new SortedList<int,DgvRowInfo>();
            foreach ( DataGridViewRow row in dgvHandler.SelectedRows )
            {
                DgvRowInfo rowInfo = new DgvRowInfo(row.Index, row.Index + 1);
                rowInfoList.Add(row.Index, rowInfo );
            }
            ValidateList();
            
            Redo();
        }
        /// <summary>
        /// Validates the list for valid moves.
        /// </summary>
        private void ValidateList()
        {
            DgvRowInfo rowInfo;
            // walk through the list in revers order
            IList<int> keyList = rowInfoList.Keys;
            int rowIndex = dgvHandler.BottomRowIndex + 1;
            for (int i = keyList.Count - 1; i >= 0; i--)
            {
                rowInfo = rowInfoList[keyList[i]];
                if (rowInfo.NewRowIndex >= rowIndex)
                {
                    rowIndex = rowInfo.CurrentRowIndex;
                    rowInfoList.RemoveAt(i);
                }
            }

            if (rowInfoList.Count == 0)
            {
                throw new CommandException("No values were moved.");
            }
        }
        /// <summary>
        /// Executes redo for each value in the list.
        /// </summary>
        public override void Redo()
        {
            DgvRowInfo rowInfo;
            // walk through the list in revers order
            IList<int> keyList = rowInfoList.Keys;
            for (int i = keyList.Count - 1; i >= 0; i--)
            {
                rowInfo = rowInfoList[keyList[i]];
                dgvHandler.MoveRow(rowInfo.CurrentRowIndex, rowInfo.NewRowIndex);
            }
        }
        #endregion Actions
    }
}
