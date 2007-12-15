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

namespace EnvManager.Commands
{
    public class DgvCommand : ICommand
    {
        protected string commandName = "";
        protected DgvHandler dgvHandler = null;
        protected SortedList<int, DgvRowInfo> rowInfoList = null;
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
            DgvRowInfo rowInfo;
            foreach ( KeyValuePair<int,DgvRowInfo> kvp in rowInfoList )
            {
                rowInfo = kvp.Value;
                dgvHandler.MoveRow( rowInfo.NewRowIndex, rowInfo.CurrentRowIndex );    
            }
            
        }

        public virtual void Redo()
        {
            DgvRowInfo rowInfo;
            foreach ( KeyValuePair<int,DgvRowInfo> kvp in rowInfoList )
            {
                rowInfo = kvp.Value;
                dgvHandler.MoveRow( rowInfo.CurrentRowIndex, rowInfo.NewRowIndex );
            }
        }
    }
}
