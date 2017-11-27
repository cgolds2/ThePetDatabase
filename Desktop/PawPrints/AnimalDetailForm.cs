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
            Form frm = this;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:\Users\Connor\Desktop\Forms Screenshots\" + frm.Name + @".png");
            }
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
            UploadImageForm uploadForm = new UploadImageForm(true);
            uploadForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
