using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AmbulanceService
    {
        public static List<AmbulanceDTO> GetAmbulance()
        {
            var data = DataAccessFactory.AmbulanceDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ambulance, AmbulanceDTO>());
            var mapper = new Mapper(config);
            var ambulances = mapper.Map<List<AmbulanceDTO>>(data);
            return ambulances;
        }
        public static AmbulanceDTO Get(int id)
        {
            var data = DataAccessFactory.AmbulanceDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ambulance, AmbulanceDTO>());
            var mapper = new Mapper(config);
            var ambulance = mapper.Map<AmbulanceDTO>(data);
            return ambulance;
        }
        public static bool Add(AmbulanceDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AmbulanceDTO, ambulance>();
                cfg.CreateMap<ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var ambulance = mapper.Map<ambulance>(dto);
            var result = DataAccessFactory.AmbulanceDataAccess().Add(ambulance);
            return result;
        }
    }
}
