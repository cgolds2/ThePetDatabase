using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPrints
{
    class User
    {
        private string _email;
        private string _password;
        private string _username;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }


        public User()
        {

        }
    }
}
