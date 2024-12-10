using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
