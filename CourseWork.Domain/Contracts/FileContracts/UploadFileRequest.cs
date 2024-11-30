namespace CourseWork.Domain.Contracts.FileContracts
{
    public class UploadFileRequest
    {
        public string FileName { get; set; }
        
        public string FilePath { get; set; }
        
        public int IdUser { get; set; }
        
        public string FileType { get; set; }
    }
}
