using HEALTH.Data;
using HEALTH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HEALTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly MyDBContext _context;

        public SportController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                var DsSport = _context.Sports.ToList();
                return Ok(DsSport);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{SportID}")]
        public IActionResult GetById(string SportID)
        {
            var DsSport = _context.Sports.SingleOrDefault(sp => sp.SportID == SportID);
            if (DsSport != null)
            {
                return Ok(DsSport);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNew(SportModels models)
        {
            try
            {
                var Spid = new Sport
                {
                    SportID = models.SportID,
                    SportName = models.SportName

                };

                _context.Add(Spid);
                _context.SaveChanges();
                return Ok(Spid);
            }
            catch
            { return BadRequest(); }
        }

        [HttpPut("{SportID}")]
        public IActionResult UpdateSportById(string SportID, PutSportModels models)
        {
            var DsSport = _context.Sports.SingleOrDefault(sp => sp.SportID == SportID);
            if (DsSport != null)
            {
                DsSport.SportName = models.SportName;
                _context.SaveChanges();
                return NoContent();
            }
            else
                return NotFound();
        }

        [HttpDelete("{SportID}")]
        public IActionResult Remove(string SportID)
        {
            var DsSport = _context.Sports.SingleOrDefault(sp => sp.SportID == SportID);
            if (DsSport != null)
            {
                _context.Remove(DsSport);
                _context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
