namespace HEALTH.Data
{
    public class Workout
    {
        public Guid WorkoutID { get; set; }
        public string WorkoutName { get; set;}
        public string WorkoutTime { get; set;}
        public Guid SportID { get; set; }

        //
        public Sport sport { get; set; }
        public User User { get; set; }
    }
}
