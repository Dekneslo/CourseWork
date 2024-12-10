using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Entities
{
    public class LikesToCourse
    {
        [Key]
        public int LikeId { get; set; }
        
        public int UserId { get; set; }
        
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        
        public virtual User User { get; set; }
    }
}
