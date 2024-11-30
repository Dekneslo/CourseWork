﻿using System;
using System.Collections.Generic;

namespace CourseWork.Domain.Entities
{
    public class LikeOnCourse
    {
        public int LikeId { get; set; }
        
        public int UserId { get; set; }
        
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } 
        
        public virtual User User { get; set; }
    }
}
