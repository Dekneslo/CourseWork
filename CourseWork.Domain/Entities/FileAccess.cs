namespace CourseWork.Domain.Entities
{
    public class FileAccess
    {
        public int AccessId { get; set; }
        
        public int IdFile { get; set; }
        
        public int IdUser { get; set; }
        
        public string AccessType { get; set; }

        public virtual File File { get; set; }
        
        public virtual User User { get; set; }
    }
}
