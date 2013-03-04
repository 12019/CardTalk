using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The UPDATE RECORD command message initiates the updating of a specific 
    /// record with the bits given in the command APDU.
    ///
    /// When using current record addressing, the command shall set the record 
    /// pointer on the successfully updated record.
    /// 
    /// Conditional usage and security
    /// The command can be performed only if the security status satisfies the 
    /// security attributes for this EF for the update function.
    ///
    /// If an EF is currently selected at the time of issuing the command, then 
    /// this command may be processed without identification of this file.
    ///
    /// When the command contains a valid short EF identifier, it sets the file 
    /// as current EF and resets the current record pointer.
    ///
    /// The command shall be aborted if applied to an EF without record structure.
    ///
    /// When the command applies to an EF with linear fixed or cyclic structure, 
    /// the it shall be aborted if the record length is different form the length 
    /// of the existing record.
    ///
    /// When the command applies to an EF with linear variable structure, then it 
    /// may be carried out when the record length is different from the length of 
    /// the existing record.
    ///
    /// The previous option of the command (P2=0x03), applied to a cyclic file, has 
    /// the same behaviour as APPEND RECORD.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | DC|XX|XX|XX| XX...XXX           |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| 0| 0| 0| Currently selected EF                     |
    /// | x| x| x| x|   | x| 0| 0| 0| Short EF identifier                       |
    /// | 1| 1| 1| 1|   | 1| 0| 0| 0| RFU                                       |
    /// | -| -| -| -|   | -| 0| 0| 0| First record                              |
    /// | -| -| -| -|   | -| 0| 0| 1| Last record                               |
    /// | -| -| -| -|   | -| 0| 1| 0| Next record                               |
    /// | -| -| -| -|   | -| 0| 1| 1| Previous record                           |
    /// | -| -| -| -|   | -| 1| 0| 0| Record number given in P1                 |
    /// | ANY OTHER VALUE           | RFU                                       |
    /// +--+--+--+--+   +--+--+--+--+-------------------------------------------+
    /// 
    /// </summary>
    class UpdateRecord
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.UPDATE_RECORD;
    }
}
