using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Entities
{
    public class LikesToPost
    {
        [Key]
        public int LikeId { get; set; }
        
        public int UserId { get; set; }
        
        public int PostId { get; set; }

        public Post Post { get; set; }
        
        public User User { get; set; }
    }
}
