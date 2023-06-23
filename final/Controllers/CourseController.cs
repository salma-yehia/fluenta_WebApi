using italk.BL;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet("GetCourseByCategory/{category}")]
        public ActionResult<List<CourseReadDto>> GetCourseByCategory(string category)
        {
            return _courseManager.GetCourseByCategory(category);
        }
        [HttpGet("GetCourseByLanguage/{Languageid}")]

        public ActionResult<List<CourseReadDto>> GetCourseByLanguage(int Languageid)
        {
            return _courseManager.GetCourseByLanguage(Languageid);
        }
        [HttpGet("GetCourseByLevel/{level}")]
        public ActionResult<List<CourseReadDto>> GetCourseByLevel(string level)
        {
            return _courseManager.GetCourseByLevel(level);
        }

        [HttpPost]
        public ActionResult AddCourse(CourseAddDto course)
        {
            _courseManager.AddCourse(course);
            return Ok();
        }
    }
}
