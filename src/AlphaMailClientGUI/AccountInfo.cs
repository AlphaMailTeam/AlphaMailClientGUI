using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AlphaMailClient;
using AlphaMailClient.AlphaMailClient;

namespace AlphaMailClientGUI
{
    public partial class AccountInfo : Form
    {
        public AccountInfo(AlphaMailConfig config)
        {
            InitializeComponent();

            accountNameTextBox.Text = config.Username;
            accountPasswordTextBox.Text = config.Password;

            publicKeyTextBox.Text = config.KeyPair.PublicKey.Key.ToString();
            eTextBox.Text = config.KeyPair.PublicKey.E.ToString();
            privateKeyTextBox.Text = config.KeyPair.PrivateKey.Key.ToString();

            serverTextBox.Text = config.Server;
            portTextBox.Text = config.Port.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
