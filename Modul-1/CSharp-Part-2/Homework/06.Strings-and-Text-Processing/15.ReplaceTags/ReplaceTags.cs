namespace ReplaceTags
{
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var openingUrlTag = "<a ";

            var openingHrefTag = "href=\"";
            var closingHrefTag = "\"";

            var closingUrlTag = "\"";

            var openingInfoTag = ">";
            var closingInfoTag = "</a>";

            int position = 0;

            int positionResult = 0;

            StringBuilder url = new StringBuilder();
            StringBuilder info = new StringBuilder();
            StringBuilder output = new StringBuilder();

            while (true)
            {
                if (input.IndexOf(openingUrlTag, position) == -1)
                {
                    for (int i = positionResult; i < input.Length ; i++)
                    {
                        output.Append(input[i]);
                    }
                    break;
                }

                int openingUrlTagIndex = input.IndexOf(openingUrlTag, position);

                int openingHrefTagIndex = input.IndexOf(openingHrefTag, openingUrlTagIndex);
                int closingHrefTagIndex = input.IndexOf(closingHrefTag, openingHrefTagIndex + 6);

                int closingUrlTagIndex = input.IndexOf(closingUrlTag, openingUrlTagIndex + 9);

                int openingInfoTagIndex = input.IndexOf(openingInfoTag, closingUrlTagIndex + 1);
                int closingInfoTagIndex = input.IndexOf(closingInfoTag, openingInfoTagIndex + 1);

                for (int i = openingHrefTagIndex + 6; i < closingHrefTagIndex; i++)
                {
                    url.Append(input[i]);
                }

                for (int i = openingInfoTagIndex + 1; i < closingInfoTagIndex; i++)
                {
                    info.Append(input[i]);
                }

                position = openingUrlTagIndex + 1;


                for (int i = positionResult; i < openingUrlTagIndex; i++)
                {
                    output.Append(input[i]);
                }

                output.AppendFormat("[{0}]({1})", info, url);

                info.Clear();
                url.Clear();
                positionResult = closingInfoTagIndex + 4;
            }

            Console.WriteLine(output);
        }
    }
}