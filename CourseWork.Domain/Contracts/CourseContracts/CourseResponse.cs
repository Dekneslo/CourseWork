using CourseWork.Domain.Contracts.UserContracts;

namespace CourseWork.Domain.Contracts.CourseContracts
{
    public class CourseResponse
    {
        public required int CourseId { get; set; }
        
        public required string CourseName { get; set; }
        
        public required string Description { get; set; }
        
        public required string CategoryName { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public required int CategoryId { get; set; }
    }
}
