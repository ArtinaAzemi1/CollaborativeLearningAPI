using System.ComponentModel.DataAnnotations.Schema;

namespace CollaborativeLearningAPI.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public string Day { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }

        public string Hall { get; set; }
    }
}
