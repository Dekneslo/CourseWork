using System;
using System.Collections.Generic;

namespace CourseWork.Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        
        public int UserId { get; set; }
        
        public string? City { get; set; }
        
        public string? Country { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string? Biography { get; set; }

        public User User { get; set; }
    }
}
