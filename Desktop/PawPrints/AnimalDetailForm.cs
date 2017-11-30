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
    public partial class AnimalDetailForm : Form
    {
        Animal animal;
        public AnimalDetailForm(Animal ani)
        {
            InitializeComponent();
            animal = ani;
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            //autofills form with current information on animal
            txtName.Text = animal.name;
            dtpBirthday.Value = animal.age;
            txtBreed.Text = animal.breed;
            txtAnimalType.Text = animal.animal_type;
            txtWeight.Text = animal.weight.ToString();            
            txtSize.Text = animal.size;
            txtNotes.Text = animal.notes;
        }

        //redirects to AddEditForm
        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditForm editForm = new AddEditForm(animal);
            editForm.Show();
        }

        //redirects to UploadByID form
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (UploadImageForm uploadForm = new UploadImageForm(false))
            {
                if(uploadForm.ShowDialog() == DialogResult.OK)
                {
                    string fname = uploadForm.filename;
                    WebHandeler.addPicture(fname, animal.id);
                    AnimalForm_Load(sender,e);
                    //TODO REFRESH ANIMALLIST
                    this.Close();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            WebHandeler.deleteAnimal(animal.id);
            this.Close();
        }
    }
}
