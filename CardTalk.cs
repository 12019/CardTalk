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
    public partial class CardTalk : Form
    {
        public CardTalk()
        {
            InitializeComponent();
            updateReaderList();
        }


        private void buttonRefreshReaderList_Click(object sender, EventArgs e)
        {
            updateReaderList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readersList"></param>
        public void updateReaderList()//List<string> readersList)
        {
            readerActions readers = new readerActions();
            List<string> readersList = readers.getReadersList();

            // Check if the list has some items. No items indicates an error
            if (readersList.Count > 0)
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
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // TODO: Which of these is an elegant solution
            this.Close();
            Application.Exit();
        }

        private void buttonRefreshATR_Click(object sender, EventArgs e)
        {
            readerActions readers = new readerActions();
            textBoxATR.Text = readers.getATR(comboBoxReadersList.SelectedItem.ToString());
        }
    }
}
