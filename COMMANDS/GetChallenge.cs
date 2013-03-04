using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// 
    /// Definition and scope:
    /// The GET CHALLENGE command requires the issuing of a challenge (e.g. random number) 
    /// for use in a security related procedure (e.g. EXTERNAL AUTHENTICATE command).
    /// 
    /// Conditional usage and security
    /// The challenge is valid at least for the next command. No further condition is 
    /// specified in this part of ISO/IEC 7816.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | 84|00|00|  |                    |XX|
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// </summary>
    class GetChallenge
    {
        private byte _CLA = 0x00;
        private byte _INS = ISO7816Commands.GET_CHALLENGE;
        private byte _P1 = 0x00;
        private byte _P2 = 0x00;
        private byte _Lc;// = 0x00;
        private byte[] _CMD_DATA_BUFFER = new byte[ISO7816Commands.T1_CASE2_LEN];
        private byte[] _RSP_DATA_BUFFER;
        private int _RSP_DATA_BUFFER_LEN = 8;
        private byte _Le = 0x00;
        private readerActions _readerHandle = null;

        public byte CLA { get { return _CLA; } }
        public byte INS { get { return _INS; } }
        public byte P1 { get { return _P1; } }
        public byte P2 { get { return _P2; } }
        public byte Lc { get { return _Lc; } }
        public byte Le { get { return _Le; } }

        public GetChallenge()
        {
        }

        public GetChallenge(readerActions readerHandle)
        {
            _readerHandle = readerHandle;
        }

        public byte[] GET_CHALLENGE_ISO7816_CMD()
        {
            return GET_CHALLENGE_ISO7816_CMD((byte)0x08);
        }

        public byte[] GET_CHALLENGE_ISO7816_CMD(byte Le)
        {
            _RSP_DATA_BUFFER_LEN = Le;

            return null;// _CMD_DATA_BUFFER;
        }

        public Boolean GET_CHALLENGE_ISO7816_RSP(byte[] responseData, byte[] sw1sw2)
        {
            Boolean rspOK = true;

            return rspOK;
        }

        public void GET_CHALLENGE_ISO7816_CMD_RSP()
        {
            if (null == _readerHandle)
            {
            }
            else
            {
                // Prepare the command
                GET_CHALLENGE_ISO7816_CMD();

                // Allocate response buffer size - the size of Le
                _RSP_DATA_BUFFER = new byte[_RSP_DATA_BUFFER_LEN];

                // Send the command to the reader and get response
                _readerHandle.sendCmdGetResp(_CMD_DATA_BUFFER, ref _RSP_DATA_BUFFER);

                // Handle the reponse
            }
        }
    }
}
