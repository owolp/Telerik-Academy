namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for String extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The method converts a string with the MD5 algorithm.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Returns the hashed sum of the provided string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// The method checks if the provided string contains special words.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>Returns true if the input string contains the special words, otherwise returns false.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// The method tries to parse the provided string to short.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>Returns a short variable if the string can be converted, otherwise returns null.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// The method tries to parse the provided string to integer.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>Returns an integer variable if the string can be converted, otherwise returns null.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// The method tries to parse the provided string to long.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>Returns a long variable if the string can be converted, otherwise returns null.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// The method tries to parse the provided string to DateTime.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>Returns a DateTime variable if the string can be converted, otherwise returns null.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// The method capitalizes the first letter from the provided string.
        /// </summary>
        /// <param name="input">The string to be capitalized.</param>
        /// <returns>Returns the provided string if it's null or empty, otherwise returns the capitalized string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// The method gets the substring between two strings.
        /// </summary>
        /// <param name="input">The string from which will be extracted the substrings.</param>
        /// <param name="startString">The start string from which will be extracted the substring.</param>
        /// <param name="endString">The end string till which will be extracted the substring.</param>
        /// <param name="startFrom">The start point of the searching in the provided string.</param>
        /// <returns>
        /// Returns an empty string if the provided string does not contain the start and/or end string.
        /// Returns the substring between the the two strings.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// The method converts all Cyrillic Letters to Latin.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Returns the converted string from Cyrillic to Latin.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// The method converts all Latin Letters to Cyrillic.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Returns the converted string from Latin to Cyrillic.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// The method checks if there are any invalid symbols and replaces them with empty string. 
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>Returns the checked string to a valid one.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// The method checks if there are any invalid symbols and replaces them with empty string.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>Returns the checked string to a valid one.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// The method returns the first N characters provided from the input string.
        /// </summary>
        /// <param name="input">The string from which will be extracted the first N characters.</param>
        /// <param name="charsCount">The number of symbols to be returned.</param>
        /// <returns>If the charsCount is less than the input length returns the first charsCount characters, otherwise returns the full string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// The method returns the file name extension if any.
        /// </summary>
        /// <param name="fileName">The file name to be checked.</param>
        /// <returns>Returns empty sting if there is no extension or the extension is less than 1 characters, or  the input string is empty.
        /// Otherwise returns the file name extension.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// The method converts from file extension to content type.
        /// </summary>
        /// <param name="fileExtension">The file extension to be checked.</param>
        /// <returns>Return the proper content type based on the file extension.
        /// If there is no valid extension returns default message <code>"application/octet-stream"</code>
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// The method converts from string to byte array.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Returns byte array from the string.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
