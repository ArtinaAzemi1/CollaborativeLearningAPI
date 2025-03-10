﻿namespace CollaborativeLearningAPI.Models
{
    public class Professor : Staff
    {
        public string Title { get; set; }

        public string SubjectArea { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

    }
}
