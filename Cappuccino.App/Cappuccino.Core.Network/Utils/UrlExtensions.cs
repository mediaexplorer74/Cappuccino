using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cappuccino.Core.Network.Utils 
{
    internal static class UrlExtensions {
        public static string JoinToUrl(this Dictionary<string, string> dictionary) 
        {
            return String.Join("&", dictionary.Select(pair => $"{pair.Key}={pair.Value}"));
        }

        public static Dictionary<string, string> SplitUrl(this string url) 
        {
            Dictionary<string, string> param = new();
            /*var a = url.IndexOf('#') + 1;
            string[] tokens = url[a];//url[(url.IndexOf('#') + 1)..].Split('&');
            Dictionary<string, string> param = new();

            foreach (string token in tokens) 
            {
                string[] pair = token.Split('=');

                if (pair.Length == 2)
                    param.Add(pair[0], pair[1]);
            }
            return param;
            */
            Match match = Regex.Match(url, @"\:|\.(.{2,3}(?=/))"); // Regex Pattern
            if (match.Success)  // check if it has a valid match
            {
                string split = match.Groups[0].Value; // get the matched text
                int index = url.IndexOf(split);

                string[] pair = new string[]
                {
                url.Substring(0, index + split.Length),
                url.Substring(index + (split.Length), url.Length - (index + split.Length))
                };

                if (pair.Length == 2)
                    param.Add(pair[0], pair[1]);
            }
            return param;
        }
        
    }
}

