using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWork.Domain.Entities;
using File = CourseWork.Domain.Entities.File;

namespace CourseWork.Domain.Entities
{
    public class PostMedia
    {
        [Key]
        public int MediaId { get; set; }
        
        public int PostId { get; set; }
        
        public int FileId { get; set; }
        

        public File File { get; set; }
        
        public Post Post { get; set; } 
        
    }
}
