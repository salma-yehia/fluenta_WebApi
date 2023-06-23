namespace italk.DAL.Data.Models
{
    public class Language
    {
        public enum LangName
        {
            Empty,
            English,
            Frensh,
            Germany
        }
        public int Id { get; set; }

        public LangName LanguageName { get; set; } = LangName.Empty;
        public ICollection<Instructor> instructors { get; set; } = new List<Instructor>();
        public ICollection<Course> Courses { get; set;}=new List<Course>();
    }
}
