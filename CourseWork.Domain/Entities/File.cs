using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;
using Domain.Models;
using FileAccess = System.IO.FileAccess;

namespace CourseWork.Domain.Entities
{
    public class File
    {
        public int FileId { get; set; }
        
        public string FileName { get; set; } = null!;
        
        public string FileType { get; set; } = null!;
        
        public long FileSize { get; set; }
        
        public string FilePath { get; set; } = null!;
        
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<CourseMedia> CourseMedia { get; set; }
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<PostMedia> PostMedia { get; set; }
    }
}
