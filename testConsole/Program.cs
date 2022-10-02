using simpleTextEncoders;
using System;
using System.Threading.Tasks;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstration console app.");
            Console.WriteLine("LIB: simpleTextEncoder.");
            Console.WriteLine("Author: Marcin Kaminski (marcin.kaminski.gd (at) gmail.com).");

            string s1 = "THisIsJustASampleTestMessage Special Chars:(123 * 098 >> && ## @@){}. Message is for demonstration only.";
            string s2 = simpleTextEncoder.cipher(s1);
            string s3 = simpleTextEncoder.decipher(s2);
            Console.WriteLine("String to encrypt:");
            Console.WriteLine(s1);
            Console.WriteLine("String after encryption:");
            Console.WriteLine(s2);
            Console.WriteLine("String after decryption:");
            Console.WriteLine(s1);

            Task.Delay(5000).Wait();

        }
    }
}
