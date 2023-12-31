﻿using System.ComponentModel.DataAnnotations;

namespace HEALTH.Data
{
    public class User
    {
        public string UserID { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string RoleID { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        //
        public Role Role { get; set; }

        public ICollection<Workout> Workouts { get; set; }

        public User() 
        {
            Workouts = new List<Workout>();
        }
    }
}
