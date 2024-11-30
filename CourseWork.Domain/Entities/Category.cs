namespace CourseWork.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
