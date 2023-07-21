using HEALTH.Data;
using HEALTH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HEALTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkuotController : ControllerBase
    {
        private readonly MyDBContext _context;

        public WorkuotController(MyDBContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Getall()
        {
            try
            {
                var DsWk = _context.Workouts.ToList();
                return Ok(DsWk);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{WkID}")]
        public IActionResult GetById( string WkID)
        {
            try
            {
                var DsWk = _context.Workouts.SingleOrDefault(w=>w.WorkoutID==WkID);
                return Ok(DsWk);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateWorkout(WoukoutModels models)
        {
            try
            {
                var W = new Workout
                {
                    WorkoutID=models.WorkoutID,
                    WorkoutName=models.WorkoutName,
                    Distance=models.Distance,
                    Speed=models.Speed,
                    Time=models.Time,
                    SportID=models.SportID,
                    UserID=models.UserID
                };
                _context.Add(W);
                _context.SaveChanges();
                return Ok(W);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{WkID}")]
        public IActionResult UpdateWorkout(string WkID, PutWorkoutModels pmodels)
        {
                     
            var DsWk = _context.Workouts.SingleOrDefault(w => w.WorkoutID == WkID);
            if(DsWk!=null)
             {
                    DsWk.WorkoutName=pmodels.WorkoutName;
                    DsWk.Distance=pmodels.Distance;
                    DsWk.Speed=pmodels.Speed;
                    DsWk.Time=pmodels.Time;
                    DsWk.SportID=pmodels.SportID;
                    DsWk.UserID=pmodels.UserID;
                    _context.SaveChanges();
                    return NoContent();
            }               
            else
               return NotFound();
            
        }

        [HttpDelete("{WkID}")]
        public IActionResult RemoveWorkout(string WkID)
        {
           var DsWk = _context.Workouts.SingleOrDefault(w => w.WorkoutID == WkID);
           if (DsWk != null)
                {
                    _context.Remove(DsWk);
                    _context.SaveChanges();
                    return Ok();
                }
           else          
               return NotFound();
                
        }
    }
}
