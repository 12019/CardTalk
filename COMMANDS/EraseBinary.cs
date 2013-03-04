using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The ERASE BINARY command message sets (part of) the content of an EF to 
    /// its logical erased state, sequentially starting from a given offset.
    /// 
    /// Conditional usage and security:
    /// When the command contains a valid short EF identifier, it sets the file as 
    /// current EF.
    /// 
    /// The command is processed on the currently selected EF. The command can be 
    /// performed only if the security status satisfies the security attributes 
    /// for the erase function.
    /// 
    /// The command shall be aborted if it is applied to an EF without transparent 
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | 0E|XX|XX|XX| XX...XXX           |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// If b8=1 in P1, then b7-6 are set to 0 (RFU bits). bit5-1 are a short EF 
    /// identifier and P2 is the offset of the first byte to be updated in data 
    /// units from the beginning of the file.
    /// 
    /// If b8=0 in P1, then P1||P2 is the offset of the first byte to be written 
    /// in data units from the beginning of the file.
    /// 
    /// </summary>
    class EraseBinary
    {
        private byte _CLA = 0x00;
        private byte _INS = ISO7816Commands.READ_BINARY;
        private byte _P1 = 0x00;
        private byte _P2 = 0x00;
        private byte _Lc = 0x00;
        private byte[] _DATA_BUFFER = new byte[256];
        private byte _Le = 0x00;
        private readerActions _readerHandle = null;

        public EraseBinary()
        {
        }

        public EraseBinary(readerActions readerHandle)
        {
            _readerHandle = readerHandle;
        }

        public byte[] ERASE_BINARY_ISO7816_CMD()
        {
            return _DATA_BUFFER;
        }

        public Boolean ERASE_BINARY_ISO7816_RSP(byte[] responseData, byte[] sw1sw2)
        {
            Boolean rspOK = true;
            return rspOK;
        }

        public void ERASE_BINARY_ISO7816_CMD_RSP()
        {
        }
    }
}
