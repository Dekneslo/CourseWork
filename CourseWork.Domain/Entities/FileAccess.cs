using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;
using File = CourseWork.Domain.Entities.File;

namespace CourseWork.Domain.Entities
{
    public class FileAccess
    {
        public int FileId { get; set; }
        
        public int UserId { get; set; }
        
        public string AccessType { get; set; }
        
        public virtual File IdFileNavigation { get; set; }
        
        public virtual User IdUserNavigation { get; set; }
    }
}
