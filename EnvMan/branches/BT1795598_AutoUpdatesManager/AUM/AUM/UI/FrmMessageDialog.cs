using System;
using System.Collections.Generic;
using System.ComponentModel;
/*
   AUM - Automated Updates Manager Tests
   Copyright (C) 2006-2008 Vlad Setchin <auto.updates.mng@gmail.com>

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

using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AUM.UI
{
    public partial class FrmMessageDialog : Form
    {
        public FrmMessageDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            set { lblMessage.Text = value; }
        }

        /// <summary>
        /// BTNs the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnClick(object sender, EventArgs e)
        {
            if (sender.Equals(btnCancel))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (sender.Equals(btnOK))
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Hide();
        }
	
    }
}