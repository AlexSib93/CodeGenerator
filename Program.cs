// See https://aka.ms/new-console-template for more information
using CodeGenerator;
string project = Environment.GetCommandLineArgs()[1];

string fileType = Environment.GetCommandLineArgs()[2];

Generator.GenCode(project, fileType);