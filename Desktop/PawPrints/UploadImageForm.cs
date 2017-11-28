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
        public string filename;
        public bool needsIDVal;

        public UploadImageForm(Boolean needsID)
        {
            InitializeComponent();
            txtAnimalID.Visible = lblAnimalID.Visible = needsID;
            needsIDVal = needsID;
        }


        private void UploadImageForm_Load(object sender, EventArgs e)
        {
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
                    filename = fd.FileName;
                    imageResult = Image.FromFile(filename);
                    pnlImagePreview.BackgroundImage = imageResult;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (needsIDVal)
            {
                string aid = txtAnimalID.Text;
                int temp;
                if (int.TryParse(aid, out temp))
                {
                    animalID = int.Parse(txtAnimalID.Text);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please enter a valid animal id");
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
