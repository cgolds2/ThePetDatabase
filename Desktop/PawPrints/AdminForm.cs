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
    public partial class AdminForm : Form
    {
        public AdminForm(Boolean isAdmin)
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Form frm = this;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:\Users\Connor\Desktop\Forms Screenshots\" + frm.Name + @".png");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (areFieldsBlank())
            {
                MessageBox.Show("Username, Password, and Email must not be blank");
            }else
            {
                User u = new User();
                u.email = txtEmail.Text;
                u.password = txtPassword.Text;
                u.username = txtUsername.Text;
                WebHandeler.createUser(u);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Password must not be blank");
            }
            else
            {
                if(dgvAnimalList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a user to edit password of");

                }
                else
                {
                    //Grid is layed out as id-email-username
                    int id = (int)dgvAnimalList.SelectedRows[0].Cells[0].Value;
                    User u = new User();
                    u.email = (string)dgvAnimalList.SelectedRows[0].Cells[1].Value;
                    u.password = txtPassword.Text;
                    u.username = (string)dgvAnimalList.SelectedRows[0].Cells[2].Value;
                    WebHandeler.updateUser(u, id);
                }
      
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvAnimalList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete");

            }
            else
            {


                //Grid is layed out as id-email-username
                int id = (int)dgvAnimalList.SelectedRows[0].Cells[0].Value;
                string username = (string)dgvAnimalList.SelectedRows[0].Cells[2].Value;

                DialogResult result = MessageBox.Show("Do you want to delete user " + username, "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    WebHandeler.deleteUsers(id);

                }


            }
        }
        private bool areFieldsBlank()
        {
            return txtPassword.Text.Equals("") || txtUsername.Text.Equals("") || txtEmail.Text.Equals("");

        }
    }
}
