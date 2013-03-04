using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The APPEND RECORD command message initiates either the appending of a 
    /// record at the end of an EF of linear structure or the writing of record 
    /// number 1 in an EF of cyclic structure.
    ///
    /// The command shall set the record pointer on the successfully appended record.
    /// 
    /// Conditional usage and security
    /// The command can be performed only if the security status satisfies the 
    /// security attributes for this EF for the append function.
    ///
    /// If an EF is currently selected at the time of issuing the command, then 
    /// this command may be processed without identification of this file.
    ///
    /// When the command contains a valid short EF identifier, it sets the file 
    /// as current EF and resets the current record pointer.
    ///
    /// The command shall be aborted if applied to an EF without record structure.
    ///
    /// NOTE - If this command is applied to an EF of cyclic structure full of records, 
    /// then the record with the highest record number is replaced. This record becomes 
    /// record number 1.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | E2|00|XX|XX| XX...XXX           |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| 0| 0| 0| Currently selected EF                     |
    /// | x| x| x| x|   | x| 0| 0| 0| Short EF identifier                       |
    /// | 1| 1| 1| 1|   | 1| 0| 0| 0| RFU                                       |
    /// | ANY OTHER VALUE           | RFU                                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// 
    /// </summary>
    class AppendRecord
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.APPEND_RECORD;
    }
}
