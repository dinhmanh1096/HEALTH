namespace HEALTH.Data
{
    public class Workout
    {
        public Guid WorkoutID { get; set; }
        public string WorkoutName { get; set;}
        public string Distance { get; set;}
        public string Speed { get; set;}
        public string Time { get; set;}
        public Guid SportID { get; set; }
        public Guid UserID { get; set; }

        //
        public Sport sport { get; set; }
        public User user { get; set; }
    }
}
