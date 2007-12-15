using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EnvManager.Handlers
{
    public class DgvModifyValueCommand : DgvCommand
    {
        protected DataGridViewRow currentRow = null;
        protected DataGridViewRow newRow = null;

        public DgvModifyValueCommand(DgvHandler dgvHandler)
            : base(dgvHandler)
        {

        }

        protected DataGridViewRow CloneRow(DataGridViewRow row)
        {
            DataGridViewRow newRow = row.Clone() as DataGridViewRow;
            newRow.Cells[0].Value = new Bitmap(row.Cells[0].Value as Bitmap);
            newRow.Cells[1].Value = string.Copy(row.Cells[1].Value as String);

            return newRow;
        }

        public override void Undo()
        {
            Console.WriteLine("Undo New Row: " + newRow.Cells[1].Value.ToString());
            dgvHandler.DeleteRow(newRowIndex);
            if (currentRow != null)
            {
                Console.WriteLine("Write Old Row: " + currentRow.Cells[1].Value.ToString());
                dgvHandler.InsertRow(currentRowIndex, CloneRow(currentRow));
            }
        }
        public override void Redo()
        {
            if (currentRow != null)
            {
                dgvHandler.DeleteRow(currentRowIndex);
            }
            dgvHandler.InsertRow(newRowIndex, CloneRow(newRow));
        }

        public DataGridViewRow CurrentRow
        {
            get
            {
                return currentRow;
            }
        }
        public DataGridViewRow NewRow
        {
            set
            {
                newRow = CloneRow(value);
                newRowIndex = value.Index;
            }
        }
    }
}
