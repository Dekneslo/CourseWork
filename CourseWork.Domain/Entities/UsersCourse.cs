using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Entities
{
    public class UsersCourse
    {
        public int UserId { get; set; }
        
        public User User { get; set; }

        public int CourseId { get; set; }
        
        public Course Course { get; set; }  
    }
}
