namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PostData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var db = new BlogDbContext();

            //ListUsers(db);

            //ListPosts(db);

            //AddPost(db);

            //CascadingInsert(db);

            //Update(db);

            //Delete(db);

            //ExecuteNativeSQL(db);
        }

        private static void ExecuteNativeSQL(BlogDbContext db)
        {
            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);

            var posts = db.Database.SqlQuery<PostData>(
                @"SELECT ID, Title, Date FROM Posts WHERE CONVERT(date, Date) BETWEEN {0} AND {1} ORDER BY Date",
                startDate,
                endDate);

            foreach (var post in posts)
            {
                Console.WriteLine($"#{post.ID}: {post.Title} ({post.Date})");
            }
        }

        private static void Delete(BlogDbContext db)
        {
            var lastPost = db.Posts.OrderByDescending(p => p.ID).First();
            db.Comments.RemoveRange(lastPost.Comments);
            lastPost.Tags.Clear();

            db.Posts.Remove(lastPost);
            db.SaveChanges();

            Console.WriteLine($"Post #{lastPost.ID} removed.");
        }

        private static void Update(BlogDbContext db)
        {
            var user = db.Users.Where(u => u.Username.Equals("Mariika")).First();

            user.PasswordHash = Guid.NewGuid().ToByteArray();

            Console.WriteLine($"User #{user.ID} ({user.Username}) has a new random password.");
        }

        private static void CascadingInsert(BlogDbContext db)
        {
            var post = new Post()
            {
                Title = "New Title 2",
                Body = "New Body.",
                User = db.Users.First(),
                Comments = new Comment[]
                            {
                    new Comment()
                    {
                        Text = "First comment.", Date = DateTime.Now
                    },
                    new Comment()
                    {
                        Text = "Second comment.", Date = DateTime.Now, User = db.Users.First()
                    }
                            },
                Tags = db.Tags.Take(3).ToList(),
                Date = DateTime.Now
            };

            db.Posts.Add(post);
            db.SaveChanges();
        }

        private static void AddPost(BlogDbContext db)
        {
            var post = new Post()
            {
                Title = "New Title",
                Body = "New Body.",
                Date = DateTime.Now
            };

            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.ID} created successfully.");
        }

        private static void ListPosts(BlogDbContext db)
        {
            var posts = db.Posts.Select(p => new
            {
                p.ID,
                p.Title,
                Comments = p.Comments.Count(),
                Tags = p.Tags.Count()
            });

            Console.WriteLine($"SQL query:\n{posts}\n");

            foreach (var post in posts)
            {
                Console.WriteLine($"#{post.ID} {post.Title}: Comments - {post.Comments}, Tags: {post.Tags}");
            }
        }

        private static void ListUsers(BlogDbContext db)
        {
            foreach (User user in db.Users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
