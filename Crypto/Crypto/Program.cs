using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Crypto
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string pathInFile = @"X:\Sharp Projects\_Cursovyi\Crypto\Crypto\test.txt";
            byte[] fileData = File.ReadAllBytes(pathInFile);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] signature = rsa.SignData(fileData, new SHA1CryptoServiceProvider());
            File.WriteAllBytes(pathInFile + ".signature", signature);
            

        }
    }
}
