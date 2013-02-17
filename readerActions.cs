/******************************************************************************
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk
{
    public class readerActions
    {
        private int _phContext;
        private int _phCard;
        private int _pcchReader;
        private int _ActiveProtocol;// IntPtr.Zero;

        public readerActions()
        {
            resetClassVars();
        }

        private void resetClassVars()
        {
            _phContext = 0;
            _phCard = 0;
            _pcchReader = 0;
            _ActiveProtocol = 0;
        }

        public void semdCmdGetResp(byte[] command, byte[] response)
        {
            int retCode = 0;
            String readerName = null;

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
                            int sw1sw2 = 0;
                            byte[] responseBuffer = new byte[256];

                            winscardWrapper.SCARD_IO_REQUEST ioSend;
                            ioSend.dwProtocol = winscardWrapper.SCARD_PROTOCOL_T1;
                            ioSend.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(winscardWrapper.SCARD_IO_REQUEST));
                            
                            //winscardWrapper.SCardTransmit
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
        }

        public String getATR(String readerName)
        {
            int retCode = 0;
            String stringATR = null;

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
                            }
                        }
                    }
                    finally
                    {
                        // Disconnect from the reader
                        retCode = winscardWrapper.SCardDisconnect(_phCard, 0);
                    }
                }
            }
            finally
            {
                // Release context
                retCode = winscardWrapper.SCardReleaseContext(_phContext);
                resetClassVars();
            }

            return stringATR;
        }

        /// <summary>
        /// Get a list of all the readers connected.
        /// </summary>
        /// <returns></returns>
        public List<String> getReadersList()
        {
            List<string> listOfReaders = new List<string>();
            
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

                    // Now create a byte array to hold the names of the card readers
                    byte[] mszReaders = new byte[_pcchReader];

                    // Fill readers buffer with second call.
                    retCode = winscardWrapper.SCardListReaders(_phContext, null, mszReaders, ref _pcchReader);

                    // Populate List with readers.
                    ASCIIEncoding ascii = new ASCIIEncoding();

                    string currbuff = ascii.GetString(mszReaders);
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
                            listOfReaders.Add(reader);
                            len = len - (reader.Length + 1);
                            currbuff = currbuff.Substring(nullindex + 1, len);
                        }
                    }
                }
            }
            finally
            {
                retCode = winscardWrapper.SCardReleaseContext(_phContext);
                //retCode = winscardWrapper.SCardFreeMemory(_phContext, ref _pcchReader);
                resetClassVars();
            }

            return listOfReaders;
        }
    }
}
