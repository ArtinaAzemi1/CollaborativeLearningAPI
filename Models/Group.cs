namespace CollaborativeLearningAPI.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Year { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
