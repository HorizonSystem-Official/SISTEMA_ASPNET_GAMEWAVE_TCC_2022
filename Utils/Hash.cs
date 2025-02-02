﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using BCrypt;
namespace TCC_Sistema_Cliente_Jogos_2022.Utils
{
    //CLASSE UTILIZADA PARA CRIPTOGRAFAR E DESCRIPTOGRAFAR SENHAS
    public class Hash
    {
        //public static string GerarHash(string senha)
        //{
        //    SHA256 sha256 = SHA256.Create();
        //    byte[] bytes = Encoding.UTF8.GetBytes(senha);
        //    byte[] hash = sha256.ComputeHash(bytes);
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 0; i < hash.Length; i++ )
        //    {
        //        result.Append(hash[i].ToString("x"));
        //    }
        //    return result.ToString();
        //}

        public static string GenerateBCrypt(string text)
        {
            // Configurations
            int workfactor = 10; // 2 ^ (10) = 1024 iterations.

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(text, salt);

            return hash;
        }

        public static bool CompareBCrypt(string text, string hash)
        {
            return text == null || hash == null ? false : BCrypt.Net.BCrypt.Verify(text, hash);
        }

        //Formatação criptografada das imagens
        public static string GenerateMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();

            Byte[] originalBytes = encoder.GetBytes(text);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            text = BitConverter.ToString(encodedBytes).Replace("-", "");
            return text.ToLower();
        }

        public static bool CompareMD5(string text, string hash)
        {
            return (GenerateMD5(text) == hash);
        }

    }
}