using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// 
    /// Definition and scope:
    /// The VERIFY command initiates the comparison in the card of the verification 
    /// data sent from the interface device with the reference data stored in the 
    /// card (e.g. password).
    /// 
    /// Conditional usage and security
    /// The security status may be modified as a result of a comparison. Unsuccessful 
    /// comparisons may be recorded in the card (e.g. to limit the number of further 
    /// attempts of the use of the reference data).
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | 20|XX|XX|XX| XX...XX            |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                            |
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| 0| 0| 0| No information is given                        |
    /// | 0| -| -| -|   | -| -| -| -| Global reference data (card password)          |
    /// | 1| -| -| -|   | -| -| -| -| Specific reference data (DF specific password) |
    /// | 0| 0| 0| x|   | x| x| x| x| Reference data number                          |
    /// | ANY OTHER VALUE           | RFU                                            |
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// </summary>
    class Verify
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.VERIFY;
    }
}
