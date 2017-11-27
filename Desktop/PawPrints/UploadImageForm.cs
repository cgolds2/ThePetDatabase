using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPrints
{
    public partial class UploadImageForm : Form
    {
        public Image imageResult;
        public int animalID;
        public UploadImageForm(Boolean needsID)
        {
            InitializeComponent();
            txtAnimalID.Visible = lblAnimalID.Visible = needsID;          
        }


        private void UploadImageForm_Load(object sender, EventArgs e)
        {
            Form frm = this;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:\Users\Connor\Desktop\Forms Screenshots\" + frm.Name + @".png");
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;
                string all = "Image Files|";
                foreach (ImageCodecInfo c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    Console.WriteLine(codecName);
                    fd.Filter = string.Format("{0}{1}{2} ({3})|{3}", fd.Filter, sep, codecName, c.FilenameExtension);
                    all += c.FilenameExtension+";";
                    sep = "|";
                }
                fd.Filter = string.Format("{0}{1}{2} ({3})|{3}", fd.Filter, sep, "All Files", "*.*");
                fd.Filter = all + "|" +  fd.Filter;
                DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK && fd.CheckFileExists)
                {
                    string filename = fd.FileName;
                    imageResult = Image.FromFile(filename);
                    pnlImagePreview.BackgroundImage = imageResult;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            animalID = int.Parse(txtAnimalID.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
