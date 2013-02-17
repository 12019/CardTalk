namespace CardTalk
{
    partial class CardTalk
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
            this.buttonRefreshReaderList = new System.Windows.Forms.Button();
            this.labelReaders = new System.Windows.Forms.Label();
            this.comboBoxReadersList = new System.Windows.Forms.ComboBox();
            this.labelATR = new System.Windows.Forms.Label();
            this.textBoxATR = new System.Windows.Forms.TextBox();
            this.buttonRefreshATR = new System.Windows.Forms.Button();
            this.buttonAnalyseATR = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.richTextBoxRunningLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxRunningLog = new System.Windows.Forms.GroupBox();
            this.tabControlActions = new System.Windows.Forms.TabControl();
            this.tabPageSendSingleCmd = new System.Windows.Forms.TabPage();
            this.tabPageSendMultipleCommands = new System.Windows.Forms.TabPage();
            this.tabPageExecuteScript = new System.Windows.Forms.TabPage();
            this.tabPageExecuteTransaction = new System.Windows.Forms.TabPage();
            this.groupBoxRunningLog.SuspendLayout();
            this.tabControlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRefreshReaderList
            // 
            this.buttonRefreshReaderList.Location = new System.Drawing.Point(745, 22);
            this.buttonRefreshReaderList.Name = "buttonRefreshReaderList";
            this.buttonRefreshReaderList.Size = new System.Drawing.Size(75, 27);
            this.buttonRefreshReaderList.TabIndex = 0;
            this.buttonRefreshReaderList.Text = "Refresh";
            this.buttonRefreshReaderList.UseVisualStyleBackColor = true;
            this.buttonRefreshReaderList.Click += new System.EventHandler(this.buttonRefreshReaderList_Click);
            // 
            // labelReaders
            // 
            this.labelReaders.AutoSize = true;
            this.labelReaders.Location = new System.Drawing.Point(17, 28);
            this.labelReaders.Name = "labelReaders";
            this.labelReaders.Size = new System.Drawing.Size(107, 15);
            this.labelReaders.TabIndex = 1;
            this.labelReaders.Text = "Smart Card Readers";
            // 
            // comboBoxReadersList
            // 
            this.comboBoxReadersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReadersList.FormattingEnabled = true;
            this.comboBoxReadersList.Location = new System.Drawing.Point(130, 25);
            this.comboBoxReadersList.Name = "comboBoxReadersList";
            this.comboBoxReadersList.Size = new System.Drawing.Size(551, 23);
            this.comboBoxReadersList.TabIndex = 2;
            // 
            // labelATR
            // 
            this.labelATR.AutoSize = true;
            this.labelATR.Location = new System.Drawing.Point(17, 76);
            this.labelATR.Name = "labelATR";
            this.labelATR.Size = new System.Drawing.Size(27, 15);
            this.labelATR.TabIndex = 3;
            this.labelATR.Text = "ATR";
            // 
            // textBoxATR
            // 
            this.textBoxATR.Location = new System.Drawing.Point(130, 72);
            this.textBoxATR.Name = "textBoxATR";
            this.textBoxATR.Size = new System.Drawing.Size(551, 22);
            this.textBoxATR.TabIndex = 4;
            // 
            // buttonRefreshATR
            // 
            this.buttonRefreshATR.Location = new System.Drawing.Point(745, 72);
            this.buttonRefreshATR.Name = "buttonRefreshATR";
            this.buttonRefreshATR.Size = new System.Drawing.Size(89, 23);
            this.buttonRefreshATR.TabIndex = 5;
            this.buttonRefreshATR.Text = "Get ATR";
            this.buttonRefreshATR.UseVisualStyleBackColor = true;
            this.buttonRefreshATR.Click += new System.EventHandler(this.buttonRefreshATR_Click);
            // 
            // buttonAnalyseATR
            // 
            this.buttonAnalyseATR.Location = new System.Drawing.Point(852, 72);
            this.buttonAnalyseATR.Name = "buttonAnalyseATR";
            this.buttonAnalyseATR.Size = new System.Drawing.Size(89, 23);
            this.buttonAnalyseATR.TabIndex = 6;
            this.buttonAnalyseATR.Text = "Analyze ATR";
            this.buttonAnalyseATR.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(205, 517);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // richTextBoxRunningLog
            // 
            this.richTextBoxRunningLog.Location = new System.Drawing.Point(6, 21);
            this.richTextBoxRunningLog.Name = "richTextBoxRunningLog";
            this.richTextBoxRunningLog.Size = new System.Drawing.Size(410, 331);
            this.richTextBoxRunningLog.TabIndex = 8;
            this.richTextBoxRunningLog.Text = "";
            // 
            // groupBoxRunningLog
            // 
            this.groupBoxRunningLog.Controls.Add(this.richTextBoxRunningLog);
            this.groupBoxRunningLog.Location = new System.Drawing.Point(20, 123);
            this.groupBoxRunningLog.Name = "groupBoxRunningLog";
            this.groupBoxRunningLog.Size = new System.Drawing.Size(422, 358);
            this.groupBoxRunningLog.TabIndex = 9;
            this.groupBoxRunningLog.TabStop = false;
            this.groupBoxRunningLog.Text = "Running Log";
            // 
            // tabControlActions
            // 
            this.tabControlActions.Controls.Add(this.tabPageSendSingleCmd);
            this.tabControlActions.Controls.Add(this.tabPageSendMultipleCommands);
            this.tabControlActions.Controls.Add(this.tabPageExecuteScript);
            this.tabControlActions.Controls.Add(this.tabPageExecuteTransaction);
            this.tabControlActions.Location = new System.Drawing.Point(477, 143);
            this.tabControlActions.Name = "tabControlActions";
            this.tabControlActions.SelectedIndex = 0;
            this.tabControlActions.Size = new System.Drawing.Size(482, 332);
            this.tabControlActions.TabIndex = 10;
            // 
            // tabPageSendSingleCmd
            // 
            this.tabPageSendSingleCmd.Location = new System.Drawing.Point(4, 24);
            this.tabPageSendSingleCmd.Name = "tabPageSendSingleCmd";
            this.tabPageSendSingleCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendSingleCmd.Size = new System.Drawing.Size(474, 304);
            this.tabPageSendSingleCmd.TabIndex = 0;
            this.tabPageSendSingleCmd.Text = "Send Command";
            this.tabPageSendSingleCmd.UseVisualStyleBackColor = true;
            // 
            // tabPageSendMultipleCommands
            // 
            this.tabPageSendMultipleCommands.Location = new System.Drawing.Point(4, 24);
            this.tabPageSendMultipleCommands.Name = "tabPageSendMultipleCommands";
            this.tabPageSendMultipleCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendMultipleCommands.Size = new System.Drawing.Size(379, 304);
            this.tabPageSendMultipleCommands.TabIndex = 1;
            this.tabPageSendMultipleCommands.Text = "Send Commands";
            this.tabPageSendMultipleCommands.UseVisualStyleBackColor = true;
            // 
            // tabPageExecuteScript
            // 
            this.tabPageExecuteScript.Location = new System.Drawing.Point(4, 24);
            this.tabPageExecuteScript.Name = "tabPageExecuteScript";
            this.tabPageExecuteScript.Size = new System.Drawing.Size(474, 304);
            this.tabPageExecuteScript.TabIndex = 2;
            this.tabPageExecuteScript.Text = "Execute Script";
            this.tabPageExecuteScript.UseVisualStyleBackColor = true;
            // 
            // tabPageExecuteTransaction
            // 
            this.tabPageExecuteTransaction.Location = new System.Drawing.Point(4, 24);
            this.tabPageExecuteTransaction.Name = "tabPageExecuteTransaction";
            this.tabPageExecuteTransaction.Size = new System.Drawing.Size(474, 304);
            this.tabPageExecuteTransaction.TabIndex = 3;
            this.tabPageExecuteTransaction.Text = "Execute Transaction";
            this.tabPageExecuteTransaction.UseVisualStyleBackColor = true;
            // 
            // CardTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 605);
            this.Controls.Add(this.tabControlActions);
            this.Controls.Add(this.groupBoxRunningLog);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAnalyseATR);
            this.Controls.Add(this.buttonRefreshATR);
            this.Controls.Add(this.textBoxATR);
            this.Controls.Add(this.labelATR);
            this.Controls.Add(this.comboBoxReadersList);
            this.Controls.Add(this.labelReaders);
            this.Controls.Add(this.buttonRefreshReaderList);
            this.Font = new System.Drawing.Font("Segoe WP Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CardTalk";
            this.Text = "Card Talk";
            this.groupBoxRunningLog.ResumeLayout(false);
            this.tabControlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefreshReaderList;
        private System.Windows.Forms.Label labelReaders;
        private System.Windows.Forms.ComboBox comboBoxReadersList;
        private System.Windows.Forms.Label labelATR;
        private System.Windows.Forms.TextBox textBoxATR;
        private System.Windows.Forms.Button buttonRefreshATR;
        private System.Windows.Forms.Button buttonAnalyseATR;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.RichTextBox richTextBoxRunningLog;
        private System.Windows.Forms.GroupBox groupBoxRunningLog;
        private System.Windows.Forms.TabControl tabControlActions;
        private System.Windows.Forms.TabPage tabPageSendSingleCmd;
        private System.Windows.Forms.TabPage tabPageSendMultipleCommands;
        private System.Windows.Forms.TabPage tabPageExecuteScript;
        private System.Windows.Forms.TabPage tabPageExecuteTransaction;
    }
}

