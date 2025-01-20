using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

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

        public int CoordinatorId { get; set; }
        public virtual Coordinator Coordinator { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
