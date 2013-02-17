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
    static class utils
    {
        // byte array => string http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa

        public static String ByteArrayToString(byte[] byteArray, string byteSeparator)
        {
            string hex = BitConverter.ToString(byteArray);
            return hex.Replace("-", byteSeparator);
        }
        public static String ByteArrayToString(byte[] byteArray)
        {
            string hex = BitConverter.ToString(byteArray);
            return hex.Replace("-", " ");
        }

        public static byte[] StringToByteArray(String hex)
        {
            byte[] byteArray = new byte[hex.Length];

            return byteArray;
        }

        public static String createTLV(int tag, byte[] payload)
        {
            String createdTLV = null;

            return createdTLV;
        }

        public static String getTLVPayload(byte[] tlv)
        {
            String payload = null;

            return payload;
        }
    }
}
