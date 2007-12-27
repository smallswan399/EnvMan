/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2007 Vlad Setchin <envmng@gmail.com>

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
    public class EditVarNameCommand : ICommand
    {
        private string currentVarName = "";
        private string newVarName = "";
        private TextBox txtBox = null;
        private string commandName = "Edit Variable Name";

        public EditVarNameCommand(TextBox txtBox)
        {
            this.txtBox = txtBox;
            currentVarName = string.Copy( txtBox.Text );
        }
        public void Execute()
        {

        }
        public void Undo()
        {
            txtBox.CausesValidation = false;
            txtBox.Text = string.Copy( currentVarName );
            txtBox.CausesValidation = true;
        }
        public void Redo()
        {
            txtBox.Text = string.Copy( newVarName );
        }
        public string CurrentVarName
        {
            get { return currentVarName; }
        }
        public string NewVarName
        {
            set { newVarName = value; }
        }
        public string CommandName
        {
            get { return commandName; }
        }
    }
}
