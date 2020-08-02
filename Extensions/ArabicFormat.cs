using System;
using System.Text;

namespace AllWithOneAccord.Extensions
{
    public static class ArabicFormat
    {
        public static string RemoveTshkela(string s)
        {
            s = s.Replace("ْ", ""); //   ْ
            s = s.Replace("َ", ""); //   َ
            s = s.Replace("ِ", ""); //   ِ
            s = s.Replace("ّ", ""); //   ّ
            s = s.Replace("ُ", ""); //   ُ
            s = s.Replace("ً", ""); //   ً
            s = s.Replace("ٍ", ""); //  ٍ
            s = s.Replace("ّ", ""); // ~
            s = s.Replace("ٌ", ""); //  ٌ
            return s;
        }

        public static string ArabicNumber(int input) => ConvertToEasternArabicNumerals(input.ToString());

        public static string ArabicNumber(string input) => ConvertToEasternArabicNumerals(input);

        public static string ConvertToEasternArabicNumerals(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var utf8Encoder = new UTF8Encoding();
            var utf8Decoder = utf8Encoder.GetDecoder();
            var convertedChars = new StringBuilder();
            var convertedChar = new char[1];
            var bytes = new byte[] { 217, 160 };
            var inputCharArray = input.ToCharArray();
            foreach (var c in inputCharArray)
            {
                if (char.IsDigit(c))
                {
                    bytes[1] = Convert.ToByte(160 + char.GetNumericValue(c));
                    utf8Decoder.GetChars(bytes, 0, 2, convertedChar, 0);
                    convertedChars.Append(convertedChar[0]);
                }
                else
                {
                    convertedChars.Append(c);
                }
            }
            return convertedChars.ToString();
        }
        //public static string ConvertToEasternArabicNumerals(string input)
        //{
        //    if (string.IsNullOrEmpty(input))
        //        return input;

        //    var convertedChars = new StringBuilder();

        //    var inputCharArray = input.ToCharArray();
        //    foreach (var c in inputCharArray)
        //    {
        //        if (char.IsDigit(c))
        //        {
        //            var arabicNumber = Convert.ToByte(160 + char.GetNumericValue(c));
        //            var bytes = new byte[] { 217, arabicNumber };

        //            var utf8Encoder = new UTF8Encoding();
        //            var utf8Decoder = utf8Encoder.GetDecoder();
        //            var convertedChar = new char[1];
        //            utf8Decoder.GetChars(bytes, 0, 2, convertedChar, 0);
        //            convertedChars.Append(convertedChar[0]);
        //        }
        //        else
        //        {
        //            convertedChars.Append(c);
        //        }
        //    }
        //    return convertedChars.ToString();
        //}
    }
}
