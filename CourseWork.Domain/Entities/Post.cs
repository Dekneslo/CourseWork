using Domain.Models;

namespace CourseWork.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; } // Добавляем UserId в Post

        public virtual User User { get; set; } // Навигационное свойство для User

        public virtual ICollection<Comment> Comments { get; set; } // Коллекция комментариев
    }

    public enum PostType
    {
        Post = 0,
        DailyUpdate = 1
    }
}
