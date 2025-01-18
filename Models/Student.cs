using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CollaborativeLearningAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Groups { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
