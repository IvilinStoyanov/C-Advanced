using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data
{
    public class ForumData
    {
        public List<User> Users { get; set; }

        public List<Category> Categories { get; set; }

        public List<Reply> Replies { get; set; }

        public List<Post> Posts { get; set; }

        public ForumData()
        {
            Users = DataMapper.LoadUsers();
            Categories = DataMapper.LoadCategory();
            Replies = DataMapper.LoadReply();
            Posts = DataMapper.LoadPosts();
        }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(Users);
            DataMapper.SaveCategories(Categories);
            DataMapper.SavePost(Posts);
            DataMapper.SaveReply(Replies);
        }
    }
}
