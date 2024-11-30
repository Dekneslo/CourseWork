namespace CourseWork.Domain.Entities
{
    public class UsersCourse
    {
        public int UserId { get; set; }
        
        public virtual User User { get; set; } 
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; } 
    }
}
