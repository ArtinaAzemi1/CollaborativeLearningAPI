namespace CollaborativeLearningAPI.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public string Day { get; set; } // Alternatively, you can use an enum for days of the week.
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }

        public string Hall { get; set; }
    }
}
