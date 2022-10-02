using System;

namespace simpleTextEncode
{

    /// <summary>
    /// Simple static class for ASCII shift. 
    /// Useful when you want to store something in text (text file, some internet transmission), 
    /// but you want to hide it from sniffer / hacker eyes.
    /// 
    /// Biggest benefit is that it does not modify ascii special chars, like new line. So you can use this in big text files.
    /// 
    /// Author :    Marcin Kaminski (marcin.kaminski.gd (at) gmail.com)
    /// 
    /// </summary>
    public class simpleTextEncoder
    {

        /// <summary>
        /// Constant values: min and max ascii code value;
        /// </summary>
        private static byte ascii_min = 32;
        private static byte ascii_max = 125;

        /// <summary>
        /// Function for easy string encryption
        /// </summary>
        /// <param name="s">String to be encrypted</param>
        /// <returns></returns>
        public static string cipher(string s)
        {
            return converter(s, ascii_min, ascii_max, 66, true);
        }

        /// <summary>
        /// Function for easy string decryption
        /// </summary>
        /// <param name="s">String to be decrypted</param>
        /// <returns></returns>
        public static string decipher(string s)
        {
            return converter(s, ascii_min, ascii_max, 66, false);
        }

        /// <summary>
        /// Function for encryption with your own shift value. This makes possible to encrypt with your own key.
        /// </summary>
        /// <param name="s">String to be encrypted</param>
        /// <param name="shift">How many positions do the ascii code has to be shifted forward</param>
        /// <returns></returns>
        public static string cipher(string s, byte shift)
        {
            return converter(s, ascii_min, ascii_max, shift, true);
        }


        /// <summary>
        /// Function for decryption with your own shift value. This makes possible to decrypt with your own key.
        /// </summary>
        /// <param name="s">String to be decrypted</param>
        /// <param name="shift">How many positions do the ascii code has to be shifted forward</param>
        /// <returns></returns>
        public static string decipher(string s, byte shift)
        {
            return converter(s, ascii_min, ascii_max, shift, false);
        }

        internal static string converter(string s, byte c_min, byte c_max, byte c_shift_in, bool crypt)
        {
            string ret = "";
            int c_delta = (c_max - c_min);
            //shift can not be greater then shift window length
            int c_shift = c_shift_in % c_delta;
            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                int v1 = c1;
                //switch
                if ((c_min <= c1) && (c1 < c_max))
                {
                    //... do magic...
                    if (crypt)
                    {
                        v1 = ((v1 - c_min) + c_shift);
                        if (v1 > c_delta) v1 -= c_delta;
                        v1 += c_min;
                    }
                    else
                    {
                        v1 = ((v1 - c_min) - c_shift);
                        if (v1 < 0) v1 += c_delta;
                        v1 += c_min;
                    }
                    //push the char
                    c1 = Convert.ToChar(v1);
                }
                //
                ret += c1;
            }
            return ret;
        }

    }
}
