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
    public partial class AddEditForm : Form
    {
        private Animal animal;

        public AddEditForm()
        {
            InitializeComponent();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            Form frm = this;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:\Users\Connor\Desktop\Forms Screenshots\" + frm.Name + @".png");
            }
            //TODO autofill with previous information
        }

        //redirects to picture upload
        private void pnlProfilePic_Click(object sender, EventArgs e)
        {
            UploadImageForm uploadForm = new UploadImageForm(true);
            uploadForm.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            animal.name = txtName.Text;
            animal.age = dtpBirthday.Value;
            animal.breed = txtBreed.Text;
            animal.animal_type = txtAnimalType.Text;
            int temp;
            if (int.TryParse(txtWeight.Text, out temp))
            {
                animal.weight = temp;
            }
            else
            {
                MessageBox.Show("Weight must be a whole number");
            }
            animal.size = txtSize.Text;
            animal.notes = txtNotes.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
