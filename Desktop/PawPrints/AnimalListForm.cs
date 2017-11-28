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
            dgvAnimalList.Rows.Clear();
            User curUser = ProgramMain.currentUser;
            Tuple<List<Animal>, int> result = WebHandeler.getAllAnimals(curUser.shelter_id);
            List<Animal> animalList = result.Item1;
            foreach (Animal animal in animalList)
            {
                if(WebHandeler.getPicture(animal.id).Item2 != -1)
                {
                    dgvAnimalList.Rows.Add(animal.id, animal.name, WebHandeler.getPicture(animal.id).Item1);
                }
                else
                {
                    MessageBox.Show("Error showing picture");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tuple<Animal, int> selectedAnimal = WebHandeler.getAnimal((int)dgvAnimalList.Rows[e.RowIndex].Cells[0].Value);
            AnimalDetailForm detailForm = new AnimalDetailForm(selectedAnimal.Item1);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AnimalListForm_Load(sender,e);
        }
    }
}
