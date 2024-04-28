// See https://aka.ms/new-console-template for more information
using CodeGenerator;
string project = Environment.GetCommandLineArgs().Count() > 1 
    ? Environment.GetCommandLineArgs()[1]
    : "DefaultProject";

string fileType = Environment.GetCommandLineArgs().Count() > 2
    ? Environment.GetCommandLineArgs()[2]
    : "";

Generator.GenCode(project, fileType);