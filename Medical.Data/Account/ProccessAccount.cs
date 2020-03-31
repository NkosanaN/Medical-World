using Medical.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data
{
    public class ProccessAccount
    {
        public bool VerifyAcc(Users data)
        {
            //var sql = $"exec sp_users_process 0 , @FirstName = '{data.FirstName}' ,  @LastName = '{data.LastName}' , @Email = '{data.Email}' , @DateOfBirth = '{DateTime.Now}', @Password ='{data.Password}' ";

            //return utils.Execute(sql);
            return true;
        }
    }
}
