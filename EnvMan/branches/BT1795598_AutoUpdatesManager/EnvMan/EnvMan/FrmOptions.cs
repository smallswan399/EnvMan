using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EnvMan.Properties;
using System.Configuration;

namespace EnvMan
{
    public partial class FrmOptions : Form
    {
        private const string DEFAULT_PROXY_PORT = "80";
        private ProxySettings proxySettings = ProxySettings.Default;
        private FrmMainSettings mainFormSettings = FrmMainSettings.Default;

        public FrmOptions()
        {
            InitializeComponent();

            LoadSettings();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CbUseProxy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            LblAddress.Enabled = CbUseProxy.Checked;
            TxtAddress.Enabled = CbUseProxy.Checked;
            LblPassword.Enabled = CbUseProxy.Checked;
            TxtPassword.Enabled = CbUseProxy.Checked;
            LblPasswordOptional.Enabled = CbUseProxy.Checked;
            LblPort.Enabled = CbUseProxy.Checked;
            TxtPort.Enabled = CbUseProxy.Checked;
            LblUserName.Enabled = CbUseProxy.Checked;
            TxtUserName.Enabled = CbUseProxy.Checked;
            LblUserNameOptional.Enabled = CbUseProxy.Checked;

            if (!CbUseProxy.Checked)
            {
                InitProxySettings();
            }
            else
            {
                LoadProxySettings();
            }
        }

        /// <summary>
        /// Clears proxy settings.
        /// </summary>
        private void InitProxySettings()
        {
            TxtAddress.Text = string.Empty;
            TxtPort.Text = DEFAULT_PROXY_PORT;
            TxtUserName.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            this.CbOneInstance.Checked = mainFormSettings.OnlyOneInstance;
            this.CbUseProxy.Checked = proxySettings.UseProxy;
            if (proxySettings.UseProxy)
            {
                LoadProxySettings();
            }
        }

        private void LoadProxySettings()
        {
            TxtAddress.Text = proxySettings.ServerAddress;
            TxtPort.Text = string.Empty + proxySettings.ServerPort;
            TxtUserName.Text = proxySettings.ServerUserName;
            TxtPassword.Text = proxySettings.ServerPassword; 
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            this.mainFormSettings.OnlyOneInstance = CbOneInstance.Checked;

            // Proxy settings
            proxySettings.UseProxy = CbUseProxy.Checked;
            proxySettings.ServerAddress = TxtAddress.Text;
            proxySettings.ServerPort = TxtPort.Text;
            proxySettings.ServerUserName = TxtUserName.Text;
            proxySettings.ServerPassword = TxtPassword.Text;
            proxySettings.Save();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validate controls
            CancelEventArgs cancelEvent = new CancelEventArgs();
            TxtValidating(TxtAddress, cancelEvent);
                       
            if (!cancelEvent.Cancel)
            {
                SaveSettings();
                this.Close(); 
            }
        }

        /// <summary>
        /// Validating Text Boxes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void TxtValidating(object sender, CancelEventArgs e)
        {
            // Validate Proxy
            if (CbUseProxy.Checked)
            {
                if (sender.Equals(TxtAddress))
                {
                    if (TxtAddress.Text == string.Empty)
                    {
                        errorProvider.SetError(TxtAddress, "Address Cannot be Empty");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.Clear();
                    }
                }
                else if (sender.Equals(TxtPort))
                {
                    if (TxtPort.Text == string.Empty)
                    {
                        errorProvider.SetError(TxtPort, "Server Port cannot be empty");
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
