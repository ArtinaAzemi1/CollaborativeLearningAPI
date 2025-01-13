namespace CollaborativeLearningAPI.Models
{
    public class Assistant: Staff
    {
        public string ResearchField { get; set; }

        public Boolean AssistsInGrading { get; set; }

        public Boolean HelpsWithProjects { get; set; }
    }
}
