namespace ReadFileContents
{
    using System;
    using System.IO;

    class ReadFileContents
    {
        static void Main()
        {
            var filePath = Console.ReadLine();
            try
            {
                using (var file = new StreamReader(filePath))
                {
                    Console.WriteLine(file.ReadToEnd());
                }
            }
            catch (FieldAccessException ex)
            {
                PrintException(ex);
            }
            catch (FileNotFoundException ex)
            {
                PrintException(ex);
            }
            catch (PathTooLongException ex)
            {
                PrintException(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                PrintException(ex);
            }
            catch (ArgumentNullException ex)
            {
                PrintException(ex);
            }
            catch (ArgumentException ex)
            {
                PrintException(ex);
            }
            catch (IOException ex)
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