using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crypto
{
    public class Program
    {
        private static string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string keys = abc.ToLower();
        private static string key = "abz";

        public static void Main(string[] args)
        {

            var enc = ENCRYPT("SAYAPERGIKEPASAR", key);


            Console.WriteLine(enc);

            var decr = DECRYPT(enc, key);


            Console.WriteLine(decr);


            var ct = "TGCSZ GEUAA EFWGQ AHQMC".Split(" ");
            //  Console.WriteLine(DECRYPT(ct,"muk"));
            //
            string[] digits = abc.Select(o => o.ToString()).ToArray();



            int N = 3;
            int D = abc.Length;
            int[] digit = new int[N];
            var q = new List<string>();
        again:
            var aaa = string.Join("", digit.Reverse().Select(x => char.ConvertFromUtf32(65 + x)).ToArray());
            Console.Write("{0} ", aaa); // 65 is 'A'
            for (int i = 0; i < N; ++i)
            {
                if (++digit[i] < D)
                    goto again;
                digit[i] = 0;
                q.Add(aaa);
            }

            Console.WriteLine();


            Console.WriteLine(Math.Pow(27, N) + " - " + q.Count());
            var r = 0;
            foreach (var item in q)
            {
                Console.WriteLine(DECRYPT(ct[0], item.ToLower()) + " " + DECRYPT(ct[1], item.ToLower()) + " " + DECRYPT(ct[2], item.ToLower()) + "  " + item);
            }
            return;
        }

        private static string ENCRYPT(string pt, string key)
        {
            StringBuilder sb = new StringBuilder();
            var keyIndex = 0;
            foreach (var item in pt)
            {
                if (keyIndex >= key.Length)
                    keyIndex = 0;

                var result = mod((Index(item) + IndexKey(key[keyIndex])), 26);
                sb.Append(abc[result]);

                keyIndex++;
            }

            return sb.ToString();
        }

        private static string DECRYPT(string pt, string key)
        {
            StringBuilder sb = new StringBuilder();
            var keyIndex = 0;
            foreach (var item in pt)
            {
                if (keyIndex >= key.Length)
                    keyIndex = 0;

                var result = mod((Index(item) - IndexKey(key[keyIndex])), 26);
                sb.Append(abc[result]);

                keyIndex++;
            }

            return sb.ToString();
        }

        public static int mod(int n, int m)
        {
            return ((n % m) + m) % m;
        }


        public static int Index(char huruf)
        {
            return abc.IndexOf(huruf);
        }


        public static int IndexKey(char huruf)
        {
            return keys.IndexOf(huruf);
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
