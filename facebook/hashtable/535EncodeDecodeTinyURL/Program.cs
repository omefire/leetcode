using System;

namespace _535EncodeDecodeTinyURL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TinyURL2.encode("http://google.com"));
            Console.WriteLine("Done");
        }
    }
}
