using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// Definition and scope:
    /// The PUT DATA command is used for storing one primitive data object or 
    /// one or more data objects contained in a constructed data object within 
    /// the current context (e.g. application-specific environment or current DF). 
    /// The exact storing functions (writing once and/or updating and/or appending) 
    /// are to be induced by the definition or the nature of the data objects.
    /// 
    /// NOTE - The command could be used for example to update data objects.
    /// 
    /// Conditional usage and security
    /// The command can be performed only if the security status satisfies the 
    /// security conditions defined by the application within the context for 
    /// the function(s).
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | DA|XX|XX|XX| XX...XX            |  |
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
    class PutData
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.PUT_DATA;
    }
}
