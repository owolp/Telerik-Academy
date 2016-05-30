namespace DownloadFile
{
    using System;
    using System.Net;

    class DownloadFile
    {
        static void Main()
        {
            var input = Console.ReadLine();//"https://telerikacademy.com/Content/Images/news-img01.png";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(input, "../../files/ninja.png");
                    Console.WriteLine("The file has been downloaded successfully!");
                }
            }
            catch (ArgumentException ex)
            {
                PrintException(ex);
            }
            catch (NotSupportedException ex)
            {
                PrintException(ex);
            }
            catch (WebException ex)
            {
                PrintException(ex);
            }
 
        }

        static void PrintException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}