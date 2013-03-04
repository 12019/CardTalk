using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The READ RECORD(S) response message gives the contents of the specified 
    /// record(s) (or the beginning part of one record) of an EF.
    /// 
    /// Conditional usage and security
    /// The command can be performed only if the security status satisfies the 
    /// security attributes for this EF for the read function.
    /// 
    /// If an EF is currently selected at the time of issuing the command, then 
    /// this command may be processed without identification of this file.
    /// 
    /// When the command contains a valid short EF identifier, it sets the file 
    /// as current EF and resets the current record pointer.
    ///
    /// The command shall be aborted if applied to an EF without record structure.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | B2|XX|XX|  |                    |xx|
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| -| -| -| Currently selected EF                     |
    /// | x| x| x| x|   | x| -| -| -| Short EF identifier                       |
    /// | 1| 1| 1| 1|   | -| -| -| -| RFU                                       |
    /// | -| -| -| -|   | -| 1| x| x| Usage of record number in P1              |
    /// | -| -| -| -|   | -| 1| 0| 0| Read record P1                            |
    /// | -| -| -| -|   | -| 1| 0| 1| Read all records from P1 upto the last    |
    /// | -| -| -| -|   | -| 1| 1| 0| Read all records from the last up to P1   |
    /// | -| -| -| -|   | -| 1| 1| 1| RFU                                       |
    /// | -| -| -| -|   | -| 1| x| x| Usage of record identifier in P1          |
    /// | -| -| -| -|   | -| 0| 0| 0| Read first occurence                      |
    /// | -| -| -| -|   | -| 0| 0| 1| Read last occurence                       |
    /// | -| -| -| -|   | -| 0| 1| 0| Read next occurence                       |
    /// | -| -| -| -|   | -| 0| 1| 1| Read previous occurence                   |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// 
    /// </summary>
    class ReadRecord
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.READ_RECORD;
    }
}
