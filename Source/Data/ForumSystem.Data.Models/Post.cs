namespace ForumSystem.Data.Models
{
    using ForumSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Post : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
