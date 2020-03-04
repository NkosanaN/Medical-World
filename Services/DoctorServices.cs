using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication8.ViewModals;

using Medical.Data;

namespace WebApplication8.Services
{
    public class DoctorServices : IDisposable
    {
        //ProcessDoctors client = new ProcessDoctors();
        AutoMapper.IMapper mapper;

    
        public DoctorServices()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorViewModal, Medical.Data.Models.Doctor>();
                cfg.CreateMap<Medical.Data.Models.Doctor, DoctorViewModal>();
            });
            mapper = config.CreateMapper();
        }

        public List<DoctorViewModal> GetDocList()
        {
            using (Medical.Data.MedicalDAL client = new Medical.Data.MedicalDAL(""))
            {
                return mapper.Map<List<DoctorViewModal>>(client.GetDoctorsList());
            }            
        }

        public void Dispose()
        {
            ;
        }
    }
}