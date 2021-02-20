using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.Validator
{
    public static class Validator
    {
        public static string StringValidator(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{nameof(value)} cannot be null.");
            }

            return value.ToUpper();
        }

        public static string StateValidator(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{nameof(value)} cannot be null.");
            }
            else if (value.Length != 2)
            {
                throw new Exception("Please use your state abbrivation.");
            }

            return value.ToUpper();
        }

        public static string ZipcodeValidator(this string value)
        {
            if (value.Length != 5)
            {
                throw new Exception("Invalid Zipcode.");
            }

            return value;
        }

        public static int OrderValidator(this int value)
        {
            if (value > 30)
            {
                throw new Exception("Unreasonable amount of products ordered.");
            }

            return value;
        }
    }
}
