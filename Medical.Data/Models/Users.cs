using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Models
{
    public class Users
    {
		public int id { set; get; }
		public string FirstName { set; get; }
		public string LastName { set; get; }
		public string Email { set; get; }
		public string Password { set; get; }
		public System.DateTime DateOfBirth { set; get; }
	}
}
