using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using CodeGenerator.Enum;

namespace CodeGenerator
{
    public class SharpCodeAnalizator
    {
        public CodeLanguageEnum CodeLanguage { get; set; }
        public string CodeText { get; set; }
        public static string UsingText(string codeText)
        {
            return codeText.Substring(0, codeText.IndexOf("namespace"));
        }

        public List<SharpClass> Classes { get; set; } = new List<SharpClass>();
        public SharpCodeAnalizator(string codeText, CodeLanguageEnum codeLanguage)
        {
            CodeText = codeText;
            CodeLanguage = codeLanguage;

            Classes = GetClasses(codeText);
        }

        public string CodeWithoutClass(string className)
        {
            string res = CodeText;

            SharpClass sharpClass = Classes.FirstOrDefault(c => c.Name == className);
            if(sharpClass != null)
            {

                int start = res.IndexOf(sharpClass.Code.Substring(0, 100));
                res = res.Substring(0, start) + res.Substring(start + sharpClass.Code.Length - 1);
            }

            return res;
        }
        public string CodeWithoutClasses()
        {
            string res = CodeText;

            foreach (SharpClass c in Classes)
            {
                res = CodeWithoutClass(c.Name);
            }

            return res;
        }

        private List<SharpClass> GetClasses(string codeText)
        {
            List<SharpClass> res = new List<SharpClass>();
            string tempCode = codeText;
            while (tempCode.IndexOf("class ") > 0)
            {
                int classNameStartWith = tempCode.IndexOf("class ");

                string className = FindFirstClassName(tempCode, classNameStartWith);
                if (!string.IsNullOrEmpty(className))
                {
                    string classText = ClassText(tempCode, className);

                    if (!string.IsNullOrEmpty(classText))
                    {
                        res.Add(new SharpClass(className, classText));

                        int charCountForSearch = Math.Min(classText.Length, 100);

                        int start = tempCode.IndexOf(classText.Substring(0, charCountForSearch));

                        tempCode = tempCode.Substring(0, start) + tempCode.Substring(start + classText.Length - 1);
                    }
                }

            }

            return res;
        }

        private static string FindFirstClassName(string tempCode, int classNameStartWith)
        {
            string classCode = tempCode.Substring(classNameStartWith + 6);
            int classNameEndWith = Math.Min(classCode.IndexOf(" "), classCode.IndexOf(Environment.NewLine));
            string className = classCode.Substring(0, classNameEndWith).Trim();
            return className;
        }

        public static string ClassText(string code, string className)
        {
            var lines = code.Split(Environment.NewLine);
            int classStartLine = -1;
            int braceCount = 0;
            bool classFound = false;
            List<string> resLines = new List<string>();

            bool started = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Ищем начало класса
                if (!classFound && Regex.IsMatch(line, $@"\bclass\s+{className}\b"))
                {
                    resLines.Add(line);
                    classStartLine = i;
                    classFound = true;

                    // Проверяем, есть ли открывающая скобка в этой же строке
                    if (line.Contains("{"))
                    {
                        braceCount++;
                    }
                    continue;
                }

                // Если класс найден, считаем скобки
                if (classFound)
                {

                    resLines.Add(line);
                    foreach (char c in line)
                    {
                        if (c == '{')
                        {
                            braceCount++;
                            started = true;
                        }

                        if (c == '}') braceCount--;

                        // Когда все скобки закрыты, возвращаем диапазон
                        if (started && braceCount == 0 && classStartLine != -1)
                        {
                            return string.Join(Environment.NewLine, resLines);
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, resLines);
        }

    }

    public class SharpClass
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<SharpClassMethods> Methods { get; set; } = new List<SharpClassMethods>();
        public SharpClass(string name, string code)
        {
            Name = name;
            Code = code;

            //init methods
            InitMethods();
        }

        private void InitMethods()
        {
            string tempCode = Code;
            string methodName = "Run";
            if (!string.IsNullOrEmpty(methodName))
            {
                string methodText = MethodText(tempCode, methodName);
                if (!string.IsNullOrEmpty(methodText))
                {
                    Methods.Add(new SharpClassMethods(methodName, methodText));

                    int start = tempCode.IndexOf(methodText.Substring(0, 100));

                    tempCode = tempCode.Substring(0, start) + tempCode.Substring(start + methodText.Length - 1);
                }
            }
        }

        public static string MethodText(string code, string methodName)
        {
            List<string> resLines = new List<string>();

            var lines = code.Split(Environment.NewLine);
            int classStartLine = -1;
            int braceCount = 0;
            bool classFound = false;

            bool started = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Ищем начало класса
                if (!classFound && Regex.IsMatch(line, $@"\b {methodName}\b"))
                {
                    resLines.Add(line);
                    classStartLine = i;
                    classFound = true;

                    // Проверяем, есть ли открывающая скобка в этой же строке
                    if (line.Contains("{"))
                    {
                        braceCount++;
                    }
                    continue;
                }

                // Если класс найден, считаем скобки
                if (classFound)
                {

                    resLines.Add(line);
                    foreach (char c in line)
                    {
                        if (c == '{')
                        {
                            braceCount++;
                            started = true;
                        }

                        if (c == '}') braceCount--;

                        // Когда все скобки закрыты, возвращаем диапазон
                        if (started && braceCount == 0 && classStartLine != -1)
                        {
                            return string.Join(Environment.NewLine, resLines);
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, resLines);
        }

    }

    public class SharpClassMethods
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public SharpClassMethods(string name, string code)
        {
            Name = name;
            Code = code;
        }

    }
}
