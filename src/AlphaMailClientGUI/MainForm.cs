using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AlphaMailClient;
using AlphaMailClient.AlphaMailClient;

namespace AlphaMailClientGUI
{
    public partial class MainForm : Form
    {
        private AlphaMailClient.AlphaMailClient.AlphaMailClient client;
        private AlphaMailConfig config;
        private bool loggedIn = false;

        public MainForm(string[] args)
        {
            InitializeComponent();

            string configFilePath;
            string defaultConfigPath = string.Format("{0}\\account.conf", Directory.GetCurrentDirectory());
            if (File.Exists(defaultConfigPath))
                configFilePath = defaultConfigPath;
            else
            {
                if (args.Length == 0)
                {

                    do
                    {
                        var result = configFileOpener.ShowDialog();
                        if (result == DialogResult.Cancel)
                            Environment.Exit(0);
                    }
                    while (!File.Exists(configFileOpener.FileName));
                    configFilePath = configFileOpener.FileName;
                }
                else
                {
                    if (!File.Exists(args[0]))
                    {
                        do
                        {
                            var result = configFileOpener.ShowDialog();
                            if (result == DialogResult.Cancel)
                                Environment.Exit(0);
                        }
                        while (!File.Exists(configFileOpener.FileName));
                        configFilePath = configFileOpener.FileName;
                    }
                    else
                        configFilePath = args[0];
                }
            }

            config = AlphaMailConfig.FromFile(configFilePath);
            client = new AlphaMailClient.AlphaMailClient.AlphaMailClient(config.Server, config.Port, config.KeyPair);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var result = client.Login(config.Username, config.Password);
            if (result == AuthResultCode.LoginSuccess)
            {
                this.Text = string.Format("AlphaMailClientGUI - Logged In ({0})", config.Username);
                loggedIn = true;
            }
            displayAuthResultCode(result);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var result = client.Register(config.Username, config.Password);
            displayAuthResultCode(result);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (!loggedIn)
            {
                displayAuthResultCode(AuthResultCode.NotAuthenticated);
                return;
            }

            var result = client.CheckForMessages();

            if (result.Length == 0)
                appendLine(ResponseConstants.NO_NEW_MESSAGES);
            else
            {
                foreach (var message in result)
                {
                    appendLine("Sender: {0}", message.Sender);
                    appendLine("To: {0}", message.Recipient);
                    appendLine("Subject: {0}", message.Subject);
                    appendLine("Message:\n{0}", message.MessageString);
                    appendLine();
                }
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!loggedIn)
            {
                displayAuthResultCode(AuthResultCode.NotAuthenticated);
                return;
            }

            var senderForm = new MessageSenderForm();
            var result = senderForm.ShowDialog();

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.OK:
                    var message = senderForm.Message;
                    var resultCode = client.SendMessage(message.Recipient, message.Subject, message.MessageString);
                    displayMessageResultCode(resultCode);
                    break;
            }
        }

        private void openConfigMenuItem_Click(object sender, EventArgs e)
        {
            var result = configFileOpener.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            if (!File.Exists(configFileOpener.FileName))
                return;

            config = AlphaMailConfig.FromFile(configFileOpener.FileName);
            client = new AlphaMailClient.AlphaMailClient.AlphaMailClient(config.Server, config.Port, config.KeyPair);

            this.Text = "AlphaMailClientGUI - Not Logged In";
            loggedIn = false;
        }

        private void exitApplicationMenuItem_Click(object sender, EventArgs e)
        {
            client = null;
            Environment.Exit(0);
        }

        private void accountInfoMenuItem_Click(object sender, EventArgs e)
        {
            new AccountInfo(config).ShowDialog();
        }

        private void appendLine(string linef = "", params object[] args)
        {
            if (args.Length == 0)
                mainFeed.Text += string.Format("{0}\n", linef);
            else
                mainFeed.Text += string.Format(linef + "\n", args);
        }

        private void clear()
        {
            mainFeed.Text = string.Empty;
        }

        private void displayAuthResultCode(AuthResultCode result)
        {
            string message;

            switch (result)
            {
                case AuthResultCode.LoginBadPassword:
                    message = ResponseConstants.LOGIN_BAD_PASSWORD;
                    break;
                case AuthResultCode.LoginBadUser:
                    message = ResponseConstants.LOGIN_BAD_USERNAME;
                    break;
                case AuthResultCode.LoginSuccess:
                    message = ResponseConstants.LOGIN_SUCCESS;
                    break;
                case AuthResultCode.NotAuthenticated:
                    message = ResponseConstants.NOT_AUTHENTICATED;
                    break;
                case AuthResultCode.RegisterBadUser:
                    message = ResponseConstants.REGISTER_BAD_USER;
                    break;
                case AuthResultCode.RegisterSuccess:
                    message = ResponseConstants.REGISTER_SUCCESS;
                    break;
                default:
                    message = ResponseConstants.UNKNOWN_ERROR;
                    break;
            }

            MessageBox.Show(message);
        }

        private void displayMessageResultCode(MessageResultCode result)
        {
            string message;

            switch (result)
            {
                case MessageResultCode.MessageSuccess:
                    message = ResponseConstants.MESSAGE_SUCCESS;
                    break;
                case MessageResultCode.NoUser:
                    message = ResponseConstants.MESSAGE_NO_USER;
                    break;
                default:
                    message = ResponseConstants.UNKNOWN_ERROR;
                    break;
            }

            MessageBox.Show(message);
        }
    }
}
