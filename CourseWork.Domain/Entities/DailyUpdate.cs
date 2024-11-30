namespace CourseWork.Domain.Entities
{
    public class DailyUpdate
    {
        public int DailyUpdateId { get; set; }
        
        public string Description { get; set; }

        public DateTime DateOfPosted { get; set; } = DateTime.UtcNow;
        
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
