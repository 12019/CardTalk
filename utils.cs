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
            if (null == byteArray)
            {
                return "";
            }
            else
            {
                string hex = BitConverter.ToString(byteArray);
                return hex.Replace("-", " ");
            }
        }

        public static byte[] StringToByteArray(String hex)
        {
            String stringToWork = hex.Replace(" ", "");
            byte[] byteArray = new byte[stringToWork.Length / 2];
            int j = 0;
            for (int i = 0; i < stringToWork.Length; i++)
            {
                byte tempByte;
                String tempString = stringToWork.Substring(i, 2);
                tempByte = byte.Parse(tempString, System.Globalization.NumberStyles.HexNumber);
                byteArray[j] = tempByte;
                i += 1;
                j++;
            }
            return byteArray;
        }

        public static byte StringToByte(String hex, int position)
        {
            String tempString = hex.Substring(position, 2);
            return byte.Parse(tempString, System.Globalization.NumberStyles.HexNumber);
        }

        public static String prepareInfoForRunningLog(String inputInfo)
        {
            byte[] infoToPrepare = StringToByteArray(inputInfo);
            String preparedInfo = "";

            String oneLine = "";
            String asciiEquivalent = "";
            int i = 0;
            int byteCounter = 1;
            
            do
            {
                String temp = utils.ByteToString(infoToPrepare[i]);

                oneLine += temp + " ";
                asciiEquivalent += utils.printableASCII(infoToPrepare[i]);

                if (8 == byteCounter)
                {
                    oneLine += "   ";
                }
                else if (16 == byteCounter)
                {
                    oneLine += "   ";
                    byteCounter = 0;
                    preparedInfo += oneLine + asciiEquivalent + "\n";
                    oneLine = "";
                    asciiEquivalent = "";

                    if (i < infoToPrepare.Length - 1)
                        oneLine += "        ";
                }

                byteCounter++;
                i++;
            } while (i < infoToPrepare.Length);

            if (oneLine != "")
            {
                int numCharsInserted = oneLine.Length / 3;

                for (int j = 0; j < (18 - numCharsInserted); j++)
                {
                    oneLine += "   ";
                }

                if (infoToPrepare.Length > 16)
                    oneLine += "      ";

                preparedInfo += oneLine + asciiEquivalent + "\n";
            }

            return preparedInfo;
        }

        public static String printableASCII(byte byteToPrint)
        {
            String ascii = null;

            if ((byteToPrint < 0x20) || (byteToPrint > 0x7E))
            {
                ascii = ".";
            }
            else
            {
                ascii = ((char)byteToPrint).ToString();
            }

            return ascii;
        }

        public static String ByteToString(byte byteToConvert)
        {
            String byteAsString = null;

            // TODO: Do this...
            byteAsString = byteToConvert.ToString("X2");
            
            return byteAsString;
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
