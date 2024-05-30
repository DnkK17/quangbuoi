using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;

namespace MrKool.Repository
{
    public class AreaRepository : IAreaRepository
    {
         
        private readonly DBContext _context;


        public AreaRepository(DBContext context)
        {
            _context = context;
        }

        public Area GetById(int areaID)
        {
            return _context.Set<Area>().SingleOrDefault(a => a.AreaID == areaID);
        }

        public List<Area> GetAll()
        {
            return _context.Set<Area>().ToList();
        }

        public List<Area> GetByNameContaining(string name)
        {
            return _context.Set<Area>().Where(a => a.Address.Contains(name)).ToList();
        }

        public List<Area> GetByCity(string city)
        {
            return _context.Set<Area>().Where(a => a.City == city).ToList();
        }
    }
}
