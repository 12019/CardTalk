using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk
{
    class analyseATR
    {
        private const byte _directConvention = 0x3B;
        private const byte _indirectConvention = 0x3F;

        private const int _tsPosition = 0;
        private const int _t0Position = 1;

        private int _Fi;    // (TA1) Clock rate conversion factor
        private int _f;     // (TA1) max frequency (MHz)
        private int _Di;    // (TA1) bit rate conversion factor
        private int _N;     // (TC1) extra guardtime 
        private int _communicationProtocol; // (TDi) Communcation Protocol
        private int _IFSC;  // (TA3) Information Field Size

        private int _BWI;
        private int _CWI;
        private int _CWT;   // (TB3) Character Waiting Time CWT = (11 + 2^CWI)etu
        private int _BWT;   // (TB3) Block Waiting Time BWT = 11 + (2^BWI * 960 * Fd/f)

        private int _currPosition;
             
        private int _ta1Position;
        private int _tb1Position;
        private int _tc1Position;
        private int _td1Position;
        
        private int _ta2Position;
        private int _tb2Position;
        private int _tc2Position;
        private int _td2Position;
        
        private int _ta3Position;
        private int _tb3Position;
        private int _tc3Position;
        private int _td3Position;

        private int _historicalBytePosition;
        private int _tckPosition;
        
        private String _atr;
        private byte[] _atrBA;
        private int _atrLength;

        private Boolean _isATROk; 

        private String _TS;
        private String _T0;

        private String _TA1;
        private String _TB1;
        private String _TC1;
        private String _TD1;

        private Boolean _2ndInterfaceCharExists;
        private String _TA2;
        private String _TB2;
        private String _TC2;
        private String _TD2;

        private Boolean _3rdInterfaceCharExists;
        private String _TA3;
        private String _TB3;
        private String _TC3;
        private String _TD3;

        private int _numHistoricalBytes;
        private String _historicalBytes;
        private String _TCK;
        
        public String ATR_TO_ANALYSE
        {
            get { return _atr; }
            set { _atr = value; initATR(); analyseNow(); }
        }

        public int ATR_LENGTH { get { return _atrLength; } }
        public Boolean IS_ATR_OK { get { return _isATROk; } }
        public String TS_BYTE { get { return _TS; } }
        public String T0_BYTE { get { return _T0; } }

        public String TA1_BYTE { get { return _TA1; } }
        public String TB1_BYTE { get { return _TB1; } }
        public String TC1_BYTE { get { return _TC1; } }
        public String TD1_BYTE { get { return _TD1; } }

        public String TA2_BYTE { get { return _TA2; } }
        public String TB2_BYTE { get { return _TB2; } }
        public String TC2_BYTE { get { return _TC2; } }
        public String TD2_BYTE { get { return _TD2; } }
        
        public String TA3_BYTE { get { return _TA3; } }
        public String TB3_BYTE { get { return _TB3; } }
        public String TC3_BYTE { get { return _TC3; } }
        public String TD3_BYTE { get { return _TD3; } }

        public int NUM_HISTORICAL_BYTES { get { return _numHistoricalBytes; } }
        public String HISTORICAL_BYTES { get { return _historicalBytes; } }
        public String CHECK_BYTE { get { return _TCK; } }

        public String displayBox = " +-----+-------+------+-------------------------------------------------+\n";
        public String displayBox1 = " | POS | Value | byte | Description                                     |\n";
        private String displayInfoTS = " | {0}  | {1}    | TS   | Initial Character                               |\n";
        private String displayInfoT0 = " | {0}  | {1}    | T0   | Format byte                                     |\n";
        private String displayInfoTA1 = " | {0}  | {1}    | TA1  | Global Interface byte, encodes Fi, Di           |\n";
        private String displayInfoTB1 = " | {0}  | {1}    | TB1  | Global deprecated                               |\n";
        private String displayInfoTC1 = " | {0}  | {1}    | TC1  | Global, encodes N                               |\n";
        private String displayInfoTD1 = " | {0}  | {1}    | TD1  | Structural, encodes Y2 and T                    |\n";
        private String highNibbleInfo = " |       High nibble 0x{0} b({1})                                        |\n";
        private String nibbleInfoB4 = " |                    b4 - {0} - TD{1}                              |\n";
        private String nibbleInfoB3 = " |                    b3 - {0} - TC{1}                              |\n";
        private String nibbleInfoB2 = " |                    b2 - {0} - TB{1}                              |\n";
        private String nibbleInfoB1 = " |                    b1 - {0} - TA{1}                              |\n";
        private String lowNibbleInfo = " |       Low nibble 0x{0} - {1}";

        public String DISPLAY_INFO_TS { get { return String.Format(displayInfoTS, _tsPosition.ToString("X2"), _TS); } }
        public String DISPLAY_INFO_T0 { get { return String.Format(displayInfoT0, _t0Position.ToString("X2"), _T0); } }
        
        public String DISPLAY_INFO_TA1 { get { if (_TA1 != "") return String.Format(displayInfoTA1, _ta1Position.ToString("X2"), _TA1); else return ""; } }
        public String DISPLAY_INFO_TB1 { get { if (_TB1 != "") return String.Format(displayInfoTB1, _tb1Position.ToString("X2"), _TB1); else return ""; } }
        public String DISPLAY_INFO_TC1 { get { if (_TC1 != "") return String.Format(displayInfoTC1, _tc1Position.ToString("X2"), _TC1); else return ""; } }
        public String DISPLAY_INFO_TD1 { get { if (_TD1 != "") return String.Format(displayInfoTD1, _td1Position.ToString("X2"), _TD1); else return ""; } }


        public String DISPLAY_HIGH_NIBBLE(String infoByte)
        {
            String highNbleInfo = "";
            String lowNbleInfo = "";
            int highNibble = 0;
            int lowNibble = 0;
            int i = 0;
            if ("T0" == infoByte)
            {
                highNibble = (_atrBA[_t0Position] & 0xF0) >> 4;
                lowNibble = (_atrBA[_t0Position] & 0x0F);
                lowNbleInfo = String.Format(lowNibbleInfo, lowNibble.ToString("X"), (lowNibble.ToString() + " Historical bytes present @ position " + (_historicalBytePosition + 1).ToString("d2") + "     |\n"));
                i = 1;
            }

            if ("TD1" == infoByte)
            {
                highNibble = (_atrBA[_td1Position] & 0xF0) >> 4;
                lowNibble = (_atrBA[_td1Position] & 0x0F);
                lowNbleInfo = String.Format(lowNibbleInfo, lowNibble.ToString("X"), ("Communication protocol type T=" + lowNibble.ToString() + "               |\n"));
                i = 2;
            }

            if ("TD2" == infoByte)
            {
                highNibble = (_atrBA[_td2Position] & 0xF0) >> 4;
                lowNibble = (_atrBA[_td2Position] & 0x0F);
                lowNbleInfo = String.Format(lowNibbleInfo, lowNibble.ToString("X"), ("Communication protocol type T=" + lowNibble.ToString() + "               |\n"));
                i = 2;
            }

            if ("TD3" == infoByte)
            {
                highNibble = (_atrBA[_td3Position] & 0xF0) >> 4;
                lowNibble = (_atrBA[_td3Position] & 0x0F);
                lowNbleInfo = String.Format(lowNibbleInfo, lowNibble.ToString("X"), ("Communication protocol type T=" + lowNibble.ToString() + "               |\n"));
                i = 2;
            }

            highNbleInfo = String.Format(highNibbleInfo, highNibble.ToString("X"), Convert.ToString(highNibble, 2));
            if (0x08 == (highNibble & 0x08))
            {
                highNbleInfo += String.Format(nibbleInfoB4, "1", (i.ToString() + " present"));
            }
            else
            {
                highNbleInfo += String.Format(nibbleInfoB4, "0", (i.ToString() + " absent "));
            }

            if (0x04 == (highNibble & 0x04))
            {
                highNbleInfo += String.Format(nibbleInfoB3, "1", (i.ToString() + " present"));
            }
            else
            {
                highNbleInfo += String.Format(nibbleInfoB3, "0", (i.ToString() + " absent "));
            }

            if (0x02 == (highNibble & 0x02))
            {
                highNbleInfo += String.Format(nibbleInfoB2, "1", (i.ToString() + " present"));
            }
            else
            {
                highNbleInfo += String.Format(nibbleInfoB2, "0", (i.ToString() + " absent "));
            }

            if (0x01 == (highNibble & 0x01))
            {
                highNbleInfo += String.Format(nibbleInfoB1, "1", (i.ToString() + " present"));
            }
            else
            {
                highNbleInfo += String.Format(nibbleInfoB1, "0", (i.ToString() + " absent "));
            }
            return highNbleInfo + lowNbleInfo;
        }

        public analyseATR(String atr)
        {
            _atr = atr;

            initATR();

            analyseNow();
        }

        private void initATR()
        {
            _atrLength = _atr.Replace(" ", "").Length / 2;
            _atrBA = utils.StringToByteArray(_atr); 
            resetATRChars();
        }

        private void resetATRChars()
        {
            _TS = _T0 = _TA1 = _TB1 = _TC1 = _TD1 = _TA2 = _TB2 = _TC2 = _TD2 = _TA3 = _TB3 = _TC3 = _TD3 = _historicalBytes = _TCK = null;
            _isATROk = _2ndInterfaceCharExists = _3rdInterfaceCharExists = false;
            _currPosition = _numHistoricalBytes = 0;
        }

        private void analyseNow()
        {
            handleTS();

            handleT0();

            // Handle first interface bytes
            handleTA1();

            handleTB1(_tb1Position);

            handleTC1();

            handleTDi(1, _td1Position);

            // Handle second interface bytes
            handleTA2();

            handleTB1(_tb1Position);

            handleTC2();

            handleTDi(2, _td2Position);

            handleTA3();

            handleTB3();
        }

        private void handleTS()
        {
            byte ts = _atrBA[_tsPosition];
            if ((null == _atr) || ((_directConvention != ts) && (_indirectConvention != ts)))
            {
                _isATROk = false;
            }
            else
            {
                _TS = utils.ByteToString(ts);
                _currPosition++;
            }
        }

        private void handleT0()
        {
            byte ts = _atrBA[_t0Position];
            _T0 = utils.ByteToString(ts);
            _currPosition++;
            //byte bitmapNibble = (byte)(ts & 0xF0);

            // Check which of the FIRST interface bytes are present (TA1 TB1 TC1 TD1)
            // T0 encoding as follows
            // BIT position => 8  7  6  5  4  3  2  1
            //                 |  |  |  |  \________/ => Length of historical bytes
            //                 |  |  |  +------------ => TA1 present
            //                 |  |  +--------------- => TB1 present
            //                 |  +------------------ => TC1 present
            //                 +--------------------- => TD1 present
            if (0x10 == (ts & 0x10))
            {
                // TA1 present
                _ta1Position = _currPosition++;
            }
            if (0x20 == (ts & 0x20))
            {
                // TB1 present
                _tb1Position = _currPosition++;
            }
            if (0x40 == (ts & 0x40))
            {
                // TC1 present
                _tc1Position = _currPosition++;
            }
            if (0x80 == (ts & 0x80))
            {
                // TD1 present
                _td1Position = _currPosition++;
            }

            //byte numHistoricalChars = (byte)(ts & 0x0F);
            _numHistoricalBytes = (int)(ts & 0x0F);
        }

        /// <summary>
        /// TA1 will contain 
        ///     Clock Conversion Factor (Fi/f) in high nibble
        ///     Bit Rate Conversion Factor (Di) in low nibble
        ///     
        ///  These conversion factors are standard as defined in ISO7816
        /// </summary>
        private void handleTA1()
        {
            // Proceed only if we have a TA1 byte
            if (0 != _td1Position)
            {
                _TA1 = utils.ByteToString(_atrBA[_ta1Position]);
                int fif = (_atrBA[_ta1Position] & 0xF0) >> 4;
                int di = _atrBA[_ta1Position] & 0x0F;

                if (0 == fif) { _Fi = 372; _f = 4; }
                else if (1 == fif) { _Fi = 372; _f = 5; }
                else if (2 == fif) { _Fi = 558; _f = 6; }
                else if (3 == fif) { _Fi = 744; _f = 8; }
                else if (4 == fif) { _Fi = 1116; _f = 12; }
                else if (5 == fif) { _Fi = 1488; _f = 16; }
                else if (6 == fif) { _Fi = 1860; _f = 20; }
                else if (7 == fif) { _Fi = 0; _f = 0; }
                else if (8 == fif) { _Fi = 0; _f = 0; }
                else if (9 == fif) { _Fi = 512; _f = 5; }
                else if (10 == fif) { _Fi = 768; _f = 7; }   // Should be 7.5
                else if (11 == fif) { _Fi = 1024; _f = 10; }
                else if (12 == fif) { _Fi = 1536; _f = 15; }
                else if (13 == fif) { _Fi = 2048; _f = 20; }
                else if (14 == fif) { _Fi = 0; _f = 0; }
                else if (15 == fif) { _Fi = 0; _f = 0; }

                if (0 == di) { _Di = 0; }
                else if (1 == di) { _Di = 1; }
                else if (2 == di) { _Di = 2; }
                else if (3 == di) { _Di = 4; }
                else if (4 == di) { _Di = 8; }
                else if (5 == di) { _Di = 16; }
                else if (6 == di) { _Di = 32; }
                else if (7 == di) { _Di = 64; }
                else if (8 == di) { _Di = 12; }
                else if (9 == di) { _Di = 20; }
                else if (10 == di) { _Di = 0; }
                else if (11 == di) { _Di = 0; }
                else if (12 == di) { _Di = 0; }
                else if (13 == di) { _Di = 0; }
                else if (14 == di) { _Di = 0; }
                else if (15 == di) { _Di = 0; }
            }
        }

        private void handleTB1(int position)
        {
            // Proceed only if we have a TB1 byte
            if (0 != position)
            {
                _TB1 = utils.ByteToString(_atrBA[position]);
                // If the TB1 byte is present it should have a value of 0x00
                // This is because according to ISO7816 TB1 and TB2 are deprecatd 
                //  and the card should not transmit them
                if (0x00 != _atrBA[position])
                {
                    // TODO: Throw some kinda error
                }
            }
        }

        private void handleTC1()
        {
            // Proceed only if we have a TC1 byte
            if (0 != _tc1Position)
            {
                _TC1 = utils.ByteToString(_atrBA[_tc1Position]);
                _N = _atrBA[_tc1Position];
            }
        }

        private void handleTDi(int tdCounter, int tdPosition)
        {
            // Proceed only if we have a TD1 byte
            if (0 != tdPosition)
            {
                // High nibble of TD1 is an indicator of what other interface bytes are available
                // Low nibble indicates the protocol type
                
                // Check which of the SECOND interface bytes are present (TA1 TB1 TC1 TD1)
                // T0 encoding as follows
                // BIT position => 8  7  6  5  4  3  2  1
                //                 |  |  |  |  \________/ => Length of historical bytes
                //                 |  |  |  +------------ => TA1 present
                //                 |  |  +--------------- => TB1 present
                //                 |  +------------------ => TC1 present
                //                 +--------------------- => TD1 present
                byte ts = _atrBA[tdPosition];
                int ta, tb, tc, td;
                ta = tb = tc = td = 0;

                if (0x10 == (ts & 0x10))
                {
                    // TA(i+1) present
                    ta = _currPosition++;
                }
                if (0x20 == (ts & 0x20))
                {
                    // TB(i+1) present
                    tb = _currPosition++;
                }
                if (0x40 == (ts & 0x40))
                {
                    // TC(i+1) present
                    tc = _currPosition++;
                }
                if (0x80 == (ts & 0x80))
                {
                    // TD(i+1) present
                    td = _currPosition++;
                }

                if (1 == tdCounter)
                {
                    _TD1 = utils.ByteToString(_atrBA[tdPosition]);
                    _ta2Position = ta;
                    _tb2Position = tb;
                    _tc2Position = tc;
                    _td2Position = td;
                }
                else if (2 == tdCounter)
                {
                    _TD2 = utils.ByteToString(_atrBA[tdPosition]);
                    _ta3Position = ta;
                    _tb3Position = tb;
                    _tc3Position = tc;
                    _td3Position = td;
                }

                // If td is 0 then the current position indicates the start of the historical characters
                if ( (0 == td) && (0 != _numHistoricalBytes) )
                {
                    _historicalBytePosition = _currPosition;
                    if (0 != _communicationProtocol)
                    {
                       _tckPosition = _currPosition + _numHistoricalBytes;
                    }
                }

                // Get communication protocol
                _communicationProtocol = (_atrBA[tdPosition] & 0x0F);
            }
        }

        private void handleTA2()
        {
        }

        private void handleTC2()
        {
        }

        /// <summary>
        /// Contains Information Field Size IFSC
        /// </summary>
        private void handleTA3()
        {
            if (0 != _ta3Position)
                _IFSC = _atrBA[_ta3Position];
        }

        private void handleTB3()
        {
            if (0 != _tb3Position)
            {
                // bits 8-5 => BWI
                // bits 4-1 => CWI

                // Based on the BWI and CWI calculate BWT and CWT
                _BWI = (_atrBA[_tb3Position] & 0xF0) >> 4;
                _CWI = (_atrBA[_tb3Position] & 0x0F);

                _CWT = (int)(Math.Pow(2, _CWI) + 11);
                _BWT = (int)(11 + (Math.Round(Math.Pow(2, _BWI) * 960 * 372 / (_f * 1000000))));
            }
        }

        private void calculateCheckSum()
        {
        }

        public String giveExplainedATR()
        {
            String result = null;

            return result;
        }
    }
}
