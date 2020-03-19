using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GuestsBook.encription
{
    public static class EncryptionUtility
    {
        public static string AlgorithmName { get; set; }
        public static string KeyFile { get; set; }
        public static void GenerateKey()
        {
            // Create algorithm
            SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            // Generate algorithm's key
            algorithm.GenerateKey();
            byte[] Key = algorithm.Key;
            // Seve key to file
            using (FileStream fs = new FileStream(KeyFile, FileMode.Create))
            {
                fs.Write(Key, 0, Key.Length);
            }
        }

        public static void ReadKey(SymmetricAlgorithm algorithm)
        {
            byte[] Key;
            using (FileStream fs = new FileStream(KeyFile, FileMode.Open))
            {
                Key = new byte[fs.Length];
                fs.Read(Key, 0, (int)fs.Length);
            }
            algorithm.Key = Key;
        }

        public static byte[] EncryptData(string data)
        {
            byte[] ClearData = Encoding.UTF8.GetBytes(data);

            using (SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName))
            {
                ReadKey(Algorithm);

                using (MemoryStream Target = new MemoryStream())
                {
                    Algorithm.GenerateIV();
                    Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);
                    using (CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(ClearData, 0, ClearData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Target.ToArray();
                }
            }
        }

        public static string DecryptDate(byte[] data)
        {
            using (SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName))
            {
                ReadKey(Algorithm);

                using (MemoryStream Target = new MemoryStream())
                {
                    int ReadPos = 0;
                    byte[] IV = new byte[Algorithm.IV.Length];
                    Array.Copy(data, IV, IV.Length);
                    Algorithm.IV = IV;
                    ReadPos += Algorithm.IV.Length;

                    CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(data, ReadPos, data.Length - ReadPos);
                    cs.FlushFinalBlock();

                    return Encoding.UTF8.GetString(Target.ToArray());
                }
            }
        }
    }
}