using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.DataAccessLayer;
using System.Data;

namespace _2.BusinessLogicLayer
{
    public class User
    {
        private string userID;
        private string username;
        private string password;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }

        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public User()
        {

        }

        public User(string userID, string username, string password)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        // Method to extract the username and password from the data access layer
        public bool UserLogin(string username, string password)
        {
            CRUD crud = new CRUD();
            string condition = string.Format("WHERE Username = '{0}' AND Password = '{1}'", username, password);
            DataSet data = crud.Read("Username, Password", "tblUser",condition);
            if (data.Tables["tblUser"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * Math.PI);
        }

        // Equals method to determine if Login credentials are valid
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
            {
                return false;
            }
            User user = (User)obj;
            return (this.username == user.username) && (this.password == user.password);
        }

        public bool RegisterUser(User user)
        {
            CRUD crud = new CRUD();
            bool successfulRegistration = crud.Insert("tblUser", "Username, Password", string.Format("{0},{1}", user.username, user.password));
            return successfulRegistration;
        }

        
    }
}
