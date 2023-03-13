using CodeGenerator;
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
            FillForm();
        }

        private void FillForm()
        {
            tbDescription.Text = Project.Description;
            tbProjectName.Text = Project.Name;
            RefreshModelsGridView();
        }

        private void RefreshModelsGridView()
        {
            dgvModels.DataSource = null;
            dgvModels.DataSource = Project.Models;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Project.Name = tbProjectName.Text;
            Project.Description = tbDescription.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModelEditForm modelEditForm = new ModelEditForm();
            if(modelEditForm.ShowDialog() == DialogResult.OK)
            {
                Project.Models.Add(modelEditForm.Model);
                RefreshModelsGridView();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ModelMetadata selectedModel = GetSelectedModel();
            if (selectedModel != null)
            {
                ModelEditForm editForm = new ModelEditForm(selectedModel);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        private ModelMetadata GetSelectedModel()
        {
            ModelMetadata res = new ModelMetadata();
            if (dgvModels.SelectedRows.Count > 0)
            {
                res = (ModelMetadata)dgvModels.SelectedRows[0].DataBoundItem;
            }

            return res;
        }
    }
}
