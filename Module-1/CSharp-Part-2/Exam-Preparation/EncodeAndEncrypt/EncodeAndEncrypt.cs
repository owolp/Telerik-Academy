namespace EncodeAndEncrypt
{
    using System;
    using System.Linq;
    using System.Text;

    class EncodeAndEncrypt
    {
        static void Main()
        {
            var message = Console.ReadLine();
            var cypher = Console.ReadLine();

            Console.WriteLine(Encode(Encrypt(message, cypher) + cypher) + cypher.Length);

        }

        static string Encrypt(string message, string cypher)
        {
            StringBuilder result = new StringBuilder();

            if (message.Length >= cypher.Length)
            {
                for (int mIndex = 0, cIndex = 0; mIndex < message.Length; mIndex++, cIndex++)
                {
                    if (cIndex == cypher.Length)
                    {
                        cIndex = 0;
                    }
                    int cypherDigit = cypher[cIndex] - 'A';
                    int messageDigit = message[mIndex] - 'A';
                    char encryptDigit = (char)((messageDigit ^ cypherDigit) + 'A');
                    result.Append(encryptDigit);
                }
            }
            else
            {
                var messageArray = message.ToCharArray();

                for (int mIndex = 0, cIndex = 0; mIndex < messageArray.Count(); mIndex++, cIndex++)
                {
                    int messageDigit = message[mIndex] - 'A';
                    int cypherDigit = cypher[cIndex] - 'A';
                    char encryptDigit = 'a';
                    while (true)
                    {
                        int tempDigit = ((messageDigit ^ cypherDigit) + 'A');
                        if (cIndex + messageArray.Length >= cypher.Length)
                        {
                            encryptDigit = (char)tempDigit;
                            cIndex = mIndex;
                            break;
                        }
                        messageDigit = tempDigit - 'A';
                        cypherDigit = cypher[cIndex + messageArray.Length] - 'A';
                        cIndex += messageArray.Length;
                    }
                    result.Append(encryptDigit);
                }
            }

            return result.ToString();
        }

        static string Encode(string encryptedMessage)
        {
            StringBuilder result = new StringBuilder();

            int currentLetterCount = 1;

            for (int index = 1; index < encryptedMessage.Length; index++)
            {

                if (encryptedMessage[index - 1] == encryptedMessage[index])
                {
                    currentLetterCount++;
                }
                else
                {
                    #region ifelse
                    //if (currentLetterCount > 2)
                    //{
                    //    result.Append(currentLetterCount);
                    //    result.Append(encryptedMessage[index - 1]);
                    //}
                    //else if(currentLetterCount == 2)
                    //{
                    //    result.Append(encryptedMessage[index - 1]).Append(encryptedMessage[index - 1]);
                    //}
                    //else
                    //{
                    //    result.Append(encryptedMessage[index - 1]);
                    //}

                    //currentLetterCount = 1;
                    #endregion
                    result = Calculate(encryptedMessage, currentLetterCount, result, index);

                    currentLetterCount = 1;
                }
            }

            result = Calculate(encryptedMessage, currentLetterCount, result, encryptedMessage.Length);
            #region ifelse
            //if (currentLetterCount > 2)
            //{
            //    result.Append(currentLetterCount);
            //    result.Append(encryptedMessage[encryptedMessage.Length - 1]);
            //}
            //else if (currentLetterCount == 2)
            //{
            //    result.Append(encryptedMessage[encryptedMessage.Length - 1]).Append(encryptedMessage[encryptedMessage.Length - 1]);
            //}
            //else
            //{
            //    result.Append(encryptedMessage[encryptedMessage.Length - 1]);
            //}
            #endregion
            return result.ToString();
        }

        static StringBuilder Calculate(string encryptedMessage, int currentLetterCount, StringBuilder result, int index)
        {

            if (currentLetterCount > 2)
            {
                result.Append(currentLetterCount);
                result.Append(encryptedMessage[index - 1]);
            }
            else
            {
                result.Append(new string(encryptedMessage[index - 1], currentLetterCount));
            }

            #region ifelse
            //if (currentLetterCount > 2)
            //{
            //    result.Append(currentLetterCount);
            //    result.Append(encryptedMessage[index - 1]);
            //}
            //else if (currentLetterCount == 2)
            //{
            //    result.Append(new string(encryptedMessage[index - 1], 2));
            //    //result.Append(encryptedMessage[index - 1]).Append(encryptedMessage[index - 1]);
            //}
            //else
            //{
            //    result.Append(encryptedMessage[index - 1]);
            //}
            #endregion

            return result;
        }
    }
}