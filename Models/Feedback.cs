using System.ComponentModel.DataAnnotations.Schema;

namespace CollaborativeLearningAPI.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public string Rating { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Students { get; set; }

        public int? TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Tasks Tasks { get; set; }
    }
}
