using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    /// <summary>
    /// 
    /// Definition and scope:
    /// The INTERNAL AUTHENTICATE command initiates the computation of the 
    /// authentication data by the card using the challenge data sent from 
    /// the interface device and a relevant secret (e.g. a key) stored in 
    /// the card.
    /// 
    /// When the relevant secret is attached to the MF, the command may be used
    /// to authenticate the card as a whole.
    /// 
    /// When the relevant secret is attached to another DF, the comand may be 
    /// used to authenticate that DF.
    /// 
    /// Conditional usage and security
    /// The successful execution of the command may be subject to successful 
    /// completion of prior commands (e.g. Verify, Select File) or selections 
    /// (e.g. the relevant secret).
    /// 
    /// If a key and an algorithm are currently selected when issuing the command
    /// then the command may implicitly use the key and the algorithm.
    /// 
    /// The number of times the command is issued may be recorded in the card to
    /// limit the number of further attempts of using the relevant secret or the 
    /// algorithm.
    /// 
    /// Command message:
    /// +---+---+--+--+--+--------------------+--+
    /// |CLA|INS|P1|P2|Lc|        DATA        |Le|
    /// +---+---+--+--+--+--------------------+--+
    /// |XX | 88|XX|XX|XX| XX...XX            |XX|
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
    class InternalAuthenticate
    {
        private byte CLA = 0x00;
        private byte INS = ISO7816Commands.INTERNAL_AUTHENTICATE;
    }
}
