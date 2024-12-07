namespace CourseWork.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Category Category { get; set; } 
        
        public int CategoryId { get; set; }
        
        public ICollection<User> EnrolledUsers { get; set; } = new List<User>();
    }
}