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
using EnvManager.Commands;

namespace EnvManager.Tests.Commands
{
    public class DgvTestDataHandler
    {
        DataGridView dgv = null;
        private DgvHandler dgvHandler = null;
        private DataGridViewImageColumn ValueType = null;
        private DataGridViewTextBoxColumn Value = null;

        public DgvTestDataHandler(ref DataGridView dgv)
        {
            this.ValueType = new System.Windows.Forms.DataGridViewImageColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dgv = dgv;
            dgv.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[ ] {
            this.ValueType,
            this.Value} );
            dgvHandler = new DgvHandler( ref dgv );
        }

        public DgvHandler DgvHanlderData
        {
            get { return dgvHandler; }
        }
    }
}