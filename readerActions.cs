/******************************************************************************
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Change all uses of String to byte[]
namespace CardTalk
{
    public class readerActions
    {
        private int _phContext;
        private int _phCard;
        private int _pcchReader;
        private int _ActiveProtocol;// IntPtr.Zero;
        private String _readerToUse;
        private winscardWrapper.SCARD_IO_REQUEST _pioSendRequest;
        private CardTalk _cardtalk;

        public readerActions()
        {
            resetClassVars();
        }

        public readerActions(CardTalk cardtalk)
        {
            resetClassVars();
            _cardtalk = cardtalk;
        }

        public String READER_TO_USE
        {
            get { return _readerToUse; }
            set { _readerToUse = value; }
        }

        private void resetClassVars()
        {
            _phContext = 0;
            _phCard = 0;
            _pcchReader = 0;
            _ActiveProtocol = 0;
            //_readerToUse = null;
        }

        public byte[] sendCmdGetResp(byte[] command, ref byte[] response)
        {
            byte[] byteArray = new byte[255];;

            return byteArray;
        }

        public String __sendCmdGetResp(String command, ref byte[] response, ref byte[] sw1sw2)
        {
            int retCode = 0;
            byte[] cmd = utils.StringToByteArray(command);

            //_cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.CMD, utils.ByteArrayToString(command));

            try
            {
                // Establish resource manager context
                retCode = winscardWrapper.SCardEstablishContext(winscardWrapper.SCARD_SCOPE_USER, 0, 0, ref _phContext);

                // Check how to proceed
                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                {
                    try
                    {
                        // Now connect to the card reader
                        retCode = winscardWrapper.SCardConnect(_phContext, _readerToUse, 2, 3, ref _phCard, ref _ActiveProtocol);

                        // Check if the connection was established with the said readername
                        if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                        {
                            //byte[] responseBuffer = new byte[255];

                            winscardWrapper.SCARD_IO_REQUEST ioSend;
                            ioSend.dwProtocol = winscardWrapper.SCARD_PROTOCOL_T1;
                            ioSend.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(winscardWrapper.SCARD_IO_REQUEST));

                            int respLen = 0;
                            retCode = winscardWrapper.SCardTransmit(_phCard, ref ioSend, ref cmd[0], cmd.Length, ref ioSend, ref response[0], ref respLen);
                            if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                            {
                                response = new byte[respLen];
                                retCode = winscardWrapper.SCardTransmit(_phCard, ref ioSend, ref cmd[0], cmd.Length, ref ioSend, ref response[0], ref respLen);
                                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                                {
                                    // Prepare the response
                                    //byte[] sw1sw2Byte = new byte[2];
                                    //Array.Copy(responseBuffer, (responseBuffer.Length - 2), sw1sw2, 0, 2);
                                    //sw1sw2 = utils.ByteArrayToString(sw1sw2Byte);
                                    //Array.Resize(ref responseBuffer, responseBuffer.Length - 2);
                                    //response = utils.ByteArrayToString(responseBuffer);
                                    //_cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.RSP, response, sw1sw2);
                                }
                            }
                        }
                    }
                    finally
                    {
                        // Do not reset class variables and release contexts
                    }
                }
            }
            finally
            {
                // Do not reset class variables and release contexts
            }

            // Send command data

            // Get the response
            return winscardWrapper.GetScardErrMsg(retCode);
        }
        public String sendCmdGetResp(String command, ref String response, ref String sw1sw2)
        {
            // Clean the String command from white spaces and send the command
            return sendCmdGetResp(utils.StringToByteArray(command.Replace(" ", "")), ref response, ref sw1sw2);
        }

        public String sendCmdGetResp(byte[] command, ref String response, ref String sw1sw2)
        {
            int retCode = 0;
            
            //_cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.CMD, utils.ByteArrayToString(command));
            
            try
            {
                // Establish resource manager context
                retCode = winscardWrapper.SCardEstablishContext(winscardWrapper.SCARD_SCOPE_USER, 0, 0, ref _phContext);

                // Check how to proceed
                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                {
                    try
                    {
                        // Now connect to the card reader
                        retCode = winscardWrapper.SCardConnect(_phContext, _readerToUse, 2, 3, ref _phCard, ref _ActiveProtocol);

                        // Check if the connection was established with the said readername
                        if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                        {
                            byte[] responseBuffer = new byte[255];

                            winscardWrapper.SCARD_IO_REQUEST ioSend;
                            ioSend.dwProtocol = winscardWrapper.SCARD_PROTOCOL_T1;
                            ioSend.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(winscardWrapper.SCARD_IO_REQUEST));
                            
                            int respLen = 0;
                            retCode = winscardWrapper.SCardTransmit(_phCard, ref ioSend, ref command[0], command.Length, ref ioSend, ref responseBuffer[0], ref respLen);
                            if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                            {
                                responseBuffer = new byte[respLen];
                                retCode = winscardWrapper.SCardTransmit(_phCard, ref ioSend, ref command[0], command.Length, ref ioSend, ref responseBuffer[0], ref respLen);
                                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                                {
                                    // Prepare the response
                                    byte[] sw1sw2Byte = new byte[2];
                                    Array.Copy(responseBuffer, (responseBuffer.Length - 2), sw1sw2Byte, 0, 2);
                                    sw1sw2 = utils.ByteArrayToString(sw1sw2Byte);
                                    Array.Resize(ref responseBuffer, responseBuffer.Length - 2);
                                    response = utils.ByteArrayToString(responseBuffer);
                                    //_cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.RSP, response, sw1sw2);
                                }
                            }
                        }
                    }
                    finally
                    {
                        // Do not reset class variables and release contexts
                    }
                }
            }
            finally
            {
                // Do not reset class variables and release contexts
            }

            // Send command data

            // Get the response
            return winscardWrapper.GetScardErrMsg(retCode);
        }

        public Boolean getATR(String readerName, ref String stringATR)
        {
            int tempCode = 0;
            int retCode = 0;
            //String stringATR = null;

            // TODO: set _readerToUse using getters and setter property
            //_readerToUse = readerName;

            try
            {
                // Establish resource manager context
                retCode = winscardWrapper.SCardEstablishContext(winscardWrapper.SCARD_SCOPE_USER, 0, 0, ref _phContext);

                // Check how to proceed
                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                {
                    try
                    {
                        // Now connect to the card reader
                        retCode = winscardWrapper.SCardConnect(_phContext, readerName, 2, 3, ref _phCard, ref _ActiveProtocol);

                        // Check if the connection was established with the said readername
                        if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                        {
                            // Get ATR by checking card status
                            byte[] atr;
                            byte byteTemp = new byte();
                            uint atrLen = 0;
                            
                            // First get the ATR length
                            retCode = winscardWrapper.SCardGetAttrib(_phCard, winscardWrapper.SCARD_ATTR_ATR_STRING, ref byteTemp, ref atrLen);

                            // Prepare the byte array to the ATR length to hold the ATR
                            atr = new byte[atrLen];
                            
                            // Now get the entire ATR
                            retCode = winscardWrapper.SCardGetAttrib(_phCard, winscardWrapper.SCARD_ATTR_ATR_STRING, ref atr[0], ref atrLen);

                            if (winscardWrapper.SCARD_S_SUCCESS != retCode)
                            {
                                // Error some how indicate it
                            }
                            else
                            {
                                // Convert the byte[] to string to return
                                stringATR = utils.ByteArrayToString(atr);

                                // Use of delegate
                                //delegateAppendToRunningLog runningLog = new delegateAppendToRunningLog(_cardtalk.appendToRunningLog);
                                //runningLog(stringATR);

                                //_cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.ATR, stringATR);
                            }
                        }
                    }
                    finally
                    {
                        // Disconnect from the reader
                        tempCode = winscardWrapper.SCardDisconnect(_phCard, 0);
                        if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                        {
                            retCode = tempCode;
                        }
                    }
                }
            }
            finally
            {
                // Release context
                tempCode = winscardWrapper.SCardReleaseContext(_phContext);
                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                    retCode = tempCode;

                resetClassVars();
            }

            //return retCode;
            if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                return true;
            else
            {
                stringATR = winscardWrapper.GetScardErrMsg(retCode);
                return false;
            }
        }

        /// <summary>
        /// Get a list of all the readers connected.
        /// </summary>
        /// <returns></returns>
        public int getReadersList(ref List<String> listOfReaders)
        {
            //List<string> listOfReaders = new List<string>();
            
            int retCode = 0;

            try
            {
                // Establish resource manager context
                retCode = winscardWrapper.SCardEstablishContext(winscardWrapper.SCARD_SCOPE_USER, 0, 0, ref _phContext);

                // Check how to proceed
                if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                {
                    // Get the list of readers, first call to SCardListReaders will get the length of the buffer needed
                    // this can be done by setting the 3rd paramerter to null
                    // 4th parameter will contain Length of the mszReaders buffer in characters
                    retCode = winscardWrapper.SCardListReaders(_phContext, null, null, ref _pcchReader);

                    // Proceed if no error
                    if (winscardWrapper.SCARD_S_SUCCESS == retCode)
                    {
                        // Now create a byte array to hold the names of the card readers
                        byte[] mszReaders = new byte[_pcchReader];

                        // Fill readers buffer with second call.
                        retCode = winscardWrapper.SCardListReaders(_phContext, null, mszReaders, ref _pcchReader);

                        // Populate List with readers.
                        ASCIIEncoding ascii = new ASCIIEncoding();

                        string currbuff = ascii.GetString(mszReaders);
                        String readerList = null;
                        int len = (int)_pcchReader;
                        int nullindex = -1;
                        char nullchar = (char)0;

                        // Iterate through and fill the list with reader names
                        if (len > 0)
                        {
                            //while ((currbuff[0] != nullchar))
                            while (currbuff[0] != nullchar)
                            {
                                nullindex = currbuff.IndexOf(nullchar);   // Get null end character.
                                string reader = currbuff.Substring(0, nullindex);

                                // Prepare readerList string to have the readers names set as: <TAB SPACE> Readername <NEW LING>
                                readerList += "\t" + reader + "\n";

                                listOfReaders.Add(reader);
                                len = len - (reader.Length + 1);
                                currbuff = currbuff.Substring(nullindex + 1, len);
                            }


                            // Update the running log
                            _cardtalk.appendToRunningLog(CardTalk.DISPLAY_TYPE.CARD_READERS, readerList);
                        }
                    }
                }
            }
            finally
            {
                winscardWrapper.SCardReleaseContext(_phContext);
                //retCode = winscardWrapper.SCardFreeMemory(_phContext, ref _pcchReader);
                resetClassVars();
            }

            return retCode;
        }
    }
}
