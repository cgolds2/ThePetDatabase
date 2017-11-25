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
        public AnimalDetailForm()
        {
            InitializeComponent();
        }
        private void AnimalForm_Load(object sender, EventArgs e)
        {
            Form frm = this;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:\Users\Connor\Desktop\Forms Screenshots\" + frm.Name + @".png");
            }
        }

        //redirects to AddEditForm
        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditForm editForm = new AddEditForm();
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
            throw new NotImplementedException();
            //TODO close
        }
    }
}
