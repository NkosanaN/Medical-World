using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data
{
    public partial class MedicalDAL : IDisposable
    {

        private bool debugging = true;
        private string dbName;


        public MedicalDAL(string db)
        {
            string str = ConfigurationManager.AppSettings["debug"] ?? "false";
            bool.TryParse(str, out debugging);
            if (debugging)
            { }
            dbName = db;
        }
        public void Dispose()
        {
            ;
        }
    }
}
