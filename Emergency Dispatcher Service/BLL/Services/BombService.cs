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
    public class BombService
    {
        public static List<BombDTO> GetBomb()
        {
            var data = DataAccessFactory.BombDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bombdisposal, BombDTO>());
            var mapper = new Mapper(config);
            var Bombs = mapper.Map<List<BombDTO>>(data);
            return Bombs;
        }
        public static BombDTO Get(int id)
        {
            var data = DataAccessFactory.BombDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bombdisposal, BombDTO>());
            var mapper = new Mapper(config);
            var Bomb = mapper.Map<BombDTO>(data);
            return Bomb;
        }
        public static bool Add(BombDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BombDTO, bombdisposal>();
                cfg.CreateMap<bombdisposal, BombDTO>();
            });
            var mapper = new Mapper(config);
            var Bomb = mapper.Map<bombdisposal>(dto);
            var result = DataAccessFactory.BombDataAccess().Add(Bomb);
            return result;
        }
    }
}
