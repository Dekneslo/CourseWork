using System;
using System.Collections.Generic;

namespace CourseWork.Domain.Entities
{
    public class UserLanguage
    {
        public int UserId { get; set; }
        public string Language { get; set; }

        public User User { get; set; }
    }
}
