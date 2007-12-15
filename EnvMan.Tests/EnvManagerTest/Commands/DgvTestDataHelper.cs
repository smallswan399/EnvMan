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
