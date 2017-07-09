using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AutoSendMessageOnWeb.Lib.Security
{
    //https://stackoverflow.com/questions/17128038/c-sharp-rsa-encryption-decryption-with-transmission
    public class Crypto
    {
        static string _filePrivateKey = "Data\\private key.xml";
        static string _filePublicKey = "Data\\public key.xml";

        public static void CreateKey(int keysize)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keysize);

            var privateKey = rsa.ExportParameters(true);
            var publicKey = rsa.ExportParameters(false);

            File.WriteAllText(_filePrivateKey, ConvertKeyToString(privateKey));
            File.WriteAllText(_filePublicKey, ConvertKeyToString(publicKey));
        }

        public static string Encrypt(string s)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(ConvertStringToKey(File.ReadAllText(_filePublicKey)));

            byte[] dataToEnCrypt = Encoding.ASCII.GetBytes(s);
            byte[] dataCypher = rsa.Encrypt(dataToEnCrypt, false);

            return Convert.ToBase64String(dataCypher);
        }

        public static string Decrypt(string s)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(ConvertStringToKey(File.ReadAllText(_filePrivateKey)));

            byte[] dataCypher = Convert.FromBase64String(s);
            byte[] bytePlain = rsa.Decrypt(dataCypher, false);

            return Encoding.ASCII.GetString(bytePlain);
        }

        private static string ConvertKeyToString(RSAParameters key)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, key);
            //get the string from the stream
            return sw.ToString();
        }

        private static RSAParameters ConvertStringToKey(string data)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(data);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }

        public static string SignatureOfString(string s_tosign)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(ConvertStringToKey(File.ReadAllText(_filePrivateKey)));

            byte[] dataToSign = Encoding.ASCII.GetBytes(s_tosign);

            byte[] signature = rsa.SignData(dataToSign, new SHA1Managed());

            return Convert.ToBase64String(signature);
        }

        public static DateTime? VerifySignature(string plaintext, string s_signature)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(ConvertStringToKey(File.ReadAllText(_filePublicKey)));

                byte[] dataToVerify = Encoding.ASCII.GetBytes(plaintext);
                byte[] signature = Convert.FromBase64String(s_signature);
                if( rsa.VerifyData(dataToVerify, new SHA1Managed(), signature))
                {
                    string plainData = Crypto.Decrypt(plaintext, "thuVIENwiForm!@#!");
                    string[] dataOfKey = plainData.Split('[', ']');
                    string hashMAC = dataOfKey[1];

                    if (Crypto.HashString(DataUseForSecurity.GetFirstMAC()) == hashMAC)
                    {
                        DateTime? dateFrom = DataTypeEx.ddMMyyyy(dataOfKey[3]);
                        if (dateFrom != null && dateFrom.Value <= DataUseForSecurity.GetReadDate())
                        {
                            DateTime? dateTo = DataTypeEx.ddMMyyyy(dataOfKey[5]);
                            return dateTo;
                        }
                    }

                    return null;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string HashString(string s)
        {
            string kq = "";
            SHA1Managed heMatMa = new SHA1Managed();
            foreach (byte b in heMatMa.ComputeHash(Encoding.Unicode.GetBytes(s)))
                kq += String.Format("{0:x2}", b);
            return kq;
        }

        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
