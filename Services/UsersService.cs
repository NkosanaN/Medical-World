using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication8.ViewModals;

namespace WebApplication8.Services
{
    public  class UsersService : IDisposable
    {
        //ProcessDoctors client = new ProcessDoctors();
        AutoMapper.IMapper mapper;


        public UsersService()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModal, Medical.Data.Models.Users>();
                cfg.CreateMap<Medical.Data.Models.Users, UserViewModal>();
            });
            mapper = config.CreateMapper();
        }

        public List<UserViewModal> GetUserList()
        {
            using (Medical.Data.MedicalDAL client = new Medical.Data.MedicalDAL(""))
            {
                return mapper.Map<List<UserViewModal>>(client.GetUsersList());
            }
        }
        public bool AddUsers(UserViewModal modal)
        {
            using (Medical.Data.MedicalDAL client = new Medical.Data.MedicalDAL(""))
            {
                return client.AddUsers(mapper.Map<Medical.Data.Models.Users>(modal));
            }
        }
        public UserViewModal VerifyUserAcc(string firstname , string password)
        {
            using (Medical.Data.MedicalDAL client = new Medical.Data.MedicalDAL(""))
            {
                return mapper.Map<UserViewModal>(client.VerifyAcc(firstname, password));
            }
        }
   
        public void Dispose()
        {
            ;
        }
    }
}
