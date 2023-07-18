using System.ComponentModel.DataAnnotations;

namespace HEALTH.Data
{
    public class User
    {
        public Guid UserID { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public Guid WorkoutID { get; set; }
        public Guid RoleID { get; set; }

        public Role Role { get; set; }

        public Workout Workout { get; set; }
    }
}
