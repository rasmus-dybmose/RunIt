using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for kryptering
/// </summary>
public class kryptering
{
    public string HashPassword(String password, String salt)
    {
        var combinedPassword = String.Concat(password, salt);
        var sha256 = new SHA256Managed();
        var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);

    }

    public String GetRandomSalt (Int32 size = 12)
    {
        var random = new RNGCryptoServiceProvider();
        var salt = new Byte[size];
        random.GetBytes(salt);
        return Convert.ToBase64String(salt);
    }
}