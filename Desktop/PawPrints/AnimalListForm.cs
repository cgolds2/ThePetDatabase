using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPrints
{
    public partial class AnimalListForm : Form
    {
        public AnimalListForm()
        {
            InitializeComponent();
        }

        private void AnimalListForm_Load(object sender, EventArgs e)
        {
            //getAllAnimals(int shelterID)
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO open up this specific animal page
            //getAnimal(animalID)
            AnimalDetailForm detailForm = new AnimalDetailForm(WebHandeler.getAnimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value));
            detailForm.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm switchTo = new AdminForm();
            switchTo.ShowDialog();
        }
        
        private void btnAddPet_Click(object sender, EventArgs e)
        {
            AddEditForm addForm = new AddEditForm();
            addForm.ShowDialog();
        }

        private void btnEditPet_Click(object sender, EventArgs e)
        {
            AddEditForm editForm = new AddEditForm();
            editForm.ShowDialog();
        }
    }
}
