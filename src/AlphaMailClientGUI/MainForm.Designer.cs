namespace AlphaMailClientGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.mainFeed = new System.Windows.Forms.RichTextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.configFileOpener = new System.Windows.Forms.OpenFileDialog();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(416, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(497, 12);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // mainFeed
            // 
            this.mainFeed.Location = new System.Drawing.Point(167, 41);
            this.mainFeed.Name = "mainFeed";
            this.mainFeed.Size = new System.Drawing.Size(405, 334);
            this.mainFeed.TabIndex = 2;
            this.mainFeed.Text = "";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(12, 41);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // configFileOpener
            // 
            this.configFileOpener.FileName = "*.conf";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(12, 96);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 428);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.mainFeed);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Name = "MainForm";
            this.Text = "AlphaMailClientGUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.RichTextBox mainFeed;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.OpenFileDialog configFileOpener;
        private System.Windows.Forms.Button sendButton;
    }
}

