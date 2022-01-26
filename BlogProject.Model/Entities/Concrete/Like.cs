using BlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Model.Entities.Concrete
{
    public class Like : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
