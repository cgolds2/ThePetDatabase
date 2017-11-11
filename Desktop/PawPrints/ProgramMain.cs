using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPrints
{
    static class ProgramMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

           

            //Form x = new AddEditForm();
            //x.Show();
            //x.Close();
            //x = new AdminForm();
            //x.Show();
            //x.Close();
            // x = new AnimalDetailForm();
            //x.Show();
            //x.Close();
            // x = new AnimalListForm();
            //x.Show();
            //x.Close();
            // x = new CreateById();
            //x.Show();
            //x.Close();
            //x = new UploadImageForm();
            //x.Show();
            //x.Close();
        }
    }
}
