using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Entities
{
    public class DailyUpdate
    {
        public int DailyUpdateId { get; set; }
        
        public string Description { get; set; }
        
        public DateTime DateOfPosted { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
