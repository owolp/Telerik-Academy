#region 25/100
//namespace ParseTags
//{
//    using System;

//    class ParseTags
//    {
//        static void Main()
//        {
//            PrintArray(TagsParser(Console.ReadLine()));
//        }

//        static string[] TagsParser(string text)
//        {
//            string[] splitByUpcase = text.Split(new[] { "<upcase>", "</upcase>" }, StringSplitOptions.RemoveEmptyEntries);

//            for (int i = 1; i < splitByUpcase.Length; i += 2)
//            {
//                splitByUpcase[i] = splitByUpcase[i].ToUpper();
//            }

//            return splitByUpcase;
//        }

//        static void PrintArray(string[] array)
//        {
//            Console.WriteLine(string.Join("", array));
//        }
//    }
//}
#endregion

#region 30/100
//using System;
//using System.Text.RegularExpressions;

//class SubStringInText
//{
//    static void Main(string[] args)
//    {
//        string content = Console.ReadLine();
//        string pattern = @"(?<=^|<upcase>)[^><]+?(?=</upcase>|$)";
//        MatchCollection matches = Regex.Matches(content, pattern);
//        foreach (var match in matches)
//        {
//            string expression = match.ToString();
//            content = content.Replace(expression, expression.ToUpper());
//        }
//        content = Regex.Replace(content, @"<.+?>", "");
//        Console.WriteLine(content);
//    }
//}
#endregion

#region RegEx 100/100
//using System;
//using System.Text.RegularExpressions;

//class SubStringInText
//{
//    static void Main(string[] args)
//    {
//        string content = Console.ReadLine();

//        Console.WriteLine(Regex.Replace(content, "<upcase>(.*?)</upcase>", word => word.Groups[1].Value.ToUpper()));
//    }
//}
#endregion

namespace ParseTags
{
    using System;
    using System.Linq;
    using System.Text;

    class ParseTags
    {
        static void Main()
        {
            Console.WriteLine(FindOccurences(Console.ReadLine()));
        }

        static string FindOccurences(string text)
        {
            var result = new StringBuilder();

            var openTag = "upcase";
            var closeTag = "/upcase";

            var textAsArray = text.Split(new char[] { '<', '>' }).ToArray();

            var toUpper = false;

            foreach (var word in textAsArray)
            {
                if (word == openTag)
                {
                    toUpper = true;
                    continue;
                }

                if (word == closeTag)
                {
                    toUpper = false;
                    continue;
                }

                if (toUpper)
                {
                    result.Append(word.ToUpper());
                }
                else
                {
                    result.Append(word);
                }
            }

            return result.ToString();
        }
    }
}