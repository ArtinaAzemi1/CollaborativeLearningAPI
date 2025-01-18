using System.ComponentModel.DataAnnotations.Schema;

namespace CollaborativeLearningAPI.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
