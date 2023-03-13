using CodeGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGeneratorGUI
{
    public partial class ModelEditForm : Form
    {
        public ModelMetadata Model { get; set; } = new ModelMetadata();

        public ModelEditForm()
        {
            InitializeComponent();
        }

        public ModelEditForm(ModelMetadata model)
        {
            Model = model;
            InitializeComponent();
            FillForm();
        }

        private void FillForm()
        {
            tbName.Text = Model.Name;
            RefreshPropsGridView();
        }

        private void RefreshPropsGridView()
        {
            dgvModels.DataSource = null;
            dgvModels.DataSource = Model.Props;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Model.Name = tbName.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model.Props.Add(new PropMetadata());
            RefreshPropsGridView();
        }
    }
}
