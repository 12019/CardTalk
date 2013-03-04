using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTalk.COMMANDS
{
    static class ISO7816Commands
    {
        public static int T1_CASE1_LEN              = 4; // CLA, INS, P1, P2                 - Min=4, Max=4
        public static int T1_CASE2_LEN              = 5; // CLA, INS, P1, P2, Le             - Min=5, Max=5
        public static int T1_CASE3_LEN              = 6; // CLA, INS, P1, P2, Lc, Data       - Min=6, Max=(5+Lc)
        public static int T1_CASE4_LEN              = 7; // CLA, INS, P1, P2, Lc, Data, Le   - Min=7, Max=(6+Lc)

        public static int T1_CLA_OFFSET             = 0;
        public static int T1_INS_OFFSET             = 1;
        public static int T1_P1_OFFSET              = 2;
        public static int T1_P2_OFFSET              = 3;
        public static int T1_P3_OFFSET              = 4;
        public static int T1_LC_OFFSET              = 4;
        public static int T1_DATA_OFFSET            = 5;

        public static byte ERASE_BINARY             = 0x0E;
        public static byte VERIFY                   = 0x20;
        public static byte MANAGE_CHANNEL           = 0x70;
        public static byte EXTERNAL_AUTHENTICATE    = 0x82;
        public static byte GET_CHALLENGE            = 0x84;
        public static byte INTERNAL_AUTHENTICATE    = 0x88;
        public static byte SELECT_FILE              = 0xA4;
        public static byte READ_BINARY              = 0xB0;
        public static byte READ_RECORD              = 0xB2;
        public static byte GET_RESPONSE             = 0xC0;
        public static byte ENVELOPE                 = 0xC2;
        public static byte GET_DATA                 = 0xCA;
        public static byte WRITE_BINARY             = 0xD0;
        public static byte WRITE_RECORD             = 0xD2;
        public static byte UPDATE_BINARY            = 0xD6;
        public static byte PUT_DATA                 = 0xDA;
        public static byte UPDATE_RECORD            = 0xDC;
        public static byte APPEND_RECORD            = 0xE2;

        public static int MF_ID                     = 0x3F00;
        public static int EF_DIR                    = 0x2F00;
        public static int EF_ATR                    = 0x2F01;
        //public static int EF_ARR                    = 0x;

        public static int DF_TELECOM                = 0x7F10;
        public static int DF_GSM                    = 0x7F20;   // or 0x7F21
        public static int DF_GRAPHICS               = 0x5F50;
        public static int DF_PHONEBOOK              = 0x5F3A;

        public static byte[] ADF_USIM               = { 0xA0, 0x00, 0x00, 0x00, 0x87 };
        public static int ADF_USIM_DF_PHONEBOOK     = 0x5F3A;
        public static int ADF_USIM_DF_GSM_ACCESS    = 0x5F3B;
        public static int ADF_USIM_DF_MExE          = 0x5F3C; // Mobile Station Execution Environment
        public static int ADF_USIM_EF_IMSI_FID      = 0x6F07;
        public static int ADF_USIM_EF_IMSI_SFI      = 0x07;
        public static int ADF_USIM_EF_KEYS_FID      = 0x6F08;
        public static int ADF_USIM_EF_KEYS_SFI      = 0x08;
        public static int ADF_USIM_EF_KEYS_PS_FID   = 0x6F09;
        public static int ADF_USIM_EF_KEYS_PS_SFI   = 0x09;

        public static int ADF_USIM_EF_HPLMN_FID     = 0x6F31;
        public static int ADF_USIM_EF_HPLMN_SFI     = 0x12;

        public static int ADF_USIM_EF_UST_FID       = 0x6F38;
        public static int ADF_USIM_EF_UST_SFI       = 0x12;

        public static int ADF_USIM_EF_ACC_FID       = 0x6F78;
        public static int ADF_USIM_EF_ACC_SFI       = 0x12;

        public static int ADF_USIM_EF_FPLMN_FID     = 0x6F7B;
        public static int ADF_USIM_EF_FPLMN_SFI     = 0x0D;

        public static int ADF_USIM_EF_LOCI_FID      = 0x6F7E;
        public static int ADF_USIM_EF_LOCI_SFI      = 0x0B;

        public static int ADF_USIM_EF_AD_FID        = 0x6FAD;
        public static int ADF_USIM_EF_AD_SFI        = 0x03;

        public static int ADF_USIM_EF_ECC_FID       = 0x6FB7;
        public static int ADF_USIM_EF_ECC_SFI       = 0x01;

        public static int ADF_USIM_EF_PS_LOCI_FID   = 0x6F73;
        public static int ADF_USIM_EF_PS_LOCI_SFI   = 0x0C;

        public static int ADF_USIM_EF_START_HFN_FID = 0x6F7B;
        public static int ADF_USIM_EF_START_HFN_SFI = 0x0F;

        public static int ADF_USIM_EF_THRESHOLD_FID = 0x6F5C;
        public static int ADF_USIM_EF_THRESHOLD_SFI = 0x10;

        public static int ADF_USIM_EF_ARR_FID       = 0x6F06;
        public static int ADF_USIM_EF_ARR_SFI       = 0x17;

        public static int MF_EF_NETPAR              = 0x2FC4;
        public static int MF_EF_ELP                 = 0x2F05;
        public static int MF_EF_ICCID               = 0x2FE2;
        
        public static int DF_GSM_EF_ACM             = 0x6F39;
        public static int DF_GSM_EF_ACM_MAX         = 0x6F37;
        public static int DF_GSM_EF_FPLMN           = 0x6F7B;
        public static int DF_GSM_EF_HPLMN           = 0x6F31;
        public static int DF_GSM_EF_IMSI            = 0x6F07;   // IMSI - International Mobile Subscriber Identity
        public static int DF_GSM_EF_KC              = 0x6F20;   // Key Kc

        public static int DF_GSM_EF_LOCI            = 0x6F7E;   // Location Information
        public static int DF_GSM_EF_LP              = 0x6F05;   // Language Preference
        public static int DF_GSM_EF_PHASE           = 0x6FAE;
        public static int DF_GSM_EF_PLMN_SEL        = 0x6F30;   // Public Land Mobile Network Selector
        public static int DF_GSM_EF_PUCT            = 0x6F41;   // Price Per unit and Currency Table
        public static int DF_GSM_EF_SPN             = 0x6F46;   // Service Provider Name
        public static int DF_GSM_EF_SST             = 0x6F38;   // SIM Service Table
        
        public static int DF_GSM_DF_GRAPHICS_EF_IMG = 0x4f20;
        //public static int DF_GSM_DF_GRAPHICS_EF_IMG_DATAX = 0x4f20;

        public static int DF_TELECOM_EF_ADN         = 0x6F3A;   // Abbreviated Dialling Numbers
        public static int DF_TELECOM_EF_FDN         = 0x6F3B;   // Fixed Dialling Numbers
        public static int DF_TELECOM_EF_LND         = 0x6F44;   // Last Number Dialled
        public static int DF_TELECOM_EF_MSISDN      = 0x6F40;   // Mobile Station ISDN Number
        public static int DF_TELECOM_EF_SDN         = 0x6F49;   // Service Dialling Numbers
        public static int DF_TELECOM_EF_SMS         = 0x6F3C;   // SMS
        public static int DF_TELECOM_EF_SMSP        = 0x6F42;   // Short Message Service Parameters
        public static int DF_TELECOM_EF_SMSS        = 0x6F43;   // Short Message Service Status

    }
}
