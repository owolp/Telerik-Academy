namespace ParseURL
{
    using System;

    class ParseURL
    {
        static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine("[protocol] = {0}", ExtractProtocol(input));
            Console.WriteLine("[server] = {0}", ExtractServer(input));
            Console.WriteLine("[resource] = {0}", ExtractResource(input));
        }

        static string ExtractProtocol(string url)
        {
            string protocol = string.Empty;

            int twoDotsIndex = url.IndexOf(':');

            if (twoDotsIndex != -1)
            {
                protocol = url.Substring(0, twoDotsIndex);
            }

            return protocol;
        }

        static string ExtractServer(string url)
        {
            string server = string.Empty;

            int doubleDotIndex = url.IndexOf(':');
            int dirSlashIndex = url.IndexOf('/', doubleDotIndex + 3);

            if (dirSlashIndex != -1)
            {
                server = url.Substring(doubleDotIndex + 3, dirSlashIndex - doubleDotIndex - 3);
            }

            return server;
        }

        static string ExtractResource(string url)
        {
            string resource = string.Empty;

            int dotIndex = url.IndexOf('.');
            int dirSlashÍndex = url.IndexOf('/', dotIndex);

            if (dirSlashÍndex != -1)
            {
                resource = url.Substring(dirSlashÍndex, url.Length - dirSlashÍndex);
            }

            return resource;
        }
    }
}