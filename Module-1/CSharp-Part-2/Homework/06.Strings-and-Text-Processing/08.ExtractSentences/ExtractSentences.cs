#region 10/100
//namespace ExtractSentences
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    class ExtractSentences
//    {
//        static void Main()
//        {
//            string word = Console.ReadLine();
//            word = " " + word + " ";
//            string text = Console.ReadLine();
//            text = ". " + text + " ";

//            List<int> wordIndex = FindOccurrences(text, word);

//            StringBuilder sb = new StringBuilder();

//            for (int i = 0; i < wordIndex.Count; i++)
//            {
//                var indexOfDigit = wordIndex[i] + 1;
//                var indexOfStart = 0;
//                var indexOfEnd = 0;


//                while (true)
//                {
//                    //Console.WriteLine(text[indexOfDigit]);
//                    if (text[indexOfDigit - 2] == '.')
//                    {
//                        indexOfStart = indexOfDigit;
//                        break;
//                    }
//                    //else if (char.IsUpper(text[indexOfDigit]) && !char.IsLetter(text[indexOfDigit - 1]))
//                    //{
//                    //    indexOfStart = indexOfDigit;
//                    //    break;
//                    //}

//                    indexOfDigit--;
//                }

//                indexOfDigit = wordIndex[i] + 1;

//                while (true)
//                {
//                    //Console.WriteLine(text[indexOfDigit]);
//                    if (text[indexOfDigit] == '.')
//                    {
//                        indexOfEnd = indexOfDigit;
//                        break;
//                    }

//                    indexOfDigit++;
//                }

//                var result = text.Substring(indexOfStart, indexOfEnd - indexOfStart + 1).TrimStart(' ');
//                Console.Write(result + " ");
//            }
//            Console.WriteLine();
//        }

//        static List<int> FindOccurrences(string text, string word)
//        {
//            var wordIndex = new List<int>();

//            int indexOfWord = text.IndexOf(word);

//            while (indexOfWord != -1)
//            {
//                wordIndex.Add(indexOfWord);
//                indexOfWord = text.IndexOf(word, indexOfWord + 1);
//            }

//            return wordIndex;
//        }
//    }
//}
#endregion

#region partial
//namespace ExctractSentence
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    class ExctractSentence
//    {
//        static void Main(string[] args)
//        {
//            var word = Console.ReadLine();
//            var text = Console.ReadLine();

//            List<string> answers = new List<string>();

//            string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

//            List<char> newarr = new List<char>();

//            for (int j = 0; j < sentences.Length; j++)
//            {
//                char[] arr = sentences[j].Where(c => (char.IsLetter(c) ||
//                             char.IsWhiteSpace(c))).ToArray();


//                foreach (char symbol in sentences[j])
//                {
//                    if (symbol == '.' || symbol == ' ' || char.IsLetter(symbol))
//                    {
//                        newarr.Add(symbol);
//                    }
//                    else
//                    {
//                        newarr.Add(' ');
//                    }
//                }


//                string words = new string(newarr.ToArray());

//                //string[] words = sentences[j].Split(' ');

//                //for (int i = 0; i < words.Length; i++)
//                //{
//                //    if (string.Compare(words[i], word, true) == 0)
//                //    {
//                //        answers.Add(sentences[j].Trim() + ".");
//                //        break;
//                //    }
//                //}
//            }
//            Console.WriteLine(string.Join(" ", answers));
//        }
//    }
//}
#endregion

#region TimeLimit
//namespace ExctractSentence
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    class ExctractSentence
//    {
//        static void Main(string[] args)
//        {
//            var word = Console.ReadLine();
//            var text = Console.ReadLine();

//            List<string> answers = new List<string>();

//            string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

//            List<char> newarr = new List<char>();

//            for (int j = 0; j < sentences.Length; j++)
//            {
//                char[] arr = sentences[j].Where(c => (char.IsLetter(c) ||
//                             char.IsWhiteSpace(c))).ToArray();


//                foreach (char symbol in sentences[j])
//                {
//                    if (symbol == '.' || symbol == ' ' || char.IsLetter(symbol))
//                    {
//                        newarr.Add(symbol);
//                    }
//                    else
//                    {
//                        newarr.Add(' ');
//                    }
//                }


//                string words = new string(newarr.ToArray());

//                //string[] words = sentences[j].Split(' ');

//                //for (int i = 0; i < words.Length; i++)
//                //{
//                //    if (string.Compare(words[i], word, true) == 0)
//                //    {
//                //        answers.Add(sentences[j].Trim() + ".");
//                //        break;
//                //    }
//                //}
//            }
//            Console.WriteLine(string.Join(" ", answers));
//        }
//    }
//}
#endregion

namespace ExtractSentences
{
    using System;
    using System.Linq;

    class ExtractSentences
    {
        static void Main()
        {
            var wordToFind = Console.ReadLine();
            var input = Console.ReadLine();

            var sentences = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var separators = input.Where(x => !char.IsLetter(x)).Distinct().ToArray();

            //var wordCapitalized = wordToFind.Replace(wordToFind[0], char.ToUpper(wordToFind[0]));
            //var wordNormalized = wordToFind.Replace(wordToFind[0], char.ToLower(wordToFind[0]));

            foreach (var sentence in sentences)
            {
                var words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Trim() == wordToFind)
                    {
                        Console.Write(sentence.Trim() + ". ");
                        break;
                    }
                }
            }

        }
    }
}