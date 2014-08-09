using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections;
using System.Web.Security;
using System.Web;
using System.Security;

namespace DAL
{
    
public static class iStrat
    {
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public static String TCase(String strParam)
        {
            String strTitleCase = strParam.Substring(0, 1).ToUpper();
            strParam = strParam.Substring(1).ToLower();
            String strPrev = "";

            for (int iIndex = 0; iIndex < strParam.Length; iIndex++)
            {
                if (iIndex > 1)
                {
                    strPrev = strParam.Substring(iIndex - 1, 1);
                }
                if (strPrev.Equals(" ") ||
                    strPrev.Equals("\t") ||
                    strPrev.Equals("\n") ||
                    strPrev.Equals("."))
                {
                    strTitleCase += strParam.Substring(iIndex, 1).ToUpper();
                }
                else
                {
                    strTitleCase += strParam.Substring(iIndex, 1);
                }
            }
            return strTitleCase;
        }
        public static bool IsValidEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        public static string RNGCharacterMask()
        {
            int maxSize = 7;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;

            a = "1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);

            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
        public static string RandomString(int length)
        {
            Random ran = new Random(DateTime.Now.Second);
            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                int[] n = { ran.Next(48, 57), ran.Next(65, 90), ran.Next(97, 122) };
                //int[] n = {ran.Next(33, 57), ran.Next(65, 90), ran.Next(97, 122)};
                int picker = ran.Next(0, 3);

                if (picker == 3)//if i make the maxvalue 2 it "never" appears... dunno whats going on there
                    picker = 2;
                password[i] = (char)n[picker];
            }
            return new string(password);
        }
        public static string EncodePassword(string pass, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

    }


    //public class EncryptedQueryString : System.Collections.Specialized.StringDictionary
    //{
    //    public EncryptedQueryString()
    //    {
    //        //
    //        // TODO: Add constructor logic here
    //        //
    //    }

    //    public EncryptedQueryString(string encryptedData)
    //    {
    //        byte[] RawData = HexEncoding.GetBytes(encryptedData);
    //        byte[] ClearRawData = ProtectedData.Unprotect(RawData, null, DataProtectionScope.LocalMachine);
    //        string StringData = Encoding.UTF8.GetString(ClearRawData);
    //        int Index;
    //        string[] SplittedData = StringData.Split(new char[] { '&' });
    //        foreach (string SingleData in SplittedData)
    //        {
    //            Index = SingleData.IndexOf('=');
    //            base.Add(
    //                HttpUtility.UrlDecode(SingleData.Substring(0, Index)),
    //                HttpUtility.UrlDecode(SingleData.Substring(Index + 1))
    //                );
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder Content = new StringBuilder();
    //        foreach (string key in base.Keys)
    //        {
    //            Content.Append(HttpUtility.UrlEncode(key));
    //            Content.Append("=");
    //            Content.Append(HttpUtility.UrlEncode(base[key]));
    //            Content.Append("&");
    //        }
    //        Content.Remove(Content.Length - 1, 1);

    //        byte[] EncryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(Content.ToString()), null, DataProtectionScope.LocalMachine);
    //        return HexEncoding.GetString(EncryptedData).ToString();
    //    }

    //}
    public static class HexEncoding
    {
        public static string GetString(byte[] data)
        {
            StringBuilder Results = new StringBuilder();
            foreach (byte b in data)
            {
                Results.Append(b.ToString("X2"));
            }
            return Results.ToString();
        }
        public static byte[] GetBytes(string data)
        {
            byte[] Results = new byte[data.Length / 2];
            for (int i = 0; i < data.Length; i += 2)
            {
                Results[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }
            return Results;
        }
    }
}
