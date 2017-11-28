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
        bool isAdmin;
        public AdminForm()
        {
            InitializeComponent();
            isAdmin = WebHandeler.isUserAdmin(ProgramMain.currentUser);
            btnDeleteUser.Enabled = isAdmin;
            btnCreateUser.Enabled = isAdmin;

        }

        public void updateGrid()
        {
            dgvUserList.Rows.Clear();
            if (isAdmin)
            {
                Tuple<List<User>, int> response = WebHandeler.getAllUsers(ProgramMain.currentUser.shelter_id);
                if (response.Item2 == 1)
                {

                    List<User> users = response.Item1;

                    foreach (User u in users)
                    {
                        dgvUserList.Rows.Add(u.id, u.email, u.username);
                    }
                }
                else if (response.Item2 == -1)
                {
                    MessageBox.Show("Error getting users");
                }
                else if (response.Item2 == -2)
                {
                    MessageBox.Show("Could not connect to server");

                }
            }
            else
            {
                User u = ProgramMain.currentUser;
                dgvUserList.Rows.Add(u.id, u.email, u.username);
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (areFieldsBlank())
            {
                MessageBox.Show("Username, Password, and Email must not be blank");
            }
            else
            {
                User u = new User();
                u.email = txtEmail.Text;
                u.password = txtPassword.Text;
                u.username = txtUsername.Text;
                u.shelter_id = ProgramMain.currentUser.shelter_id;
                MessageBox.Show("User: " + u.shelter_id + "    Current User:" + ProgramMain.currentUser.shelter_id);
                if (WebHandeler.createUser(u) == 1){
                    MessageBox.Show("User creation successful");
                    updateGrid();
                }
                else
                {
                    MessageBox.Show("User creation failed.");
                }
            }
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Password must not be blank");
            }
            else
            {
                if (dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a user to edit");

                }
                else
                {
                    //Grid is layed out as id-email-username
                    int id = (int)dgvUserList.SelectedRows[0].Cells[0].Value;
                    User u = ProgramMain.currentUser;
                    u.email = txtEmail.Text;
                    u.password = txtPassword.Text;
                    u.username = txtUsername.Text;
                    u.id = id;
                    if (WebHandeler.updateUser(u) == 1)
                    {
                        MessageBox.Show("Update successful!");
                    }
                }

            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete");

            }
            else
            {

                //Grid is layed out as id-email-username
                int id = (int)dgvUserList.SelectedRows[0].Cells[0].Value;
                if(id == ProgramMain.currentUser.id)
                {
                    MessageBox.Show("Cannot delete current user");
                    return;
                }
                string username = (string)dgvUserList.SelectedRows[0].Cells[2].Value;

                DialogResult result = MessageBox.Show("Do you want to delete user " + username, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    WebHandeler.deleteUsers(id);
                    btnRefresh_Click(sender,e);
                }


            }
        }
        private bool areFieldsBlank()
        {
            return txtPassword.Text.Equals("") || txtUsername.Text.Equals("") || txtEmail.Text.Equals("");

        }

        private void dgvUserList_CurrentCellChanged(object sender, EventArgs e)
        {
         
       

        }

        private void dgvUserList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvUserList.SelectedRows.Count > 0)
            {
              txtUsername.Text = (string)dgvUserList.SelectedRows[0].Cells[2].Value;
            txtEmail.Text = (string)dgvUserList.SelectedRows[0].Cells[1].Value;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminForm_Load(sender, e);
        }
    }
}
