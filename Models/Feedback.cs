namespace CollaborativeLearningAPI.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public string Rating { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
