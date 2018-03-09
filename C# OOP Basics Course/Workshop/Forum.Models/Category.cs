using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Category
    {

        public Category(int id, string name, IEnumerable<int> post)
        {
            this.Id = id;
            this.Name = name;
            this.PostsIds = new List<int>(post);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostsIds { get; set; }
    }
}
