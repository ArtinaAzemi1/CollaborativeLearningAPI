using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollaborativeLearningAPI.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Type { get; set; }

        public string Format { get; set; }

        public int? ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professors { get; set; }
    }
}
