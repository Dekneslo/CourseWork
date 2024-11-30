namespace CourseWork.Domain.Entities
{
    public  class Course
    {
        public Course()
        {
            UsersCourses = new HashSet<UsersCourse>();
            
            Comments = new HashSet<Comment>();
            
            CourseFiles = new HashSet<CourseFile>();
            
            LikesToCourses = new HashSet<LikeOnCourse>();
        }

        public int CourseId { get; set; }
        
        public string CourseName { get; set; }
        
        public string? Description { get; set; }
        
        public int CategoryId { get; set; }
        
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
        
        public virtual ICollection<UsersCourse> UsersCourses { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<CourseFile> CourseFiles { get; set; }
        
        public virtual ICollection<LikeOnCourse> LikesToCourses { get; set; }
    }
    
}
