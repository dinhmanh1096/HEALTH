using HEALTH.Data;
using HEALTH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HEALTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext _context;

        public UserController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll() 
        {
            try
            {
                var DsUser = _context.Users.ToList();
                return Ok(DsUser);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpGet("{UserID}")]
        public ActionResult GetById(string UserID) 
        {
            var DsUser= _context.Users.SingleOrDefault(us=>us.UserID==UserID);
            if(DsUser!=null)
            {
                return Ok(DsUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNewUser(UserModels models)
        {
            try 
            {
                var UsID = new User
                {
                    UserID = models.UserID,
                    UserName = models.UserName,
                    Address = models.Address,
                    PhoneNumber = models.PhoneNumber,
                    RoleID = models.RoleID,
                    Password = models.Password
                };
                _context.Add(UsID);
                _context.SaveChanges();
                return Ok(UsID);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{UserID}")]
        public IActionResult UpdateUserById(string UserID,PutUserModels putUserModels)
        {
            var DsUser = _context.Users.SingleOrDefault(us => us.UserID == UserID);
            if(DsUser!=null) 
            {
                DsUser.UserName=putUserModels.UserName;
                DsUser.Address=putUserModels.Address;
                DsUser.PhoneNumber=putUserModels.PhoneNumber;
                DsUser.RoleID=putUserModels.RoleID;
                DsUser.Password=putUserModels.Password;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{UserID}")]
        public IActionResult RemoveUser(string UserID) 
        {
            var DsUser = _context.Users.SingleOrDefault(us => us.UserID == UserID);
            if(DsUser!=null)
            {
                _context.Remove(DsUser);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
