using CodeGenerator.Services;

namespace CodeGeneratorGUI
{
    public partial class ProjectListForm : Form
    {
        public ProjectFileManager ProjectManager { get; set; }
        public ProjectListForm()
        {
            InitializeComponent();
            ProjectManager = new ProjectFileManager("./projects");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            var projects = ProjectManager.GetProjects();
            dgvProjects.DataSource = projects;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProjectEditForm editForm = new ProjectEditForm();
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                ProjectManager.SaveProject(editForm.Project.Name, editForm.Project);
            }
        }
    }
}