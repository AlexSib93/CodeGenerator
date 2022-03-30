// See https://aka.ms/new-console-template for more information
using CodeGenerator;
string className = Environment.GetCommandLineArgs()[1];

string fileType = Environment.GetCommandLineArgs()[2];

Generator.GenCode(className, fileType);