using BlogProject.Model.Entities.Abstract;
using System.Collections.Generic;

namespace BlogProject.Model.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Article> Articles { get; set; }
    }
}
