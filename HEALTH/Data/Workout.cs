﻿namespace HEALTH.Data
{
    public class Workout
    {
        public string WorkoutID { get; set; }
        public string WorkoutName { get; set;}
        public string Distance { get; set;}
        public string Speed { get; set;}
        public string Time { get; set;}
        public string SportID { get; set; }
        public string UserID { get; set; }

        //
        public Sport sport { get; set; }
        public User user { get; set; }
    }
}
