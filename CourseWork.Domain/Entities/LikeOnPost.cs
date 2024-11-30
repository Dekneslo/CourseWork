using System;
using System.Collections.Generic;

namespace CourseWork.Domain.Entities
{
    public class LikeOnPost
    {
        public int LikeId { get; set; }
        
        public int UserId { get; set; }
        
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        
        public virtual User User { get; set; }
    }
}
