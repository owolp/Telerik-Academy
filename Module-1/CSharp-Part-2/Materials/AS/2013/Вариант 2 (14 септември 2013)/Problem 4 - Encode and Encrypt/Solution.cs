using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeAndEncrypt
{
    class Program
    {
        const char BaseLetter = 'A';

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();

            var cypherText = Encrypt(message, cypher) + cypher;
            var compressedCypherText = Encode(cypherText) + cypher.Length;

            Console.WriteLine(compressedCypherText);
        }

        private static string Encode(string message)
        {
            StringBuilder encodedTextBuilder = new StringBuilder(message.Length);
            int indexInMessage = 0;
            while (indexInMessage < message.Length)
            {
                char currentSymbol = message[indexInMessage];
                int scanIndex = indexInMessage + 1;
                int repeatLength = 1;
                while (scanIndex < message.Length &&
                    message[scanIndex] == currentSymbol)
                {
                    repeatLength++;
                    scanIndex++;
                }

                indexInMessage = scanIndex;
                if (repeatLength > 2)
                {
                    encodedTextBuilder.Append(repeatLength);
                    encodedTextBuilder.Append(currentSymbol);
                }
                else
                {
                    encodedTextBuilder.Append(new string(currentSymbol, repeatLength));
                }
            }

            return encodedTextBuilder.ToString();
        }

        private static string Encrypt(string message, string cypher)
        {
            StringBuilder cypherTextBuilder = new StringBuilder(message);

            int longer = Math.Max(message.Length, cypher.Length);

            for (int index = 0; index < longer; index++)
            {
                int indexInMessage = index % message.Length;
                int indexInCypher = index % cypher.Length;

                int charInMessageOffset = cypherTextBuilder[indexInMessage] - BaseLetter;
                int charInCypherOffset = cypher[indexInCypher] - BaseLetter;

                cypherTextBuilder[indexInMessage] = (char)(BaseLetter + (charInMessageOffset ^ charInCypherOffset));
            }

            return cypherTextBuilder.ToString();
        }
    }
}
