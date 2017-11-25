using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPrints
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dcrypt.it/decrypt/paste");
            Tuple<User,int> response = WebHandeler.verifyUser(txtUsername.Text, txtPassword.Text);

            if (response.Item2 == -1)
            {
                MessageBox.Show("Incorrect Login");
            }
            else if (response.Item2 == -2)
            {
                MessageBox.Show("Could not connect to server");

            }
            else if(response.Item2 == 1)
            {
                ProgramMain.currentUser = response.Item1;
                this.Hide();
                AnimalListForm switchTo = new AnimalListForm();
                switchTo.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("An unidentified error has occured");

            }

            //using(UploadImageForm u = new UploadImageForm(true))
            //{
            //    DialogResult res = u.ShowDialog();
            //    if(res == DialogResult.OK)
            //    {
            //        Console.WriteLine("Okay");

            //    }
            //}


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
