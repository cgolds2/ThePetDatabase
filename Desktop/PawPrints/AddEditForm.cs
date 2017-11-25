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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            animal.name = txtName.Text;
            int temp;
            //TODO figure out birthday
            animal.breed = txtBreed.Text;
            animal.animal_type = txtAnimalType.Text;
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

            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
