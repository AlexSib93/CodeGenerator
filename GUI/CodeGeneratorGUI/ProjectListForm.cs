using CodeGenerator.Services;

namespace CodeGeneratorGUI
{
    public partial class ProjectListForm : Form
    {
        public ProjectListForm()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var mngr = new ProjectFileManager("./projects");
            var projects = mngr.GetProjects();
            dgvProjects.DataSource = projects;
        }
    }
}