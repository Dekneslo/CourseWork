using System.ComponentModel.DataAnnotations;
using CourseWork.Domain.Entities;


namespace CourseWork.Domain.Entities
{
    public class CourseMedia
    {
        [Key]
        public int MediaId { get; set; }
        
        public int CourseId { get; set; }
        
        public int FileId { get; set; }

        public Course Course { get; set; }
        
        public File File { get; set; }
    }
}
