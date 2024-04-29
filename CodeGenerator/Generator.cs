using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using CodeGenerator.Projects;

namespace CodeGenerator
{
    public class Generator
    {
        public Settings Settings { get; set; } = Settings.DefaultDevSettings;
        public void GenCode(string projectName)
        {
            ProjectMetadata projectMetadata = (!string.IsNullOrEmpty(projectName))
                ? ReadMetaInfo(projectName)
                : TestProjectMetadata();

            List<IProject> projectGenerators = GetGeneratorsForSolution(projectMetadata);

            foreach (IProject project in projectGenerators)
            {
                project.GenProjectFiles();
            }

        }

        private List<IProject> GetGeneratorsForSolution(ProjectMetadata projectMetadata)
        {
            List<IProject> projectGenerators = new List<IProject>();

            if (Settings != null)
            {
                //TODO: для каждого проекта свои MetaData
                if (Settings.GenSolution)
                {
                    projectGenerators.Add(new SolutionProject(projectMetadata));
                }
                if (Settings.GenBllProject)
                {
                    projectGenerators.Add(new BuisinessLogicLayerProject(projectMetadata));
                }                
                if (Settings.GenDalProject)
                {
                    projectGenerators.Add(new DataAccessLayerProject(projectMetadata));
                }
                if (Settings.GenReactProject)
                {
                    projectGenerators.Add(new ReactBootstrapProject(projectMetadata));
                }
                if (Settings.GenWdScriptProject)
                {
                    projectGenerators.Add(new WinDrawScriptProject(projectMetadata));
                }
                if (Settings.GenWebApiProject)
                {
                    projectGenerators.Add(new WebApiProject(projectMetadata));
                }
                if (Settings.GenTestsProject)
                {
                    projectGenerators.Add(new TestsProject(projectMetadata));
                }

            }

            return projectGenerators;
        }

        private static ProjectMetadata TestProjectMetadata()
        {
            ProjectMetadata metadata = new ProjectMetadata();
            metadata.Name = "TestSoloution";
            metadata.Description = "Solution for testing generator when development";
            metadata.Path = "./TestSolution";
            metadata.Models = new List<ModelMetadata> { 
                new ModelMetadata(){
                    Name = "TestModel1",  
                    Caption = "Тестовая модель 1",
                    NameSpace = "TestNamespace",
                    Props = new List<PropMetadata>()
                    {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Description",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int"
                        }
                    }
                    
                }
            };

            return metadata;
        }

        private static ProjectMetadata ReadMetaInfo(string projectName)
        {
            ProjectMetadata res = FileService.ReadFile<ProjectMetadata>($"{projectName}.json");

            return res;
        }
    }
}
