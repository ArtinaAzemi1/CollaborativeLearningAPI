using CollaborativeLearningAPI.Data;
using CollaborativeLearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CollaborativeLearningDBContext _context;

        public StudentController(CollaborativeLearningDBContext context)
        {
            _context = context;
        }


    }
}
