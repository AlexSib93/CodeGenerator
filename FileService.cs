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
        public static void SaveFile(string content, string fileName)
        {
            string folder = Directory.GetCurrentDirectory();
            string fullPath =  folder  + "\\"+ fileName;
            File.WriteAllText(fullPath, content);
        }

        public static T ReadFile<T>(string fileName)
        {
            string folder = Directory.GetCurrentDirectory();
            string fullPath = folder + "\\" + fileName;
            T res = JsonSerializer.Deserialize<T>( File.ReadAllText(fullPath));

            return res;
        }

    }
}