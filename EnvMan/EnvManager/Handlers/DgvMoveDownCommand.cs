/*
  EnvMan - The Open-Source Windows Environment Variables Manager
  Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace EnvManager.Handlers
{
    public class DgvMoveDownCommand : DgvCommand
    {
        public DgvMoveDownCommand(DgvHandler dgvHandler) 
            : base(dgvHandler)
        {
            commandName = "Move Value Down";
        }

        #region Actions
        public override void Execute()
        {
            currentRowIndex = dgvHandler.CurrentRowIndex;
            newRowIndex = currentRowIndex + 1;
            Redo();
        }
        #endregion Actions
    }
}
