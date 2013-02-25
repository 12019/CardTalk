/******************************************************************************
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows;

namespace CardTalk
{
    //public delegate void delegateAppendToRunningLog(String text);

    public partial class CardTalk : Form
    {
        public enum DISPLAY_TYPE { ATR, CMD, RSP, CARD_READERS, READER_SELECTED };

        private String FORMAT_ATR       = "ATR:    ";
        private String FORMAT_CMD       = "CMD:    ";
        private String FORMAT_RSP       = "RSP:    ";
        private String FORMAT_SW1SW2    = "SW1SW2: ";

        private readerActions _readers;
        private int _cmdDataEntered;

        /// <summary>
        /// Primary constructor
        /// </summary>
        public CardTalk()
        {
            InitializeComponent();

            initSendCommandTab();

            _readers = new readerActions(this);
            
            updateReaderList();
        }

        /// <summary>
        /// Initialize the elements of the send command action tab
        /// </summary>
        private void initSendCommandTab()
        {
            // Selected item in teh commands list
            comboBoxKnownCommands.SelectedIndex = 0;

            // Set all the textboxes to nothing
            textBoxCLA.Clear();
            textBoxINS.Clear();
            textBoxP1.Clear();
            textBoxP2.Clear();
            textBoxP3Lc .Clear();
            textBoxLe.Clear();
            textBoxCmdData.Clear();
            textBoxCompleteCmd.Clear();

            // Deactivate the SEND button
            buttonSend.Enabled = false;

            _cmdDataEntered = 0;
        }

        /// <summary>
        /// Refresh card readers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshReaderList_Click(object sender, EventArgs e)
        {
            updateReaderList();
        }

        /// <summary>
        /// Look for all available reader
        /// Update the dropdown list with the found card readers
        /// </summary>
        public void updateReaderList()
        {
            List<string> readersList = new List<string>();;
            int retCode = _readers.getReadersList(ref readersList);

            // Check if the list has some items. No items indicates an error
            if (winscardWrapper.SCARD_S_SUCCESS == retCode)
            {
                // Clear all the items first 
                comboBoxReadersList.Items.Clear();

                // Now add all the items from the list
                foreach (String readerName in readersList)
                {
                    comboBoxReadersList.Items.Add(readerName);
                }

                // Select the first in the list as default
                // TODO: Change this to the one which has a card
                comboBoxReadersList.SelectedIndex = 0;
            }
            else
            {
                // Some thing happened, we dont have a list of card readers
                appendToRunningLog(winscardWrapper.GetScardErrMsg(retCode), Color.Red);
            }
        }

        /// <summary>
        /// Action event to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // TODO: Which of these is an elegant solution
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Get ATR again from the card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshATR_Click(object sender, EventArgs e)
        {
            //readerActions readers = new readerActions(this);
            string stringATR =_readers.getATR(comboBoxReadersList.SelectedItem.ToString());
            textBoxATR.Text = stringATR;
            appendToRunningLog(DISPLAY_TYPE.ATR, stringATR);
        }

        /// <summary>
        /// Append a message to the running log
        /// </summary>
        /// <param name="text">text to append to the running log</param>
        /*public void appendToRunningLog(String text)
        {
            richTextBoxRunningLog.SelectionColor = Color.Fuchsia;
            richTextBoxRunningLog.AppendText(text);

            richTextBoxRunningLog.SelectionColor = Color.Black;
            richTextBoxRunningLog.AppendText(text);
        }*/

        /// <summary>
        /// Append a message to the running log
        /// </summary>
        /// <param name="text">text to append to the running log</param>
        /// <param name="color">color in which to append the text</param>
        public void appendToRunningLog(String text, Color color)
        {
            richTextBoxRunningLog.SelectionColor = color;
            richTextBoxRunningLog.AppendText(text);
            richTextBoxRunningLog.ScrollToCaret();
        }

        /// <summary>
        /// Append a message to the running log - use this for response from the card
        /// </summary>
        /// <param name="dispType">differentiate the message type to append</param>
        /// <param name="response">response data to append to the running log</param>
        /// <param name="sw1sw2">sw1sw2 from the card</param>
        public void appendToRunningLog(DISPLAY_TYPE dispType, String response, String sw1sw2)
        {
            switch (dispType)
            {
                case DISPLAY_TYPE.RSP:
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog(FORMAT_RSP);
                    //appendToRunningLog(utils.prepareInfoForRunningLog(response));
                    appendToRunningLog(response);
                    appendToRunningLog(FORMAT_SW1SW2);
                    appendToRunningLog(utils.prepareInfoForRunningLog(sw1sw2));

                    
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog("\n");
                    break;
            }
        }

        /// <summary>
        /// Append a message to the running log, message of a type will be appended according to a template
        /// </summary>
        /// <param name="dispType">differentiate the message type to append</param>
        /// <param name="text">text to append to the running log</param>
        public void appendToRunningLog(DISPLAY_TYPE dispType, String text)
        {
            switch (dispType)
            {
                case DISPLAY_TYPE.ATR:
                    richTextBoxRunningLog.SelectionColor = Color.Fuchsia;
                    appendToRunningLog(FORMAT_ATR);
                    appendToRunningLog(text);
                    
                    // TODO: To display the ASCII char on the richtextbox use this line -> richTextBoxRunningLog.AppendText(((char)0x3B).ToString());

                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog("\n\n");
                    
                    break;

                case DISPLAY_TYPE.CMD:
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog(FORMAT_CMD);
                    appendToRunningLog(utils.prepareInfoForRunningLog(text));

                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    //appendToRunningLog("\n");
                    
                    break;

                case DISPLAY_TYPE.CARD_READERS:
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog("Available readers:\n");
                    appendToRunningLog(text);
                    
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog("\n");
                    
                    break;

                case DISPLAY_TYPE.READER_SELECTED:
                    richTextBoxRunningLog.SelectionColor = Color.Red;
                    appendToRunningLog("Currently selected reader:\n\t");
                    appendToRunningLog(text);
                    
                    richTextBoxRunningLog.SelectionColor = Color.Black;
                    appendToRunningLog("\n\n");
                    
                    break;
            }
        }

        private void comboBoxReaderSelected(object sender, EventArgs e)
        {
            appendToRunningLog(DISPLAY_TYPE.READER_SELECTED, comboBoxReadersList.Text);
            _readers.READER_TO_USE = comboBoxReadersList.Text;
        }

        /*private String prepareCmdRspToDisplay(String cmdRsp)
        {
            String tempInput = cmdRsp.Replace(" ", "");
            String preparedInfo = "";
            String asciiEquivalent = "";
            byte charToDisplay;

            int len = tempInput.Length;
            int temp = 0;
            for (int i = 0; i < len; i++)
            {
                // Make the display text readable
                // 8 bytes followed by double space
                // 16 bytes in a line
                if (temp == 8)
                {
                    preparedInfo += "  ";
                }
                else if (temp == 16)
                {
                    preparedInfo += "   " + asciiEquivalent;
                    asciiEquivalent = "";
                    preparedInfo += "\n        ";
                    temp = 0;
                }
                temp++;
                charToDisplay = utils.StringToByte(tempInput, i);
                preparedInfo += tempInput[i];
                preparedInfo += tempInput[++i];
                preparedInfo += " ";
                
                asciiEquivalent += utils.printableASCII(charToDisplay);
                //i++;
            }

            if (temp <= 16)
            {
                for (int i = 0; i < (16 - temp); i++)
                {
                    preparedInfo += "   ";
                }
                preparedInfo += "   " + asciiEquivalent;
            }
            return preparedInfo;
        }*/

        private void checkValueIsHex(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c != '\b')
            {
                if (!((c <= 0x66 && c >= 0x61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
                {
                    e.Handled = true;
                }
            }

            if ( (sender == textBoxCmdData) && (e.Handled != true) )
            {
                if (c != '\b')
                {
                    _cmdDataEntered++;
                    labelCmdDataNumBytes.Text = (_cmdDataEntered / 2).ToString() + " bytes";
                }
                else
                {
                    if (_cmdDataEntered > 0)
                    {
                        _cmdDataEntered--;
                        labelCmdDataNumBytes.Text = (_cmdDataEntered / 2).ToString() + " bytes";
                    }
                }
            }
        }

        private void comboBoxKnownCommandChanged(object sender, EventArgs e)
        {
            String selectedCmd = comboBoxKnownCommands.SelectedItem.ToString();

            if (selectedCmd == "Select a command...")
            {
                initSendCommandTab();
            }

            if (selectedCmd == "GET DATA - DF 20 (SECCOS)")
            {
                textBoxCLA.Text = "00";
                textBoxINS.Text = "CA";
                textBoxP1.Text = "DF";
                textBoxP2.Text = "20";
                textBoxLe.Text = "00";
            }

            if (selectedCmd == "GET CHALLENGE (ISO | SECCOS)")
            {
                textBoxCLA.Text = "00";
                textBoxINS.Text = "84";
                textBoxP1.Text = "00";
                textBoxP2.Text = "00";
                textBoxLe.Text = "00";
            }

            if (selectedCmd == "SELECT FILE - MF (SECCOS)")
            {
                textBoxCLA.Text = "00";
                textBoxINS.Text = "A4";
                textBoxP1.Text = "00";
                textBoxP2.Text = "00";
                textBoxLe.Text = "00";
            }

            textBoxCompleteCmd.Text = textBoxCLA.Text + textBoxINS.Text + textBoxP1.Text + textBoxP2.Text + textBoxP3Lc.Text + textBoxCmdData.Text + textBoxLe.Text;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            String response = "";
            String sw1sw2 = "";

            // Add the command information to the running log
            appendToRunningLog(DISPLAY_TYPE.CMD, textBoxCompleteCmd.Text);

            // Send the command to the card and get the response
            String retCode = _readers.sendCmdGetResp(textBoxCompleteCmd.Text, ref response, ref sw1sw2);

            // Check if the response if OK (90 00)
            if ("OK" == retCode)
            {
                // Present the information (response & SW1SW2) to the Send Command tab
                textBoxRespData.Text = response.Replace(" ", "");

                labelRespDataLen.Text = (textBoxRespData.Text.Length / 2).ToString() + " bytes";

                response = utils.prepareInfoForRunningLog(response);
                // Append the response data with the statusword to the running log
                appendToRunningLog(CardTalk.DISPLAY_TYPE.RSP, response, sw1sw2);

                richTextBoxRespData.Text = response.Replace("        ", "");
                richTextBoxRespData.Text = richTextBoxRespData.Text.Replace("   ", " ");
                textBoxSw1Sw2.Text = sw1sw2;
            }
            else
            {
                appendToRunningLog(retCode, Color.Red);
            }
        }

        private void leaveSingleByteFields(object sender, EventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;
            if (senderTextBox.Text.Length == 1)
            {
                senderTextBox.Text = "0" + senderTextBox.Text;
            }

            // Build the complete command data
            textBoxCompleteCmd.Text = textBoxCLA.Text + textBoxINS.Text + textBoxP1.Text + textBoxP2.Text;
            if ((textBoxP3Lc.Text != "") && (textBoxP3Lc.Text != "00"))
                textBoxCompleteCmd.Text += textBoxP3Lc.Text + textBoxCmdData.Text;

            textBoxCompleteCmd.Text += textBoxLe.Text;
        }

        private void leaveTextBoxCmdData(object sender, EventArgs e)
        {
            if ((textBoxP3Lc.TextLength > 0) && (_cmdDataEntered / 2 != Convert.ToInt32(textBoxP3Lc.Text)))
            {
                DialogResult msgboxResult = MessageBox.Show("Number of bytes entered as command data is not equal to the P3/Lc value\n\nAbort to clear everything\nRetry to try again\nIgnore to proceed with error", 
                                                            "Length Error", 
                                                            MessageBoxButtons.AbortRetryIgnore, 
                                                            MessageBoxIcon.Error);

                if (msgboxResult == DialogResult.Abort)
                {
                    // Clear all boxes and set focus on comboBoxKnownCommands
                    initSendCommandTab();
                    comboBoxKnownCommands.Focus();
                }
                else if (msgboxResult == DialogResult.Retry)
                {
                    textBoxP3Lc.Focus();
                }
                else
                {
                    // Assuming the user wants to simulate Length error
                    // TODO: prepare this
                }
                
            }
            else
            {
                if ((textBoxP3Lc.Text != "") && (0 != Convert.ToInt32(textBoxP3Lc.Text)))
                {
                    int lc = (_cmdDataEntered / 2);
                    if (lc < 0x10)
                        textBoxP3Lc.Text = "0" + lc.ToString();
                    _cmdDataEntered = 0;
                }
            }
        }

        private void checkCmdFormed(object sender, EventArgs e)
        {
            String tempCmd = textBoxCompleteCmd.Text;
            tempCmd = tempCmd.Replace(" ", "");
            if (tempCmd.Length >= 8)
            {
                buttonSend.Enabled = true;
            }
            else
            {
                buttonSend.Enabled = false;
            }
        }

        private void buttonAnalyseATR_Click(object sender, EventArgs e)
        {
            analyseATR analyse = new analyseATR(textBoxATR.Text);

            //richTextBoxAnalysedATR.SelectionColor = Color
            richTextBoxAnalysedATR.AppendText("Number of ATR bytes: " + analyse.ATR_LENGTH + " bytes\n");

            richTextBoxAnalysedATR.AppendText(analyse.displayBox);
            richTextBoxAnalysedATR.AppendText(analyse.displayBox1);
            richTextBoxAnalysedATR.AppendText(analyse.displayBox);

            analyseATRPresentation(Color.LightGray, analyse.DISPLAY_INFO_TS);
            
            analyseATRPresentation(Color.White, analyse.DISPLAY_INFO_T0);
            analyseATRPresentation(Color.White, analyse.DISPLAY_HIGH_NIBBLE("T0"));

            analyseATRPresentation(Color.LightGray, analyse.DISPLAY_INFO_TA1);

            analyseATRPresentation(Color.White, analyse.DISPLAY_INFO_TB1);

            analyseATRPresentation(Color.LightGray, analyse.DISPLAY_INFO_TC1);

            analyseATRPresentation(Color.White, analyse.DISPLAY_INFO_TD1);
            analyseATRPresentation(Color.White, analyse.DISPLAY_HIGH_NIBBLE("TD1"));
            
            richTextBoxAnalysedATR.ScrollToCaret();
        }

        private void analyseATRPresentation(Color backColor, String text)
        {
            int len = richTextBoxAnalysedATR.TextLength;
            richTextBoxAnalysedATR.SelectionStart = len;
            
            richTextBoxAnalysedATR.SelectionLength = text.Length;
            richTextBoxAnalysedATR.SelectionBackColor = backColor;
            richTextBoxAnalysedATR.AppendText(text);
        }

        private void haveATR(object sender, EventArgs e)
        {
            buttonAnalyseATR.Enabled = true;
        }

        private void appendToRunningLog(String text)
        {
            richTextBoxRunningLog.AppendText(text);
            richTextBoxRunningLog.ScrollToCaret();
        }
    }
}
