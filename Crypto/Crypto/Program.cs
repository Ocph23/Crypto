using System;
using System.Text;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder textBuilder = new StringBuilder();
                foreach (var item in args)
                {
                    textBuilder.Append(item);
                    textBuilder.Append(" ");
                }

                var encryptResult = Proccess(textBuilder.ToString(), 3, SourceType.ASCII, ProccessType.Encrypt);
                Console.WriteLine("Encrypt Result: " + encryptResult);

                var decriptResult = Proccess(encryptResult, 3, SourceType.ASCII, ProccessType.Decript);
                Console.WriteLine("Decrypt Result: " + decriptResult);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }

        private static string Proccess(string text, int key, SourceType type, ProccessType proccessType)
        {
            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case SourceType.Alphabeth:
                    var plainText = text.ToUpper();
                    var source = "abcdefghijklmnopqrstuvwxyz".ToUpper();
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

        private static int GetIndex(int index, int key, int length, ProccessType proccessType)
        {
            if (proccessType == ProccessType.Encrypt)
                return (index + key) % length;
            else
                return (length + index - key) % length;
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
