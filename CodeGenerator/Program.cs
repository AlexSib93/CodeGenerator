using CodeGenerator;

string project = Environment.GetCommandLineArgs().Count() > 1 
    ? Environment.GetCommandLineArgs()[1]
    : "";

Generator generator = new Generator();
generator.GenCode(project);