using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace CourseWork.Domain.Entities
{
    public class CommentMedia
    {
        [Key]
        public int MediaId { get; set; }
        
        public int CommentId { get; set; }
        
        public string MediaType { get; set; }
        
        public string MediaPath { get; set; }

        public virtual Comment IdCommentNavigation { get; set; }
    }
}
