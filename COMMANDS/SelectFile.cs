using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// 
    /// Definition and scope:
    /// A successful Select File sets a current file within a logical channel. 
    /// Subsequent command may implicitly refer to the current file through 
    /// that logical channel.
    /// 
    /// Selecting a DF (which may be the MF) sets it as current DF. After such 
    /// a selection, an implicit current EF may be referred to through that 
    /// logical channel.
    /// 
    /// Selecting an EF sets a pair of current files: the EF and its parent file.
    /// 
    /// After the answer to reset, the MF is implicitly selected through the basic 
    /// logical channel, unless specified differently in the historical bytes or 
    /// in the initial date string.
    /// 
    /// NOTE - A direct selection by DF name can be used for selecting applications 
    /// registered according to part 5 of ISO 7816.
    /// 
    /// Conditional usage and security
    /// The following conditions shall apply to each open logical channel.
    /// 
    /// Unless otherwise specified, the correct execution of the command modifies 
    /// the security status according to the following rules :
    /// 
    /// When the current EF is changed, or when there is no current EF the security 
    /// status if any specific to a former current EF is lost.
    /// 
    /// When the current DF is a descendant of or identical to the former current 
    /// DF, the security status specific to the former current DF is maintained.
    /// 
    /// When the current DF is neither a descendant of nor identical to the former 
    /// current DF the security status specific to the former current DF is lost. 
    /// The security status common to all common ancestors of the previous and new 
    /// current DF is maintained.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | A4|XX|XX|XX| XX...XX            |XX|
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P1
    /// +--+--+--+--+   +--+--+--+--+---------------------------------------------------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                                                                   |
    /// +--+--+--+--+   +--+--+--+--+---------------------------------------------------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| 0| x| x| Selection by file identifier                                                          |
    /// | 0| 0| 0| 0|   | 0| 0| 0| 0| - Select MF, DF or EF (data field = identifier or empty                               |
    /// | 0| 0| 0| 0|   | 0| 0| 0| 1| - Select child DF (data field = DF identifier)                                        |
    /// | 0| 0| 0| 0|   | 0| 0| 1| 0| - Select EF under current DF (data field = EF identifier                              |
    /// | 0| 0| 0| 0|   | 0| 0| 1| 1| - Select parent DF of the current DF (empty data field)                               |
    /// | 0| 0| 0| 0|   | 0| 1| x| x| Selection by DF name                                                                  |
    /// | 0| 0| 0| 0|   | 0| 1| 0| 0| - Direct selection by DF name (data field = DF name)                                  |
    /// | 0| 0| 0| 0|   | 1| x| x| x| Selection by path                                                                     |
    /// | 0| 0| 0| 0|   | 1| 0| 0| 0| - Select from MF (data field=path without the identifier of the MF)                   |
    /// | 0| 0| 0| 0|   | 1| 0| 0| 1| - Select from current DF (data field=path without the identifier of the current DF)   |
    /// | ANY OTHER VALUE           | RFU                                                                                   |
    /// +--+--+--+--+   +--+--+--+--+---------------------------------------------------------------------------------------+
    /// 
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+-----------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description               |
    /// +--+--+--+--+   +--+--+--+--+-----------------------------------+
    /// | 0| 0| 0| 0|   | x| x| 0| 0| First record                      |
    /// | 0| 0| 0| 0|   | x| x| 0| 1| Last record                       |
    /// | 0| 0| 0| 0|   | x| x| 1| 0| Next record                       |
    /// | 0| 0| 0| 0|   | x| x| 1| 1| Previous record                   |
    /// | 0| 0| 0| 0|   | x| x| -| -| File control information option   |
    /// | 0| 0| 0| 0|   | 0| 0| -| -| - Return FCI, optional template   |
    /// | 0| 0| 0| 0|   | 0| 1| -| -| - Return FCP template             |
    /// | 0| 0| 0| 0|   | 1| 0| -| -| - Return FMD template             |
    /// | ANY OTHER VALUE           | RFU                               |
    /// +--+--+--+--+   +--+--+--+--+-----------------------------------+
    /// 
    /// </summary>
    class SelectFile
    {
        public enum P2_RETURN_INFORMATION { FCI = 0x00, FCP = 0x04, FMD = 0x08 };
        public enum P2_RETURN_RECORD { FIRST = 0x00, LAST = 0x01, NEXT = 0x02, PREVIOUS = 0x03 };

        private byte _CLA = 0x00;
        private byte _INS = ISO7816Commands.SELECT_FILE;
        private byte _P1 = 0x00;
        private byte _P2 = 0x00;
        private byte _Lc;   // = 0x00;
        private byte _Le = 0x00;

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

        public SelectFile()
        {
        }

        public SelectFile(readerActions readerHandle)
        {
        }

        public byte[] SELECT_FILE_CMD()
        {
            _P2 = 0x00;
            return SELECT_FILE_CMD(0x3F00);
        }

        public byte[] SELECT_FILE_CMD(String fileName)
        {
            int fileID = 0x00;
            _P2 = 0x00;

            if (fileName == "MF")
                fileID = 0x3F00;

            return SELECT_FILE_CMD(fileID);
        }

        public byte[] SELECT_FILE_CMD(P2_RETURN_RECORD retRecInfo, P2_RETURN_INFORMATION retInfo, int fileID)
        {
            _P2 = (byte)((byte)retRecInfo | (byte)retInfo);

            return SELECT_FILE_CMD(fileID);
        }

        public byte[] SELECT_FILE_CMD(int fileID)
        {
            // Set P1 to - Select MF, DF or EF (data field=identifier or empty)
            _P1 = 0x00;

            // If FileID is provided this will be send in the command data
            // So Lc = 2 and command data length = 2
            _Lc = 2;
            _CMD_DATA_BUFFER = new byte[2];

            _CMD_DATA_BUFFER[0] = (byte)((fileID & 0xFF00) >> 8);
            _CMD_DATA_BUFFER[1] = (byte)(fileID & 0x00FF);

            return _CMD_DATA_BUFFER;
        }

        public byte[] SELECT_FILE_CMD(byte sfi)
        {
            return _CMD_DATA_BUFFER;
        }

        public byte[] SELECT_FILE_CMD(byte[] aid)
        {
            return _CMD_DATA_BUFFER;
        }

        // Other variants of SELECT FILE command
        public byte[] SELECT_FILE_CMD_GET_FCI(int fileID)
        {
            _P2 = (byte)(P2_RETURN_INFORMATION.FCI);

            return SELECT_FILE_CMD(fileID);
        }

        public byte[] SELECT_FILE_CMD_GET_FCP(int fileID)
        {
            _P2 = (byte)(P2_RETURN_INFORMATION.FCP);

            return SELECT_FILE_CMD(fileID);
        }

        public byte[] SELECT_FILE_CMD_GET_FMD(int fileID)
        {
            _P2 = (byte)(P2_RETURN_INFORMATION.FMD);

            return SELECT_FILE_CMD(fileID);
        }
    }
}
