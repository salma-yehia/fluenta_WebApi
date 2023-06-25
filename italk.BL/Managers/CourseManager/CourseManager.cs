using AutoMapper;
using italk.DAL;
using italk.DAL.UnitOfWork;
using static italk.DAL.CrsEnums;

namespace italk.BL;
public class CourseManager : ICourseManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public List<CourseReadDto> GetCourseByCategory(string category)
    {
        Category _category=(Category)Enum.Parse(typeof(Category), category);
        IQueryable<Course> Courses = _unitOfWork.CourseRepo.GetCourseByCategory(_category);
        return _mapper.Map<List<CourseReadDto>>(Courses);
    }

    public List<CourseReadDto> GetCourseByLanguage(int Languageid)
    { 
        IQueryable<Course> Courses = _unitOfWork.CourseRepo.GetCourseByLanguage(Languageid);
        return _mapper.Map<List<CourseReadDto>>(Courses);

    }

    public List<CourseReadDto> GetCourseByLevel(string level)
    {
        Level _level=(Level)Enum.Parse(typeof(Level), level);
        IQueryable<Course> Courses = _unitOfWork.CourseRepo.GetCourseByLevel(_level);
        return _mapper.Map<List<CourseReadDto>>(Courses);

    }
    public void AddCourse(CourseAddDto courseAddDto)
    {
        var CourseList = _mapper.Map<Course>(courseAddDto);
        _unitOfWork.CourseRepo.AddCourse(CourseList);
        _unitOfWork.SaveChanges();
        
    }

}
