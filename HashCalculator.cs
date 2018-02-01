using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCalculator
{
    class SimpleCheckSum
    {
        public enum HashType { MD5, SHA1, SHA256, SHA384, SHA512, RIPEMD160 };

        public static HashAlgorithm[] HA = { MD5CryptoServiceProvider.Create(), SHA1Managed.Create(), SHA256Managed.Create(), SHA384Managed.Create(), SHA512Managed.Create(), RIPEMD160Managed.Create() };
        
        public static string BytesToString(byte[] b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.Length; sb.AppendFormat("{0:x2}", b[i++])) { }
            return sb.ToString();
        }

        public static string CalcHashFromText(String txt, HashType type)
        {
            return BytesToString(HA[(int)type].ComputeHash(Encoding.Default.GetBytes(txt)));
        }

        public static string CalcHashFromFile(String filepath, HashType type)
        {
            return BytesToString(HA[(int)type].ComputeHash(File.OpenRead(filepath)));
        }
    }
}
