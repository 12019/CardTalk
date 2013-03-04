using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The WRITE RECORD command message initiates one of the following operations:
    ///     * the write once of a record,
    ///     * the logical OR of the data bytes of a record already present in the 
    ///         card with the data bytes of the record given in the command APDU.
    ///     * the logical AND of the data bytes of a record already present in the 
    ///         card with the data bytes of the record given in the APDU.
    ///
    /// When no indication is given in the data coding byte, the logical OR operation 
    /// shall apply.
    ///
    /// When using current record addressing the command shall set the record pointer 
    /// on the successfully written record.
    /// 
    /// Conditional usage and security
    /// The command can be performed only if the security status satisfies the security 
    /// attributes for this EF for the write functions.
    ///
    /// If an EF is currently selected at the time of issuing the command, then this 
    /// command may be processed without identification of this file.
    ///
    /// When the command contains a valid short EF identifier, it sets the file as 
    /// current EF and resets the current record pointer.
    ///
    /// The command shall be aborted if applied to an EF without record structure.
    ///
    /// The previous option of the command (P2=xxxxx011) applied to a cyclic file, 
    /// has the same behavior as APPEND RECORD.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | D2|XX|XX|XX| XX...XXX           |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| -| -| -| Currently selected EF                     |
    /// | x| x| x| x|   | x| -| -| -| Short EF identifier                       |
    /// | 1| 1| 1| 1|   | -| -| -| -| RFU                                       |
    /// | -| -| -| -|   | -| 0| 0| 0| First record                              |
    /// | -| -| -| -|   | -| 0| 0| 1| Last record                               |
    /// | -| -| -| -|   | -| 0| 1| 0| Next record                               |
    /// | -| -| -| -|   | -| 0| 1| 1| Previous record                           |
    /// | -| -| -| -|   | -| 1| 0| 0| Record number given in P1                 |
    /// | ANY OTHER VALUE           | RFU                                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// 
    /// </summary>
    class WriteRecord
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.WRITE_RECORD;
    }
}
