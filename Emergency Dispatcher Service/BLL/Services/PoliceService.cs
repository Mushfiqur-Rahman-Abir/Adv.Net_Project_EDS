using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PoliceService
    {
        public static List<PoliceDTO> GetPolice()
        {
            var data = DataAccessFactory.PoliceDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<police, PoliceDTO>());
            var mapper = new Mapper(config);
            var Polices = mapper.Map<List<PoliceDTO>>(data);
            return Polices;
        }
        public static PoliceDTO Get(int id)
        {
            var data = DataAccessFactory.PoliceDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<police, PoliceDTO>());
            var mapper = new Mapper(config);
            var Police = mapper.Map<PoliceDTO>(data);
            return Police;
        }
        public static bool Add(PoliceDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PoliceDTO, police>();
                cfg.CreateMap<police, PoliceDTO>();
            });
            var mapper = new Mapper(config);
            var police = mapper.Map<police>(dto);
            var result = DataAccessFactory.PoliceDataAccess().Add(police);
            return result;
        }
    }
}
