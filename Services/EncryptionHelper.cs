using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Sp00ksy
{
    public class EncryptionHelper
    {
        private ECDiffieHellmanCng ecdh;
        private Aes aes;
        private byte[] sharedSecret;

        public EncryptionHelper()
        {
            ecdh = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };
            aes = new AesCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
        }

        public byte[] GetPublicKey()
        {
            return ecdh.PublicKey.ToByteArray();
        }

        public void SetPartnerPublicKey(byte[] publicKey)
        {
            try
            {
                using (var partnerEcdh = new ECDiffieHellmanCng())
                {
                    var partnerParams = new ECParameters
                    {
                        Q = new ECPoint
                        {
                            X = publicKey.Take(32).ToArray(),
                            Y = publicKey.Skip(32).Take(32).ToArray()
                        },
                        Curve = ECCurve.NamedCurves.nistP256
                    };

                    partnerEcdh.ImportParameters(partnerParams);
                    sharedSecret = ecdh.DeriveKeyMaterial(partnerEcdh.PublicKey);

                    aes.Key = sharedSecret;
                    aes.GenerateIV();
                }
            }
            catch (CryptographicException ex)
            {
                throw new InvalidOperationException("Failed to set partner public key.", ex);
            }
        }

        public byte[] EncryptMessage(string message)
        {
            using (var encryptor = aes.CreateEncryptor())
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                cs.Write(messageBytes, 0, messageBytes.Length);
                cs.FlushFinalBlock();

                byte[] encrypted = ms.ToArray();
                byte[] result = new byte[aes.IV.Length + encrypted.Length];
                Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                Buffer.BlockCopy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

                return result;
            }
        }

        public string DecryptMessage(byte[] encryptedMessage)
        {
            using (var ms = new MemoryStream(encryptedMessage))
            {
                byte[] iv = new byte[aes.BlockSize / 8];
                ms.Read(iv, 0, iv.Length);
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
