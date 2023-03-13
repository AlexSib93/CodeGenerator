using CodeGenerator.Metadata;
using CodeGenerator.Services;

namespace CodeGeneratorGUI
{
    public partial class ProjectListForm : Form
    {
        public ProjectFileManager ProjectManager { get; set; } = new ProjectFileManager("./projects");
        public ProjectListForm()
        {
            InitializeComponent();
            Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
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
                Refresh();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProjectMetadata selectedProject = GetSelectedProject();
            if (selectedProject != null)
            {
                ProjectEditForm editForm = new ProjectEditForm(selectedProject);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    ProjectManager.SaveProject(editForm.Project.Name, editForm.Project);
                    Refresh();
                }
            }
        }

        private ProjectMetadata GetSelectedProject()
        {
            ProjectMetadata res = new ProjectMetadata();
            if(dgvProjects.SelectedRows.Count > 0)
            {
                res = (ProjectMetadata)dgvProjects.SelectedRows[0].DataBoundItem;
            }

            return res;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProjectMetadata selectedProject = GetSelectedProject();
            if (selectedProject != null)
            {
                ProjectManager.DeleteProjectFile(selectedProject.Name);
                Refresh();
            }
        }
    }
}