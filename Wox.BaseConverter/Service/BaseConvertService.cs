using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.BaseConverter.Service
{
    public class BaseConvertService : IBaseConvertService
    {
        public string Convert(string value, int baseOrigin, int baseResult)
        {
            long realValue = ArbitraryToDecimalSystem(value, baseOrigin);
            return DecimalToArbitrarySystem(realValue, baseResult);
        }

        private const string Digits = "0123456789abcdefghijklmnopqrstuvwxyz";
        private const int BitsInLong = 64;

        /// <summary>
        /// Converts the given decimal number to the numeral system with the
        /// specified radix (in the range [2, 36]).
        /// </summary>
        /// <param name="decimalNumber">The number to convert.</param>
        /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        private string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            //Code from https://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net

            if (radix < 2 || radix > Digits.Length)
            {
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());
            }

            if (decimalNumber == 0)
            {
                return "0";
            }

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new string(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        /// <summary>
        /// Converts the given number from the numeral system with the specified
        /// radix (in the range [2, 36]) to decimal numeral system.
        /// </summary>
        /// <param name="number">The arbitrary numeral system number to convert.</param>
        /// <param name="radix">The radix of the numeral system the given number
        /// is in (in the range [2, 36]).</param>
        /// <returns></returns>
        private static long ArbitraryToDecimalSystem(string number, int radix)
        {
            // Code from https://www.pvladov.com/2012/07/arbitrary-to-decimal-numeral-system.html

            if (radix < 2 || radix > Digits.Length)
            {
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());
            }

            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            // Make sure the arbitrary numeral system number is in upper case
            number = number.ToLowerInvariant();

            long result = 0;
            long multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }

                int digit = Digits.IndexOf(c);
                if (digit == -1)
                {
                    throw new ArgumentException
                    (
                        "Invalid character in the arbitrary numeral system number",
                        "number"
                    );
                }
                if (digit >= radix)
                {
                    throw new ArgumentException
                    (
                        string.Format("Character [{0}] is invalid in base {1}",c,radix)
                    );
                }

                result += digit * multiplier;
                multiplier *= radix;
            }

            return result;
        }
    }
}
