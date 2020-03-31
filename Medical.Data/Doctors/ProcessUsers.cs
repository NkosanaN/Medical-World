using Medical.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data
{
    public partial class MedicalDAL
    {
        public List<Users> GetUsersList()
        {
            var sql = "exec sp_users_data 0";

            var dt = utils.Select(sql);
            var list = new List<Users>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Users
                {
                    DateOfBirth = (DateTime)row["DateOfBirth"],
                    FirstName = row["FirstName"].ToString().Trim(),
                    LastName = row["LastName"].ToString().Trim(),
                    Email = row["Email"].ToString().Trim(),
                    Password = row["Password"].ToString().Trim()
                });
            }
            return list;
        }
        public Users VerifyAcc(string firstname, string password)
        {
            var sql = $"exec sp_users_data 1 , @FirstName = {firstname} , @Password = {password} ";

            var dt = utils.Select(sql);
            if(dt.Rows.Count == 0) 
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            return new Users
            {
                DateOfBirth = (DateTime)row["DateOfBirth"],
                FirstName = row["FirstName"].ToString().Trim(),
                LastName = row["LastName"].ToString().Trim(),
                Email = row["Email"].ToString().Trim(),
                Password = row["Password"].ToString().Trim()
            };            
        }
        public bool AddUsers (Users data)
        {
            var sql = $"exec sp_users_process 0 , @FirstName = '{data.FirstName}' ,  @LastName = '{data.LastName}' , @Email = '{data.Email}' , @DateOfBirth = '{DateTime.Now}', @Password ='{data.Password}' ";

            return utils.Execute(sql);
        }

        //public bool VerifyAcc(Users data)
        //{
        //    var sql = $"exec sp_users_process 0 , @FirstName = '{data.FirstName}' ,  @LastName = '{data.LastName}' , @Email = '{data.Email}' , @DateOfBirth = '{DateTime.Now}', @Password ='{data.Password}' ";

        //    return utils.Execute(sql);
          
        //}
    }
}
