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
        public SharpCodeAnalizator(string codeText, CodeLanguageEnum codeLanguage, bool useClassProps = false)
        {
            CodeText = codeText;
            CodeLanguage = codeLanguage;

            Classes = GetClasses(codeText, useClassProps);
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

        private List<SharpClass> GetClasses(string codeText, bool useClassProps = false)
        {
            List<SharpClass> res = new List<SharpClass>();
            string tempCode = codeText;

            var lines = tempCode.Split(Environment.NewLine);

            //пока есть классы - ищем
            while (lines.Any(l => StringHelper.TrimComment(l).IndexOf("class ") > 0) )
            {
                lines = tempCode.Split(Environment.NewLine);
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = StringHelper.TrimComment(lines[i]);
                    int classNameStartWith = line.IndexOf("class ");
                    if (classNameStartWith >= 0)
                    {
                        string className = FindFirstClassName(line, classNameStartWith);

                        if (!string.IsNullOrEmpty(className))
                        {
                            string classText = ClassText(tempCode, className);

                            if (!string.IsNullOrEmpty(classText))
                            {
                                if (res.Any(s => s.Name == className))
                                {
                                    res.Add(new SharpClass(className + "_dublicate", classText, useClassProps));
                                }
                                else
                                {
                                    res.Add(new SharpClass(className, classText, useClassProps));
                                }

                                //удаляем обработанный код
                                int charCountForSearch = Math.Min(classText.Length, 100);
                                int start = tempCode.IndexOf(classText.Substring(0, charCountForSearch));
                                tempCode = tempCode.Substring(0, start) + tempCode.Substring(start + classText.Length - 1);
                            }

                            //Прерывам цикл по 
                            break;
                        }
                    }
                    
                }

            }

            return res;
        }

        private static string FindFirstClassName(string tempCode, int classNameStartWith)
        {
            string classCode = tempCode.Substring(classNameStartWith + 6);
            int classNameEndWith = Math.Min(classCode.IndexOf(" "),  classCode.IndexOf(":"));
            string className = (classNameEndWith >= 0) 
                ? classCode.Substring(0, classNameEndWith).Trim()
                : classCode;

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
                string lineForSearch = StringHelper.TrimComment(line);

                // Ищем начало класса
                if (!classFound && Regex.IsMatch(lineForSearch, $@"\bclass\s+{className}\b"))
                {
                    resLines.Add(line);
                    classStartLine = i;
                    classFound = true;

                    // Проверяем, есть ли открывающая скобка в этой же строке
                    if (lineForSearch.Contains("{"))
                    {
                        braceCount++;
                    }
                    continue;
                }

                // Если класс найден, считаем скобки
                if (classFound)
                {

                    resLines.Add(line);
                    foreach (char c in lineForSearch)
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
        public List<SharpClassProperty> Props { get; set; }
        public SharpClass(string name, string code, bool useClassProps = false)
        {
            Name = name;
            Code = code;

            //init methods
            InitMethods();

            string innerClassText = GetInnerText(code);

            if (useClassProps)
            {
                Props = GetProps(innerClassText);
            }
        }

        private string GetInnerText(string code)
        {
            int startIndex = code.IndexOf('{') + 1;
            int endIndex = code.LastIndexOf('}');
            string innerText = code.Substring(startIndex, endIndex - startIndex);

            return innerText;
        }

        private List<SharpClassProperty> GetProps(string code)
        {
            List<SharpClassProperty> res = new List<SharpClassProperty>();
            string tempCode = code;
            while (tempCode.IndexOf("public ") > 0)
            {
                int classNameStartWith = tempCode.IndexOf("public ");

                string propName = FindFirstPropName(tempCode, classNameStartWith);
                if (!string.IsNullOrEmpty(propName) && !propName.Contains('('))
                {
                    string propText = PropText(tempCode, propName);

                    if (!string.IsNullOrEmpty(propText))
                    {
                        if (res.Any(s => s.Name == propName))
                        {
                            res.Add(new SharpClassProperty( propName + "_dublicate", propText));
                        }
                        else
                        {
                            res.Add(new SharpClassProperty( propName, propText));
                        }

                        int charCountForSearch = Math.Min(propText.Length, 100);

                        int start = tempCode.IndexOf(propText.Substring(0, charCountForSearch));

                        tempCode = tempCode.Substring(0, start) + tempCode.Substring(start + propText.Length - 1);
                    }
                }

            }

            return res;
        }

        public static string PropText(string code, string className)
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
                string lineForSearch = line;
                //убираем то что после комментария
                int startOfComment = line.IndexOf("//");
                if (startOfComment >= 0)
                {
                    lineForSearch = line.Substring(0, startOfComment);
                }

                // Ищем начало класса
                if (!classFound && !string.IsNullOrEmpty(lineForSearch) && Regex.IsMatch(lineForSearch, $@"\b{className}\b"))
                {
                    resLines.Add(line);
                    classStartLine = i;
                    classFound = true;

                    // Проверяем, есть ли открывающая скобка в этой же строке
                    if (lineForSearch.Contains("{"))
                    {
                        braceCount++;
                    }
                    if (lineForSearch.Contains("{"))
                    {
                        braceCount--;
                    }
                    if(braceCount == 0)
                    {
                        return string.Join(Environment.NewLine, resLines);
                    }
                }

                // Если класс найден, считаем скобки
                if (classFound)
                {

                    resLines.Add(line);
                    foreach (char c in lineForSearch)
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
        private string FindFirstPropName(string tempCode, int classNameStartWith)
        {
            string classCode = tempCode.Substring(classNameStartWith);
            int classNameEndWith = classCode.IndexOf(Environment.NewLine);
            string propName = classCode.Substring(0, classNameEndWith).Trim().Split(' ')[2];

            return propName;
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

            methodName = "RunService";
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
