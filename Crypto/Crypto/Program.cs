using System;
using System.Text;
using System.Linq;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            bool complete = false;
            while (!complete)
            {
                var proccessType = ProccessType.Encrypt;
                var sourceType = SourceType.Alphabeth;

                Console.Write("Crypto Type (encrypt/decrypt) : "); var cryptoType = Console.ReadLine();

                if (cryptoType.ToUpper() == "DECRYPT")
                    proccessType = ProccessType.Decript;
                else
                    cryptoType = "ENCRYPT";


                Console.Clear();
                Console.WriteLine("Crypto Type : "+ cryptoType);
                Console.Write("Input Your Text : "); var text = Console.ReadLine();
                Console.WriteLine();
               
                if (!text.All(s=>char.IsLetter(s)))
                    sourceType = SourceType.ASCII;

                Console.WriteLine("Result");
                Console.WriteLine("Source Type : " + sourceType.ToString().ToUpper());
             
                try
                {
                    switch (proccessType)
                    {
                        case ProccessType.Encrypt:
                            var encryptResult = Proccess(text, 1000, sourceType, proccessType);
                            Console.WriteLine("Encrypt Result: " + encryptResult);
                            break;

                        case ProccessType.Decript:
                            var decriptResult = Proccess(text, 1000, sourceType, ProccessType.Decript);
                            Console.WriteLine("Decrypt Result: " + decriptResult);
                            break;
                    }
                    Console.Write("Keluar ? (Y/N) : ");
                    var isOut = Console.ReadLine();
                    if (isOut.ToUpper()=="Y")
                    {
                        complete = true;
                    }
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string Proccess(string text, int key, SourceType type, ProccessType proccessType)
        {
            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case SourceType.Alphabeth:
                    var plainText = text.ToUpper();
                    var source = GetAlphabet().ToUpper();
                    foreach (var item in plainText)
                    {
                        int resultIncex = GetIndex(source.IndexOf(item), key, source.Length, proccessType);
                        sb.Append(source[resultIncex]);
                    }
                    break;

                case SourceType.ASCII:
                    byte[] values = Encoding.ASCII.GetBytes(text);
                    foreach (var item in values)
                    {
                        int resultIncex = GetIndex(item, key, 256, proccessType);
                        sb.Append((char)resultIncex).ToString();
                    }
                    break;
            }

            return sb.ToString();

        }

        private static string GetAlphabet()
        {
            return "abcdefghijklmnopqrstuvwxyz";
        }

        private static int GetIndex(int index, int key, int length, ProccessType proccessType)
        {
            if (proccessType == ProccessType.Encrypt)
                return Program.mod((index + key), length);
            else
                return Program.mod((index - key), length);
        }


        public static int mod(int n, int m)
        {
            return ((n % m) + m) % m;
        }
    }




    enum SourceType
    {
        Alphabeth, ASCII
    }

    enum ProccessType
    {
        Encrypt, Decript
    }




}
