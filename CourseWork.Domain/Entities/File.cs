namespace CourseWork.Domain.Entities
{
    public class File
    {
        public File()
        {
            CourseFiles = new HashSet<CourseFile>();
            
            FileAccesses = new HashSet<FileAccess>();
            
            PostMedia = new HashSet<PostFile>();
        }

        public int FileId { get; set; }
        
        public string FileName { get; set; }
        
        public string FileType { get; set; }
        
        public long FileSize { get; set; }
        
        public string FilePath { get; set; }
        
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        
        public virtual ICollection<CourseFile> CourseFiles { get; set; }
        
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        
        public virtual ICollection<PostFile> PostMedia { get; set; }
    }
}
