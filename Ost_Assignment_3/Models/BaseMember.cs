using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ost_Assignment_3.Models
{
    public class BaseMember
    {
        public int Id { get; set; }                
        public string FirstName { get; set; }      
        public string LastName { get; set; }       
        public string Email { get; set; }          
        public string Password { get; set; }       
        public string Gender { get; set; }         
        public string RoleName { get; set; }

        public bool UserRegistraion(string firstName, string lastName, string email, 
            string password, string gender, int roleId) 
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string commandText = "sp_RegisterNewUser"; 
            SqlCommand cmd = new SqlCommand(commandText, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@roleId", roleId);

            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();

            sqlConnection.Close();

            return true; 
        }

        public string FindMemberByUserName(string userName)
        {
            //BaseMember member = new BaseMember();
            string member = null;
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string commandText = "FindMember";
            SqlCommand cmd = new SqlCommand(commandText, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    member = reader["Email"].ToString();
                }
            }
            cmd.Dispose();
            sqlConnection.Close();
            return member;
        }

        public List<BaseMember> getAllUsers()
        {
            List<BaseMember> members = new List<BaseMember>();
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            string commandText = "select Id, FirstName, LastName, Email, Gender, RoleName " +
                "from OstMembers a inner join Roles b on a.RoleId = b.RoleId";
            SqlCommand cmd = new SqlCommand(commandText, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BaseMember member = new BaseMember
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    RoleName = reader["RoleName"].ToString()
                };
                members.Add(member);
            }
            cmd.Dispose();
            sqlConnection.Close();
            return members;
        }

    }
}