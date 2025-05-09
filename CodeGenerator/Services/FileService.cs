﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class FileService
    {
        public static void SaveFile(string content, string fileName, string path)
        {
            string folder = Directory.GetCurrentDirectory();
            string outDir = $"{ folder }\\{ path}";
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }
            string fullPath = outDir + "\\"+ fileName;


            content = content.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");

            File.WriteAllText(fullPath, content, Encoding.UTF8);
        }

        public static T ReadFile<T>(string fileName)
        {
            string folder = Directory.GetCurrentDirectory();
            string fullPath = folder + "\\" + fileName;
            T res = JsonSerializer.Deserialize<T>( File.ReadAllText(fullPath, Encoding.UTF8));

            return res;
        }

    }
}
