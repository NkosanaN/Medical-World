using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Data.Models;

namespace Medical.Data
{
    public partial class MedicalDAL 
    {
        Utils utils = new Utils();
        public List<Doctor> GetDoctorsList()
        {
            var sql = "exec sp_doctor_data 0, 1"; 

            var dt = utils.Select(sql);
            var list = new List<Doctor>();

            foreach (DataRow row in dt.Rows )
            {
                list.Add(new Doctor
                {
                    Age = (int)row["Age"],
                    Name = row["Name"].ToString().Trim(),
                    Surname = row["Surname"].ToString().Trim(),
                });
            }
            return list;
        }
        public bool AddDoctors(Doctor data)
        {
            var sql = $"exec sp_doctor_process 0 , @Name = {data.Name} ,  @Age = {data.Age} , @Surname = {data.Surname}";

            return utils.Execute(sql);
        }        
      
    }
}
