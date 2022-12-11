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
    public class FireService
    {
        public static List<FireDTO> GetFire()
        {
            var data = DataAccessFactory.FireDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<fireservice, FireDTO>());
            var mapper = new Mapper(config);
            var fires = mapper.Map<List<FireDTO>>(data);
            return fires;
        }
        public static FireDTO Get(int id)
        {
            var data = DataAccessFactory.FireDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<fireservice, FireDTO>());
            var mapper = new Mapper(config);
            var fire = mapper.Map<FireDTO>(data);
            return fire;
        }
        public static bool Add(FireDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FireDTO, fireservice>();
                cfg.CreateMap<fireservice, FireDTO>();
            });
            var mapper = new Mapper(config);
            var fire = mapper.Map<fireservice>(dto);
            var result = DataAccessFactory.FireDataAccess().Add(fire);
            return result;
        }
    }
}
