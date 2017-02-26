using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AlphaMailClient;
using AlphaMailClient.AlphaMailClient;

namespace AlphaMailClientGUI
{
    public partial class MessageSenderForm : Form
    {
        private const string INVALID_INPUT_ERROR = "Error! Please check that you have entered a recipient and a message body!";

        public AlphaMailMessage Message { get; private set; }

        public MessageSenderForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!validateMessage())
            {
                MessageBox.Show(INVALID_INPUT_ERROR);
                return;
            }

            Message = new AlphaMailMessage(string.Empty, subjectBox.Text, recipientBox.Text, messageBodyBox.Text);
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private bool validateMessage()
        {
            if (recipientBox.Text.Trim() == string.Empty)
                return false;
            if (messageBodyBox.Text.Trim() == string.Empty)
                return false;
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
