namespace CourseWork.Domain.Entities
{
    public class UserLanguage
    {
        public int IdUser { get; set; }
        public string Language { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
