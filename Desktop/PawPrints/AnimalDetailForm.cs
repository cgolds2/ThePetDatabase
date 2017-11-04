﻿using System;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
           

        }
    }
}
