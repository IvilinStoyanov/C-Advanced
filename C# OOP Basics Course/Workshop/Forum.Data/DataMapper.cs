using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Forum.Data
{
    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "congif.ini";

        private const string DEFAULT_CONFIG =
            "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }


        private static readonly Dictionary<string, string> config;

        private static void EnsureCongifFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);

            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureCongifFile(configPath);
            var lines = ReadLines(configPath);

            var result = lines.Select(l => l.Split('=')).ToDictionary(l => l[0], l => DATA_PATH + l[1]);

            return result;
        }


        public static List<Category> LoadCategory()
        {
            var lines = ReadLines(config["categories"]);

            List<Category> categories = new List<Category>();
            foreach (var line in lines)
            {
                var splitLine = line.Split(";");
                var postIds = splitLine[2]
                    .Split(',')
                    .Select(int.Parse)
                    .ToList();

                var category = new Category(int.Parse(splitLine[0]), splitLine[1], postIds);
                categories.Add(category);
            }
            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            const string categoryFormat = "{0};{1};{2}";
            List<string> lines = new List<string>();

            foreach (var category in categories)
            {
                var line =
                    string.Format
                    (categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(',', category.PostsIds));

                lines.Add(line);
            }
            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            var lines = ReadLines(config["users"]);

            List<User> users = new List<User>();
            foreach (var line in lines)
            {
                var splitLine = line.Split(";");
                var postIds = splitLine[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var category = new User(int.Parse(splitLine[0]), splitLine[1], splitLine[2], postIds);
                users.Add(category);
            }
            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            const string userFormat = "{0};{1};{2};{3}";
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                var line =
                    string.Format
                    (userFormat,
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(',', user.PostsIds));

                lines.Add(line);
            }
            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            var lines = ReadLines(config["posts"]);

            List<Post> posts = new List<Post>();
            foreach (var line in lines)
            {
                var splitLine = line.Split(";");
                var replyIds = splitLine[5]
                    .Split(',',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var post = new Post(int.Parse(splitLine[0]),
                    splitLine[1],
                    splitLine[2],
                    int.Parse(splitLine[3]),
                     int.Parse(splitLine[4]),
                    replyIds);
                posts.Add(post);
            }
            return posts;
        }

        public static void SavePost(List<Post> posts)
        {
            const string postFormat = "{0};{1};{2};{3};{4};{5}";
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                var line =
                    string.Format
                    (postFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(',', post.ReplyId));

                lines.Add(line);
            }
            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReply()
        {
            var lines = ReadLines(config["replies"]);

            List<Reply> replies = new List<Reply>();
            foreach (var line in lines)
            {
                var splitLine = line.Split(";");

                var reply = new Reply(int.Parse(splitLine[0]),
                    splitLine[1],
                     int.Parse(splitLine[2]),
                     int.Parse(splitLine[3]));

                replies.Add(reply);
            }
            return replies;
        }

        public static void SaveReply(List<Reply> replies)
        {
            const string replyFormat = "{0};{1};{2};{3}";
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                var line =
                    string.Format
                    (replyFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId);

                lines.Add(line);
            }
            WriteLines(config["replies"], lines.ToArray());
        }

    }
}
