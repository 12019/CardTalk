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
            this.textBoxATR = new System.Windows.Forms.TextBox();
            this.buttonRefreshATR = new System.Windows.Forms.Button();
            this.buttonAnalyseATR = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.richTextBoxRunningLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxRunningLog = new System.Windows.Forms.GroupBox();
            this.tabControlActions = new System.Windows.Forms.TabControl();
            this.tabPageATR = new System.Windows.Forms.TabPage();
            this.tabPageSendSingleCmd = new System.Windows.Forms.TabPage();
            this.labelCmdDataNumBytes = new System.Windows.Forms.Label();
            this.labelRespDataLen = new System.Windows.Forms.Label();
            this.richTextBoxRespData = new System.Windows.Forms.RichTextBox();
            this.labelRespData = new System.Windows.Forms.Label();
            this.textBoxSw1Sw2 = new System.Windows.Forms.TextBox();
            this.labelStatusWord = new System.Windows.Forms.Label();
            this.textBoxRespData = new System.Windows.Forms.TextBox();
            this.labelResp = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxCompleteCmd = new System.Windows.Forms.TextBox();
            this.labelCmd = new System.Windows.Forms.Label();
            this.textBoxLe = new System.Windows.Forms.TextBox();
            this.labelLe = new System.Windows.Forms.Label();
            this.textBoxCmdData = new System.Windows.Forms.TextBox();
            this.labelCmdData = new System.Windows.Forms.Label();
            this.textBoxP3Lc = new System.Windows.Forms.TextBox();
            this.textBoxP2 = new System.Windows.Forms.TextBox();
            this.textBoxP1 = new System.Windows.Forms.TextBox();
            this.textBoxINS = new System.Windows.Forms.TextBox();
            this.textBoxCLA = new System.Windows.Forms.TextBox();
            this.labelP3Lc = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.labelP1 = new System.Windows.Forms.Label();
            this.labelINS = new System.Windows.Forms.Label();
            this.labelCLA = new System.Windows.Forms.Label();
            this.comboBoxKnownCommands = new System.Windows.Forms.ComboBox();
            this.labelKnownCommands = new System.Windows.Forms.Label();
            this.tabPageSendMultipleCommands = new System.Windows.Forms.TabPage();
            this.tabPageExecuteScript = new System.Windows.Forms.TabPage();
            this.tabPageExecuteTransaction = new System.Windows.Forms.TabPage();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.richTextBoxAnalysedATR = new System.Windows.Forms.RichTextBox();
            this.groupBoxRunningLog.SuspendLayout();
            this.tabControlActions.SuspendLayout();
            this.tabPageATR.SuspendLayout();
            this.tabPageSendSingleCmd.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRefreshReaderList
            // 
            this.buttonRefreshReaderList.Location = new System.Drawing.Point(643, 23);
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
            this.comboBoxReadersList.Size = new System.Drawing.Size(479, 23);
            this.comboBoxReadersList.TabIndex = 2;
            this.comboBoxReadersList.SelectedIndexChanged += new System.EventHandler(this.comboBoxReaderSelected);
            // 
            // textBoxATR
            // 
            this.textBoxATR.Location = new System.Drawing.Point(17, 15);
            this.textBoxATR.Name = "textBoxATR";
            this.textBoxATR.Size = new System.Drawing.Size(539, 22);
            this.textBoxATR.TabIndex = 4;
            this.textBoxATR.TextChanged += new System.EventHandler(this.haveATR);
            // 
            // buttonRefreshATR
            // 
            this.buttonRefreshATR.Location = new System.Drawing.Point(89, 46);
            this.buttonRefreshATR.Name = "buttonRefreshATR";
            this.buttonRefreshATR.Size = new System.Drawing.Size(89, 23);
            this.buttonRefreshATR.TabIndex = 5;
            this.buttonRefreshATR.Text = "Get ATR";
            this.buttonRefreshATR.UseVisualStyleBackColor = true;
            this.buttonRefreshATR.Click += new System.EventHandler(this.buttonRefreshATR_Click);
            // 
            // buttonAnalyseATR
            // 
            this.buttonAnalyseATR.Enabled = false;
            this.buttonAnalyseATR.Location = new System.Drawing.Point(395, 46);
            this.buttonAnalyseATR.Name = "buttonAnalyseATR";
            this.buttonAnalyseATR.Size = new System.Drawing.Size(89, 23);
            this.buttonAnalyseATR.TabIndex = 6;
            this.buttonAnalyseATR.Text = "Analyze ATR";
            this.buttonAnalyseATR.UseVisualStyleBackColor = true;
            this.buttonAnalyseATR.Click += new System.EventHandler(this.buttonAnalyseATR_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(554, 685);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // richTextBoxRunningLog
            // 
            this.richTextBoxRunningLog.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxRunningLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxRunningLog.Location = new System.Drawing.Point(4, 21);
            this.richTextBoxRunningLog.Name = "richTextBoxRunningLog";
            this.richTextBoxRunningLog.ReadOnly = true;
            this.richTextBoxRunningLog.Size = new System.Drawing.Size(584, 587);
            this.richTextBoxRunningLog.TabIndex = 8;
            this.richTextBoxRunningLog.Text = "";
            // 
            // groupBoxRunningLog
            // 
            this.groupBoxRunningLog.Controls.Add(this.richTextBoxRunningLog);
            this.groupBoxRunningLog.Location = new System.Drawing.Point(17, 54);
            this.groupBoxRunningLog.Name = "groupBoxRunningLog";
            this.groupBoxRunningLog.Size = new System.Drawing.Size(592, 614);
            this.groupBoxRunningLog.TabIndex = 9;
            this.groupBoxRunningLog.TabStop = false;
            this.groupBoxRunningLog.Text = "Running Log";
            // 
            // tabControlActions
            // 
            this.tabControlActions.Controls.Add(this.tabPageATR);
            this.tabControlActions.Controls.Add(this.tabPageSendSingleCmd);
            this.tabControlActions.Controls.Add(this.tabPageSendMultipleCommands);
            this.tabControlActions.Controls.Add(this.tabPageExecuteScript);
            this.tabControlActions.Controls.Add(this.tabPageExecuteTransaction);
            this.tabControlActions.Location = new System.Drawing.Point(6, 21);
            this.tabControlActions.Name = "tabControlActions";
            this.tabControlActions.SelectedIndex = 0;
            this.tabControlActions.Size = new System.Drawing.Size(580, 587);
            this.tabControlActions.TabIndex = 10;
            // 
            // tabPageATR
            // 
            this.tabPageATR.Controls.Add(this.richTextBoxAnalysedATR);
            this.tabPageATR.Controls.Add(this.textBoxATR);
            this.tabPageATR.Controls.Add(this.buttonRefreshATR);
            this.tabPageATR.Controls.Add(this.buttonAnalyseATR);
            this.tabPageATR.Location = new System.Drawing.Point(4, 24);
            this.tabPageATR.Name = "tabPageATR";
            this.tabPageATR.Size = new System.Drawing.Size(572, 559);
            this.tabPageATR.TabIndex = 4;
            this.tabPageATR.Text = "ATR";
            this.tabPageATR.UseVisualStyleBackColor = true;
            // 
            // tabPageSendSingleCmd
            // 
            this.tabPageSendSingleCmd.Controls.Add(this.labelCmdDataNumBytes);
            this.tabPageSendSingleCmd.Controls.Add(this.labelRespDataLen);
            this.tabPageSendSingleCmd.Controls.Add(this.richTextBoxRespData);
            this.tabPageSendSingleCmd.Controls.Add(this.labelRespData);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxSw1Sw2);
            this.tabPageSendSingleCmd.Controls.Add(this.labelStatusWord);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxRespData);
            this.tabPageSendSingleCmd.Controls.Add(this.labelResp);
            this.tabPageSendSingleCmd.Controls.Add(this.buttonSend);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxCompleteCmd);
            this.tabPageSendSingleCmd.Controls.Add(this.labelCmd);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxLe);
            this.tabPageSendSingleCmd.Controls.Add(this.labelLe);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxCmdData);
            this.tabPageSendSingleCmd.Controls.Add(this.labelCmdData);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxP3Lc);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxP2);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxP1);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxINS);
            this.tabPageSendSingleCmd.Controls.Add(this.textBoxCLA);
            this.tabPageSendSingleCmd.Controls.Add(this.labelP3Lc);
            this.tabPageSendSingleCmd.Controls.Add(this.labelP2);
            this.tabPageSendSingleCmd.Controls.Add(this.labelP1);
            this.tabPageSendSingleCmd.Controls.Add(this.labelINS);
            this.tabPageSendSingleCmd.Controls.Add(this.labelCLA);
            this.tabPageSendSingleCmd.Controls.Add(this.comboBoxKnownCommands);
            this.tabPageSendSingleCmd.Controls.Add(this.labelKnownCommands);
            this.tabPageSendSingleCmd.Location = new System.Drawing.Point(4, 24);
            this.tabPageSendSingleCmd.Name = "tabPageSendSingleCmd";
            this.tabPageSendSingleCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendSingleCmd.Size = new System.Drawing.Size(572, 559);
            this.tabPageSendSingleCmd.TabIndex = 0;
            this.tabPageSendSingleCmd.Text = "Send Command";
            this.tabPageSendSingleCmd.UseVisualStyleBackColor = true;
            // 
            // labelCmdDataNumBytes
            // 
            this.labelCmdDataNumBytes.AutoSize = true;
            this.labelCmdDataNumBytes.Location = new System.Drawing.Point(111, 110);
            this.labelCmdDataNumBytes.Name = "labelCmdDataNumBytes";
            this.labelCmdDataNumBytes.Size = new System.Drawing.Size(0, 15);
            this.labelCmdDataNumBytes.TabIndex = 26;
            // 
            // labelRespDataLen
            // 
            this.labelRespDataLen.AutoSize = true;
            this.labelRespDataLen.Location = new System.Drawing.Point(103, 344);
            this.labelRespDataLen.Name = "labelRespDataLen";
            this.labelRespDataLen.Size = new System.Drawing.Size(0, 15);
            this.labelRespDataLen.TabIndex = 25;
            // 
            // richTextBoxRespData
            // 
            this.richTextBoxRespData.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxRespData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxRespData.Location = new System.Drawing.Point(10, 362);
            this.richTextBoxRespData.Name = "richTextBoxRespData";
            this.richTextBoxRespData.ReadOnly = true;
            this.richTextBoxRespData.Size = new System.Drawing.Size(486, 180);
            this.richTextBoxRespData.TabIndex = 24;
            this.richTextBoxRespData.Text = "";
            // 
            // labelRespData
            // 
            this.labelRespData.AutoSize = true;
            this.labelRespData.Location = new System.Drawing.Point(10, 344);
            this.labelRespData.Name = "labelRespData";
            this.labelRespData.Size = new System.Drawing.Size(83, 15);
            this.labelRespData.TabIndex = 23;
            this.labelRespData.Text = "Response Data";
            // 
            // textBoxSw1Sw2
            // 
            this.textBoxSw1Sw2.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSw1Sw2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSw1Sw2.Location = new System.Drawing.Point(502, 362);
            this.textBoxSw1Sw2.Name = "textBoxSw1Sw2";
            this.textBoxSw1Sw2.ReadOnly = true;
            this.textBoxSw1Sw2.Size = new System.Drawing.Size(60, 20);
            this.textBoxSw1Sw2.TabIndex = 22;
            this.textBoxSw1Sw2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStatusWord
            // 
            this.labelStatusWord.AutoSize = true;
            this.labelStatusWord.Location = new System.Drawing.Point(511, 344);
            this.labelStatusWord.Name = "labelStatusWord";
            this.labelStatusWord.Size = new System.Drawing.Size(51, 15);
            this.labelStatusWord.TabIndex = 21;
            this.labelStatusWord.Text = "SW1SW2";
            // 
            // textBoxRespData
            // 
            this.textBoxRespData.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRespData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRespData.Location = new System.Drawing.Point(10, 312);
            this.textBoxRespData.Name = "textBoxRespData";
            this.textBoxRespData.ReadOnly = true;
            this.textBoxRespData.Size = new System.Drawing.Size(552, 20);
            this.textBoxRespData.TabIndex = 20;
            // 
            // labelResp
            // 
            this.labelResp.AutoSize = true;
            this.labelResp.Location = new System.Drawing.Point(10, 294);
            this.labelResp.Name = "labelResp";
            this.labelResp.Size = new System.Drawing.Size(56, 15);
            this.labelResp.TabIndex = 19;
            this.labelResp.Text = "Response";
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(249, 254);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxCompleteCmd
            // 
            this.textBoxCompleteCmd.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompleteCmd.Location = new System.Drawing.Point(10, 206);
            this.textBoxCompleteCmd.Name = "textBoxCompleteCmd";
            this.textBoxCompleteCmd.Size = new System.Drawing.Size(552, 20);
            this.textBoxCompleteCmd.TabIndex = 9;
            this.textBoxCompleteCmd.TextChanged += new System.EventHandler(this.checkCmdFormed);
            this.textBoxCompleteCmd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            // 
            // labelCmd
            // 
            this.labelCmd.AutoSize = true;
            this.labelCmd.Location = new System.Drawing.Point(10, 188);
            this.labelCmd.Name = "labelCmd";
            this.labelCmd.Size = new System.Drawing.Size(60, 15);
            this.labelCmd.TabIndex = 16;
            this.labelCmd.Text = "Command";
            // 
            // textBoxLe
            // 
            this.textBoxLe.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLe.Location = new System.Drawing.Point(523, 128);
            this.textBoxLe.MaxLength = 2;
            this.textBoxLe.Name = "textBoxLe";
            this.textBoxLe.Size = new System.Drawing.Size(39, 20);
            this.textBoxLe.TabIndex = 8;
            this.textBoxLe.Text = "00";
            this.textBoxLe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxLe.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // labelLe
            // 
            this.labelLe.AutoSize = true;
            this.labelLe.Location = new System.Drawing.Point(523, 110);
            this.labelLe.Name = "labelLe";
            this.labelLe.Size = new System.Drawing.Size(18, 15);
            this.labelLe.TabIndex = 14;
            this.labelLe.Text = "Le";
            // 
            // textBoxCmdData
            // 
            this.textBoxCmdData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCmdData.Location = new System.Drawing.Point(10, 128);
            this.textBoxCmdData.Name = "textBoxCmdData";
            this.textBoxCmdData.Size = new System.Drawing.Size(507, 20);
            this.textBoxCmdData.TabIndex = 7;
            this.textBoxCmdData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxCmdData.Leave += new System.EventHandler(this.leaveTextBoxCmdData);
            // 
            // labelCmdData
            // 
            this.labelCmdData.AutoSize = true;
            this.labelCmdData.Location = new System.Drawing.Point(10, 110);
            this.labelCmdData.Name = "labelCmdData";
            this.labelCmdData.Size = new System.Drawing.Size(87, 15);
            this.labelCmdData.TabIndex = 12;
            this.labelCmdData.Text = "Command Data";
            // 
            // textBoxP3Lc
            // 
            this.textBoxP3Lc.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxP3Lc.Location = new System.Drawing.Point(246, 76);
            this.textBoxP3Lc.MaxLength = 2;
            this.textBoxP3Lc.Name = "textBoxP3Lc";
            this.textBoxP3Lc.Size = new System.Drawing.Size(39, 20);
            this.textBoxP3Lc.TabIndex = 6;
            this.textBoxP3Lc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxP3Lc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxP3Lc.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // textBoxP2
            // 
            this.textBoxP2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxP2.Location = new System.Drawing.Point(187, 76);
            this.textBoxP2.MaxLength = 2;
            this.textBoxP2.Name = "textBoxP2";
            this.textBoxP2.Size = new System.Drawing.Size(39, 20);
            this.textBoxP2.TabIndex = 5;
            this.textBoxP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxP2.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // textBoxP1
            // 
            this.textBoxP1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxP1.Location = new System.Drawing.Point(128, 76);
            this.textBoxP1.MaxLength = 2;
            this.textBoxP1.Name = "textBoxP1";
            this.textBoxP1.Size = new System.Drawing.Size(39, 20);
            this.textBoxP1.TabIndex = 4;
            this.textBoxP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxP1.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // textBoxINS
            // 
            this.textBoxINS.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxINS.Location = new System.Drawing.Point(69, 76);
            this.textBoxINS.MaxLength = 2;
            this.textBoxINS.Name = "textBoxINS";
            this.textBoxINS.Size = new System.Drawing.Size(39, 20);
            this.textBoxINS.TabIndex = 3;
            this.textBoxINS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxINS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxINS.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // textBoxCLA
            // 
            this.textBoxCLA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCLA.Location = new System.Drawing.Point(10, 76);
            this.textBoxCLA.MaxLength = 2;
            this.textBoxCLA.Name = "textBoxCLA";
            this.textBoxCLA.Size = new System.Drawing.Size(39, 20);
            this.textBoxCLA.TabIndex = 2;
            this.textBoxCLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCLA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkValueIsHex);
            this.textBoxCLA.Leave += new System.EventHandler(this.leaveSingleByteFields);
            // 
            // labelP3Lc
            // 
            this.labelP3Lc.AutoSize = true;
            this.labelP3Lc.Location = new System.Drawing.Point(248, 58);
            this.labelP3Lc.Name = "labelP3Lc";
            this.labelP3Lc.Size = new System.Drawing.Size(34, 15);
            this.labelP3Lc.TabIndex = 6;
            this.labelP3Lc.Text = "P3/Lc";
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.Location = new System.Drawing.Point(192, 58);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(19, 15);
            this.labelP2.TabIndex = 5;
            this.labelP2.Text = "P2";
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.Location = new System.Drawing.Point(138, 58);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(17, 15);
            this.labelP1.TabIndex = 4;
            this.labelP1.Text = "P1";
            // 
            // labelINS
            // 
            this.labelINS.AutoSize = true;
            this.labelINS.Location = new System.Drawing.Point(69, 58);
            this.labelINS.Name = "labelINS";
            this.labelINS.Size = new System.Drawing.Size(24, 15);
            this.labelINS.TabIndex = 3;
            this.labelINS.Text = "INS";
            // 
            // labelCLA
            // 
            this.labelCLA.AutoSize = true;
            this.labelCLA.Location = new System.Drawing.Point(10, 58);
            this.labelCLA.Name = "labelCLA";
            this.labelCLA.Size = new System.Drawing.Size(26, 15);
            this.labelCLA.TabIndex = 2;
            this.labelCLA.Text = "CLA";
            // 
            // comboBoxKnownCommands
            // 
            this.comboBoxKnownCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKnownCommands.FormattingEnabled = true;
            this.comboBoxKnownCommands.Items.AddRange(new object[] {
            "Select a command...",
            "GET DATA (ISO)",
            "GET DATA - DF 20 (SECCOS)",
            "SELECT FILE - MF (SECCOS)",
            "GET CHALLENGE (ISO | SECCOS)"});
            this.comboBoxKnownCommands.Location = new System.Drawing.Point(91, 10);
            this.comboBoxKnownCommands.Name = "comboBoxKnownCommands";
            this.comboBoxKnownCommands.Size = new System.Drawing.Size(259, 23);
            this.comboBoxKnownCommands.TabIndex = 1;
            this.comboBoxKnownCommands.SelectedIndexChanged += new System.EventHandler(this.comboBoxKnownCommandChanged);
            // 
            // labelKnownCommands
            // 
            this.labelKnownCommands.AutoSize = true;
            this.labelKnownCommands.Location = new System.Drawing.Point(10, 14);
            this.labelKnownCommands.Name = "labelKnownCommands";
            this.labelKnownCommands.Size = new System.Drawing.Size(65, 15);
            this.labelKnownCommands.TabIndex = 0;
            this.labelKnownCommands.Text = "Commands";
            // 
            // tabPageSendMultipleCommands
            // 
            this.tabPageSendMultipleCommands.Location = new System.Drawing.Point(4, 24);
            this.tabPageSendMultipleCommands.Name = "tabPageSendMultipleCommands";
            this.tabPageSendMultipleCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendMultipleCommands.Size = new System.Drawing.Size(572, 559);
            this.tabPageSendMultipleCommands.TabIndex = 1;
            this.tabPageSendMultipleCommands.Text = "Send Commands";
            this.tabPageSendMultipleCommands.UseVisualStyleBackColor = true;
            // 
            // tabPageExecuteScript
            // 
            this.tabPageExecuteScript.Location = new System.Drawing.Point(4, 24);
            this.tabPageExecuteScript.Name = "tabPageExecuteScript";
            this.tabPageExecuteScript.Size = new System.Drawing.Size(572, 559);
            this.tabPageExecuteScript.TabIndex = 2;
            this.tabPageExecuteScript.Text = "Execute Script";
            this.tabPageExecuteScript.UseVisualStyleBackColor = true;
            // 
            // tabPageExecuteTransaction
            // 
            this.tabPageExecuteTransaction.Location = new System.Drawing.Point(4, 24);
            this.tabPageExecuteTransaction.Name = "tabPageExecuteTransaction";
            this.tabPageExecuteTransaction.Size = new System.Drawing.Size(572, 559);
            this.tabPageExecuteTransaction.TabIndex = 3;
            this.tabPageExecuteTransaction.Text = "Execute Transaction";
            this.tabPageExecuteTransaction.UseVisualStyleBackColor = true;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.tabControlActions);
            this.groupBoxActions.Location = new System.Drawing.Point(643, 54);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(592, 614);
            this.groupBoxActions.TabIndex = 10;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // richTextBoxAnalysedATR
            // 
            this.richTextBoxAnalysedATR.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxAnalysedATR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAnalysedATR.Location = new System.Drawing.Point(17, 75);
            this.richTextBoxAnalysedATR.Name = "richTextBoxAnalysedATR";
            this.richTextBoxAnalysedATR.ReadOnly = true;
            this.richTextBoxAnalysedATR.Size = new System.Drawing.Size(539, 468);
            this.richTextBoxAnalysedATR.TabIndex = 7;
            this.richTextBoxAnalysedATR.Text = "";
            // 
            // CardTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 733);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxRunningLog);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.comboBoxReadersList);
            this.Controls.Add(this.labelReaders);
            this.Controls.Add(this.buttonRefreshReaderList);
            this.Font = new System.Drawing.Font("Segoe WP Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CardTalk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Talk";
            this.groupBoxRunningLog.ResumeLayout(false);
            this.tabControlActions.ResumeLayout(false);
            this.tabPageATR.ResumeLayout(false);
            this.tabPageATR.PerformLayout();
            this.tabPageSendSingleCmd.ResumeLayout(false);
            this.tabPageSendSingleCmd.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefreshReaderList;
        private System.Windows.Forms.Label labelReaders;
        private System.Windows.Forms.ComboBox comboBoxReadersList;
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
        private System.Windows.Forms.TabPage tabPageATR;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.TextBox textBoxSw1Sw2;
        private System.Windows.Forms.Label labelStatusWord;
        private System.Windows.Forms.TextBox textBoxRespData;
        private System.Windows.Forms.Label labelResp;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxCompleteCmd;
        private System.Windows.Forms.Label labelCmd;
        private System.Windows.Forms.TextBox textBoxLe;
        private System.Windows.Forms.Label labelLe;
        private System.Windows.Forms.TextBox textBoxCmdData;
        private System.Windows.Forms.Label labelCmdData;
        private System.Windows.Forms.TextBox textBoxP3Lc;
        private System.Windows.Forms.TextBox textBoxP2;
        private System.Windows.Forms.TextBox textBoxP1;
        private System.Windows.Forms.TextBox textBoxINS;
        private System.Windows.Forms.TextBox textBoxCLA;
        private System.Windows.Forms.Label labelP3Lc;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelINS;
        private System.Windows.Forms.Label labelCLA;
        private System.Windows.Forms.ComboBox comboBoxKnownCommands;
        private System.Windows.Forms.Label labelKnownCommands;
        private System.Windows.Forms.Label labelRespData;
        private System.Windows.Forms.RichTextBox richTextBoxRespData;
        private System.Windows.Forms.Label labelRespDataLen;
        private System.Windows.Forms.Label labelCmdDataNumBytes;
        private System.Windows.Forms.RichTextBox richTextBoxAnalysedATR;
    }
}

