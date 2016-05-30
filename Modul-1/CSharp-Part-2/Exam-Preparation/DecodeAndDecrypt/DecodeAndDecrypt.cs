// Partial

namespace DecodeAndDecrypt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DecodeAndDecrypt
    {
        static void Main()
        {
            var encryptedMessage = Console.ReadLine();
            char[] encMsgList = encryptedMessage.ToCharArray();

            // lengthOfCypher
            int cypherLength = encMsgList[encMsgList.Length - 1] - '0';

            StringBuilder sb = new StringBuilder();
            for (int i = encryptedMessage.Length - 1 - cypherLength; i < encryptedMessage.Length - 1; i++)
            {
                sb.Append(encryptedMessage[i]);
            }

            // cypher
            var cypher = Convert.ToString(sb);
            sb.Clear();

            for (int i = 0; i < encMsgList.Length - cypherLength - 1 ; i++)
            {
                sb.Append(encMsgList[i]);
            }

            // Encrypt(message, cypher)
            var encryption = "4a3b4caa";
            //var encryption = sb.ToString();
            sb.Clear();

            int position = 0;
            while (true)
            {
                if (position == encryption.Length)
                {
                    break;
                }
                char currentDigit = encryption[position];
                if (char.IsLetter(currentDigit))
                {
                    sb.Append(currentDigit);
                    position++;
                }
                else
                {
                    for (int i = 0; i < currentDigit - '0'; i++)
                    {
                        sb.Append(encryption[position + 1]);
                    }
                    position += 2;
                }
            }

            string encodedText = sb.ToString();





        }
    }
}
