namespace CollaborativeLearningAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public double ECTS { get; set; }

        public string Semester { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
