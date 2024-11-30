namespace CourseWork.Domain.Contracts.FileContracts
{
    public class UpdateFileRequest
    {
        public string FileName { get; set; }
        
        public int IdUser { get; set; }
        
        public int FileId { get; set; }
        public string FileType { get; set; }
    }
}
