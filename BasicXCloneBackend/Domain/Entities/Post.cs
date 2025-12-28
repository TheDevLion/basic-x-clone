using System.ComponentModel.DataAnnotations.Schema;

namespace BasicXCloneBackend.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey("UserName")]
        public string Creator { get; set; }
        public DateTime CreationDate{ get; set; }
    }
}

