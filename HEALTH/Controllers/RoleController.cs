using HEALTH.Data;
using HEALTH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HEALTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly MyDBContext _context;

        public RoleController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var DsRole = _context.Roles.ToList();
                return Ok(DsRole);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{RoleID}")]
        public IActionResult GetById(string RoleID)
        {
            var DsRole= _context.Roles.SingleOrDefault(r=>r.RoleID==RoleID);
            if (DsRole != null)
            {
                return Ok(DsRole);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNewRole(RoleModels models)
        {
            try
            {
                var rID = new Role
                {
                    RoleID = models.RoleID,
                    RoleName = models.RoleName
                };
                _context.Add(rID);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{RoleID}")]
        public IActionResult UpdateRole(String RoleID,PutRoleModels models)
        {
            var DsRole = _context.Roles.SingleOrDefault(r => r.RoleID == RoleID);
            if (DsRole != null)
            {
                DsRole.RoleName = models.RoleName; 
                _context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpDelete("{RoleID}")]
        public IActionResult Remove(string RoleID)
        {
            var DsRole = _context.Roles.SingleOrDefault(r => r.RoleID == RoleID);
            if (DsRole != null)
            {
                _context.Remove(DsRole);
                _context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
