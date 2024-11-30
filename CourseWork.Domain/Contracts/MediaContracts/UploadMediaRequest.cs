namespace CourseWork.Domain.Contracts.MediaContracts
{
    public class UploadMediaRequest
    {
        public string FileName { get; set; }
        
        public string FileType { get; set; }
        
        public byte[] FileData { get; set; }
    }
}
