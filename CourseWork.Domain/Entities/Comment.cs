using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWork.Domain.Entities;

namespace Domain.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("Post")] 
        public int PostId { get; set; }

        public int CourseId { get; set; }

        public string CommentDescription { get; set; }

        public DateTime DateCommented { get; set; } = DateTime.UtcNow;

        public Post Post { get; set; }

        public User User { get; set; }

        public Course Course { get; set; }

        public ICollection<CommentMedia> CommentMedia { get; set; }
    }
}
