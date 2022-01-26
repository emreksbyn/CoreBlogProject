using BlogProject.Model.Entities.Abstract;

namespace BlogProject.Model.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
