namespace CourseWork.Domain.Contracts.FileContracts
{
    public class AccessRequest
    {
        public int UserId { get; set; }
        public string AccessType { get; set; } // 'read', 'write', 'admin'
    }
}