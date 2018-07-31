using System;
using System.Collections.Generic;
using System.Text;

public class TinyURL1
{
    public static Dictionary<int, string> dict = new Dictionary<int, string>();
    public static int counter = 0;

    // Method1: Use a counter
    // Advantages: simple, inexpensive
    // Disadvantages: the number of urls that can be encoded is limited by the range of int,
    // ... risk of overflow if too many urls encoded, length of encoded url might end up not necessarily shorter,
    // ... pattern of encoding can be guessed, 
    public static string encode(string url)
    {
        if (url == null || string.IsNullOrEmpty(url))
        {
            return null;
        }
        dict.Add(counter, url);
        return "http://tinyurl.com/" + counter++;
    }

    public static string decode(string shortURL)
    {
        var url = dict[int.Parse(shortURL.Replace("http://tinyurl.com/", ""))];
        return url;
    }
}

public class TinyURL2
{
    private static string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // 
    private static Dictionary<string, string> dict = new Dictionary<string, string>();

    public static string GetHash()
    {
        var r = new Random();
        var bld = new StringBuilder();
        for (int i = 0; i < 6; i++)
        {
            bld.Append(alphabet[r.Next(alphabet.Length)]);
        }
        return bld.ToString();
    }

    public static string encode(string longUrl)
    {
        if (longUrl == null || string.IsNullOrEmpty(longUrl))
        {
            return null;
        }

        var hash = GetHash();
        while (dict.ContainsKey(hash))
        {
            hash = GetHash();
        }

        dict.Add(hash, longUrl);
        return "http://tinyurl.com/" + hash;
    }

    public static string decode(string shortUrl)
    {
        if (shortUrl == null || string.IsNullOrEmpty(shortUrl))
        {
            return null;
        }
        var hash = shortUrl.Replace("http://tinyurl.com/", "");
        if (dict.ContainsKey(hash))
        {
            return dict[hash];
        }
        return null;
    }
}

