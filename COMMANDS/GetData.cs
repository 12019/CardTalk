using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The GET DATA command is used for the retrieval of one primitive data 
    /// object, or the retrieval of one or more data objects contained in a 
    /// constructed data object, within the current context (e.g. application-specific 
    /// environment or current DF).
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | CA|XX|XX|  |                    |XX|
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P1P2
    /// +-------------+---------------------------------------+
    /// | value       | Meaning                               |
    /// +-------------+---------------------------------------+
    /// | 0000 - 003F | RFU                                   |
    /// | 0040 - 00FF | BER-TLV tag (1 byte) in P2            |
    /// | 0100 - 01FF | Application data (propreitary coding) |
    /// | 0200 - 02FF | Simple-TLV tag in P2                  |
    /// | 0300 - 3FFF | RFU                                   |
    /// | 4000 - FFFF | BER-TLV tag (2 bytes) in P1-P2        |
    /// +-------------+---------------------------------------+
    /// 
    /// </summary>
    class GetData
    {
        private byte _CLA   = 0x00;
        private byte _INS   = ISO7816Commands.GET_DATA;
        private byte _P1    = 0x00;
        private byte _P2    = 0x00;
        private byte _Lc;   // = 0x00;
        private byte _Le    = 0x00;
        
        private byte[] _CMD_DATA_BUFFER = new byte[ISO7816Commands.T1_CASE2_LEN];
        private byte[] _RSP_DATA_BUFFER;
        private int _RSP_DATA_BUFFER_LEN = 255;
        private readerActions _readerHandle = null;

        public byte CLA { get { return _CLA; } }
        public byte INS { get { return _INS; } }
        public byte P1 { get { return _P1; } }
        public byte P2 { get { return _P2; } }
        public byte Lc { get { return _Lc; } }
        public byte Le { get { return _Le; } }

        public GetData()
        {
        }

        public GetData(readerActions readerHandle)
        {
            _readerHandle = readerHandle;
        }

        public byte[] GET_DATA_ISO7816_CMD()
        {
            return GET_DATA_ISO7816_CMD((byte)0x08);
        }

        public byte[] GET_DATA_ISO7816_CMD(int dataObject)
        {
            // Set P1 P2 from the dataObject
            _P1 = (byte)((dataObject & 0xff00) >> 8);
            _P2 = (byte)(dataObject & 0x00ff);

            _RSP_DATA_BUFFER_LEN = Le;

            return null;// _CMD_DATA_BUFFER;
        }

        public Boolean GET_DATA_ISO7816_RSP(byte[] responseData, byte[] sw1sw2)
        {
            Boolean rspOK = true;

            return rspOK;
        }

        public void GET_DATA_ISO7816_CMD_RSP()
        {
            if (null == _readerHandle)
            {
            }
            else
            {
                // Prepare the command
                GET_DATA_ISO7816_CMD();

                // Allocate response buffer size - the size of Le
                _RSP_DATA_BUFFER = new byte[_RSP_DATA_BUFFER_LEN];

                // Send the command to the reader and get response
                _readerHandle.sendCmdGetResp(_CMD_DATA_BUFFER, ref _RSP_DATA_BUFFER);

                // Handle the reponse
            }
        }
    }
}
