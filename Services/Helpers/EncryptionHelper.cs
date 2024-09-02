using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class EncryptionHelper : IDisposable
{
    private ECDiffieHellman ecdh;
    private Aes aes;
    private byte[] sharedSecret;

    public EncryptionHelper()
    {
        ecdh = ECDiffieHellman.Create(); // Use the default algorithm which should support P-256
        aes = Aes.Create();
        aes.KeySize = 256;
        aes.Padding = PaddingMode.PKCS7;
    }

    public byte[] GetPublicKey()
    {
        return ecdh.PublicKey.ToByteArray();
    }

    public void SetPartnerPublicKey(byte[] publicKeyBytes)
    {
        if (publicKeyBytes.Length != 64) // 32 bytes X + 32 bytes Y for P-256
        {
            throw new ArgumentException("Invalid public key length.", nameof(publicKeyBytes));
        }

        var partnerParams = new ECParameters
        {
            Q = new ECPoint
            {
                X = publicKeyBytes[0..32],
                Y = publicKeyBytes[32..64]
            },
            Curve = ecdh.ExportParameters(true).Curve // Use the curve from the local ECDiffieHellman instance
        };

        using var partnerEcdh = ECDiffieHellman.Create();
        partnerEcdh.ImportParameters(partnerParams);
        sharedSecret = ecdh.DeriveKeyMaterial(partnerEcdh.PublicKey);

        aes.Key = sharedSecret;
        aes.GenerateIV();
    }

    public byte[] EncryptMessage(string message)
    {
        if (sharedSecret == null) throw new InvalidOperationException("Shared secret not established.");

        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        cs.Write(messageBytes, 0, messageBytes.Length);
        cs.FlushFinalBlock();

        byte[] encrypted = ms.ToArray();
        byte[] result = new byte[aes.IV.Length + encrypted.Length];
        Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
        Buffer.BlockCopy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

        return result;
    }

    public string DecryptMessage(byte[] encryptedMessage)
    {
        if (sharedSecret == null) throw new InvalidOperationException("Shared secret not established.");

        using var ms = new MemoryStream(encryptedMessage);
        byte[] iv = new byte[aes.BlockSize / 8];
        ms.Read(iv, 0, iv.Length);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);

        return sr.ReadToEnd();
    }

    public void Dispose()
    {
        ecdh?.Dispose();
        aes?.Dispose();
    }
}
