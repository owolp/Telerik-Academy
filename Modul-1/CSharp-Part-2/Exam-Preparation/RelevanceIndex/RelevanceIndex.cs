namespace RelevanceIndex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RelevanceIndex
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            int l = int.Parse(Console.ReadLine());

            List<string> text = new List<string>();
            List<int> textFreq = new List<int>();
            List<char> separators = new List<char>
            {
                ' ', ',', '.', '(', ')', ';', '-', '!', '?',
            };

            for (int i = 0; i < l; i++)
            {
                List<char> tempArr = new List<char>();
                int index = 1;
                var input = Console.ReadLine();

                foreach (char digit in input)
                {
                    if ((separators.Contains(digit)) && index == 1)
                    {
                        tempArr.Add(' ');
                        index = 0;
                    }
                    else if (!(separators.Contains(digit)))
                    {
                        tempArr.Add(digit);
                        index = 1;
                    }
                }

                string s = new string(tempArr.ToArray());

                string[] source = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < source.Length; j++)
                {
                    if (source[j].ToLower() == pattern.ToLower())
                    {
                        source[j] = source[j].ToUpper();
                    }
                }

                string newString = string.Join(" ", source);
                text.Add(newString);

                //https://msdn.microsoft.com/en-us/library/mt693032.aspx

                // Create the query.  Use ToLowerInvariant to match "data" and "Data" 
                var matchQuery = from word in source
                                 where word.ToLowerInvariant() == pattern.ToLowerInvariant()
                                 select word;

                // Count the matches, which executes the query.
                int wordCount = matchQuery.Count();
                //Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, pattern);

                textFreq.Add(wordCount);
            }

            for (int i = 0; i < text.Count; i++)
            {
                int maxValue = textFreq.Max();
                int maxIndex = textFreq.IndexOf(maxValue);
                textFreq[maxIndex] = 0;

                Console.WriteLine(text[maxIndex]);
            }
        }
    }
}