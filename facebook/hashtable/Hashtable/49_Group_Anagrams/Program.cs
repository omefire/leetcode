using System;

namespace _49_Group_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var r in GroupAnagrams1.Group(new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" })){
                foreach(var rr in r) {
                    Console.Write(rr);
                    Console.Write(",");
                }
                Console.WriteLine();
            }
        }
    }
}
