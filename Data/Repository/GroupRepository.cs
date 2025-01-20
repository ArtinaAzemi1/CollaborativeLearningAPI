namespace CollaborativeLearningAPI.Data.Repository
{
    public class GroupRepository
    {
        private CollaborativeLearningDBContext _context;

        public GroupRepository(CollaborativeLearningDBContext context)
        {
            _context = context;
        }


    }
}
