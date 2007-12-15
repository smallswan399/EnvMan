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

namespace EnvManager.Commands
{
    /// <summary>
    /// Structure to hold DataGridView Row information
    /// </summary>
    public struct DgvRowInfo
	{
        public DgvRowInfo(int currentRowIndex, int newRowIndex)
        {
            this.currentRowIndex = currentRowIndex;
            this.newRowIndex = newRowIndex;
            this.isValid = true;
        }

        private int currentRowIndex;
        /// <summary>
        /// Gets or sets the index of the current row.
        /// </summary>
        /// <value>The index of the current row.</value>
        public int CurrentRowIndex
        {
            set
            {
                this.currentRowIndex = value;
            }
            get
            {
                return this.currentRowIndex;
            }
        }
        
        private int newRowIndex;
        /// <summary>
        /// Gets or sets the index of the new row.
        /// </summary>
        /// <value>The new index of the row.</value>
        public int NewRowIndex
        {
            get { return newRowIndex; }
            set { newRowIndex = value; }
        }

        private bool isValid;
        /// <summary>
        /// Gets or sets a value indicating whether this DGV Row Info is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }
	
	}
}
