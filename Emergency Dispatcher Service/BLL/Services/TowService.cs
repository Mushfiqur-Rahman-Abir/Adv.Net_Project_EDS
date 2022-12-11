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
    public class TowService
    {
        public static List<TowDTO> GetTow()
        {
            var data = DataAccessFactory.TowDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<towservice, TowDTO>());
            var mapper = new Mapper(config);
            var Tows = mapper.Map<List<TowDTO>>(data);
            return Tows;
        }
        public static TowDTO Get(int id)
        {
            var data = DataAccessFactory.TowDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<towservice, TowDTO>());
            var mapper = new Mapper(config);
            var Tow = mapper.Map<TowDTO>(data);
            return Tow;
        }
        public static bool Add(TowDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TowDTO, towservice>();
                cfg.CreateMap<towservice, TowDTO>();
            });
            var mapper = new Mapper(config);
            var Tow = mapper.Map<towservice>(dto);
            var result = DataAccessFactory.TowDataAccess().Add(Tow);
            return result;
        }
    }
}
