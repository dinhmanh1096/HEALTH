using System.ComponentModel.DataAnnotations;

namespace HEALTH.Data
{
    public class Sport
    {
        public string SportID { get; set; }

        [MaxLength(50)]
        public string SportName { get; set; } 
        public ICollection<Workout> Workouts { get; set; }
        
    }
}
