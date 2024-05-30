using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.Models;
using MrKool.Repository;
using System.Collections.Generic;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : Controller
    {
        private readonly AreaRepository _areaRepository;

        public AreaController(DBContext context)
        {
            _areaRepository = new AreaRepository(context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Area>> GetAllAreas()
        {
            return _areaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Area> GetAreaById(int id)
        {
            var area = _areaRepository.GetById(id);
            if (area == null)
            {
                return NotFound();
            }
            return area;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Area>> SearchAreas(string keyword)
        {
            return _areaRepository.GetByNameContaining(keyword);
        }


    }
}
