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
        private string name;
        private string surname;
        private string gender;
        private string dob;

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

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public User()
        {

        }

        public User(string userID, string username, string password, string name, string surname, string gender, string dob)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.dob = dob;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        // Method to extract the username and password from the data access layer
        public List<User> GetLoginCredentials()
        {
            List<User> loginCredentials = new List<User>();
            CRUD crud = new CRUD();
            DataSet data = crud.ReadFromDatabase("Username, Password", "tblUser");
            foreach (DataRow item in data.Tables["tblUser"].Rows)
            {
                loginCredentials.Add(new User(item["Username"].ToString(), item["Password"].ToString()));
            }
            return loginCredentials;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * Math.PI);
        }

        // Equals method to determine if Login credentials are valid
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is User))
            {
                return false;
            }
            User user = (User)obj;
            return (this.username == user.username) && (this.password == user.password);
        }
    }
}
