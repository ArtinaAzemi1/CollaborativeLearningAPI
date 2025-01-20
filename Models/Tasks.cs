using System.ComponentModel.DataAnnotations.Schema;

namespace CollaborativeLearningAPI.Models
{
    public class Tasks
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public string Status { get; set; }

        public int? AssistantId { get; set; }
        [ForeignKey("AssistantId")]
        public Assistant Assistant { get; set; }
    }
}
