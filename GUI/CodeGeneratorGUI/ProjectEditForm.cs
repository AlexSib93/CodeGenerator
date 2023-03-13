using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGeneratorGUI
{
    public partial class ProjectEditForm : Form
    {
        public ProjectMetadata Project { get; set; }

        public ProjectEditForm()
        {
            Project = new ProjectMetadata();
            InitializeComponent();
        }

        public ProjectEditForm(ProjectMetadata project)
        {
            Project = project;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Project.Name = tbProjectName.Text;
            Project.Description = tbDescription.Text;
        }
    }
}
