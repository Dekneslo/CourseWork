namespace CourseWork.Domain.Contracts.FileContracts
{
    public class FileResponse
    {
        public int IdFile { get; set; }
        
        public string FileName { get; set; }
        
        public string FileType { get; set; }
        
        public long FileSize { get; set; }
        
        public string FilePath { get; set; }
    }
}
