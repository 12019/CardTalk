using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// 
    /// Definition and scope:
    /// The EXTERNAL AUTHENTICATE command conditionally updates the security status 
    /// using the result (yes or no) of the computation by the card based on a 
    /// challenge previously issued by the card (e.g. by a GET CHALLENGE command) a 
    /// key possibly secret stored in the card and authentication data transmitted 
    /// by the interface device.
    /// 
    /// Conditional usage and security
    /// The successful execution of the command requires that the last challenge 
    /// obtained from the card is valid.
    /// 
    /// Unsuccessful comparisons may be recorded in the card (e.g. to limit the 
    /// number of further attempts of the use of the reference data).
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | B2|XX|XX|XX| XX...XX            |  |
    /// +---+---+--+--+--+--------------------+--+
    /// 
    /// Coding of the reference control P2
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// |b8|b7|b6|b5|   |b4|b3|b2|b1|         Description                            |
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// | 0| 0| 0| 0|   | 0| 0| 0| 0| No information is given                        |
    /// | 0| -| -| -|   | -| -| -| -| Global reference data (MF specific key)        |
    /// | 1| -| -| -|   | -| -| -| -| Specific reference data (DF specific key)      |
    /// | 0| 0| 0| x|   | x| x| x| x| Number of the secret                           |
    /// | ANY OTHER VALUE           | RFU                                            |
    /// +--+--+--+--+   +--+--+--+--+------------------------------------------------+
    /// 
    /// </summary>
    class ExternalAuthenticate
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.EXTERNAL_AUTHENTICATE;
    }
}
