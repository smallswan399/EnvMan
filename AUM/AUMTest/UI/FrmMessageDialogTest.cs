using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AUM.UI;
using NUnit.Framework;

namespace AUM.Tests.UI
{
    [TestFixture]
    public partial class FrmMessageDialogTest : FrmMessageDialog
    {
        public FrmMessageDialogTest ( )
        {
            InitializeComponent();
        }

        [Test]
        public void TestOKBtn()
        {
            this.BtnClick( this.BtnOK, null );

            Assert.AreEqual( DialogResult.OK, this.DialogResult );
        }

        [Test]
        public void TestCancelBtn ( )
        {
            this.BtnClick( this.BtnCancel, null );

            Assert.AreEqual( DialogResult.Cancel, this.DialogResult );
        }
    }
}