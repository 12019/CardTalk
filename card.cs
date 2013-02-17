/******************************************************************************
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk
{
    /// <summary>
    /// 
    /// </summary>
    public static class cardStatus
    {
        // Interindustry values of SW1 SW2
        
        /* NORMAL PROCESSING */
        public static int CARD_SW1SW2_ERR_NONE = 0x9000;                            // 0x9000
        public static int CARD_SW1SW2_OK = CARD_SW1SW2_ERR_NONE;                    // 0x9000
        public static int CARD_SW1SW2_WRN = 0x6100;                                 // 0x6FXX

        /* WARNING PROCESSING */
        public static int CARD_SW1SW2_WRN_NON_VOLATILE_MEMORY_UNCHANGED = 0x6200;   // 0x62XX
        public static int CARD_SW1SW2_WRN_NON_VOLATILE_MEMORY_CHANGED = 0x6300;     // 0x63XX

        /* EXECUTION ERROR */
        public static int CARD_SW1SW2_ERR_NON_VOLATILE_MEMORY_UNCHANGED = 0x6200;   // 0x62XX
        public static int CARD_SW1SW2_ERR_NON_VOLATILE_MEMORY_CHANGED = 0x6300;     // 0x63XX
        
        /* CHECKING ERROR */
        public static int CARD_SW1SW2_ERR_LEN = 0x6700;                             // 0x6700
        public static int CARD_SW1SW2_ERR_CLA_FUNCTION_NOT_SUPPORTED = 0x6800;      // 0x68XX
        public static int CARD_SW1SW2_ERR_CMD_NOT_ALLOWED = 0x6900;                 // 0x69XX
        public static int CARD_SW1SW2_ERR_P1P2_P2_QUALIFIES = 0x6A00;               // 0x6AXX
        public static int CARD_SW1SW2_ERR_P1P2 = 0x6B00;                            // 0x6B00
        public static int CARD_SW1SW2_ERR_LE_FIELD = 0x6C00;                        // 0x6CXX - Wrong L e  field; SW2 encodes the exact number of available data bytes (see text below) 
        public static int CARD_SW1SW2_ERR_INS_BYTE = 0x6D00;                        // 0x6D00
        public static int CARD_SW1SW2_ERR_CLA_BYTE = 0x6E00;                        // 0x6E00
        public static int CARD_SW1SW2_UNKNOWN_ERROR = 0x6F00;                       // 0x6F00

        public static int CARD_SW1SW2_ERR_CMD_CHAIN_NOT_PERMITTED = 0x6884;
        
        public static int CARD_SW1SW2_LAST_CMD_OF_CHAIN_EXPECTED = 0x6883;
        public static int CARD_SW1SW2_P1P2_ERROR = 0x6A86;
    }

    /// <summary>
    /// 
    /// </summary>
    class card
    {
        card()
        {
        }
    }
}
