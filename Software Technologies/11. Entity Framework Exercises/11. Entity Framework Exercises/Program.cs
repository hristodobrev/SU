namespace _11.Entity_Framework_Exercises
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            // Uncomment each method one by one to see the result of it.

            var db = new BlogDbContext();

            //ListAllPosts(db);

            //ListAllUsers(db);

            //ListPostsTitleAndBodyFromPost(db);

            //ListOrderData(db);

            //ListOrderByTwoColumns(db);

            //SelectAuthors(db);

            //JoinAuthorsWithTitles(db);

            //SelectAuthorOfSpecificPost(db);

            //GetAllAuthorsOfPosts(db);

            //CreateData(db);

            //UpdateData(db);

            //DeleteCommentData(db);

            //DeletePostData(db);
        }

        private static void DeletePostData(BlogDbContext db)
        {
            var post = db.Posts.Single(p => p.Id == 31);

            db.Comments.RemoveRange(post.Comments);
            post.Tags.Clear();

            db.Posts.Remove(post);

            db.SaveChanges();

            Console.WriteLine($"Post #{post.Id} deleted.");
        }

        private static void DeleteCommentData(BlogDbContext db)
        {
            var comment = db.Comments.Single(c => c.Id == 1);

            db.Comments.Remove(comment);

            db.SaveChanges();

            Console.WriteLine($"Comment #{comment.Id} deleted.");
        }

        private static void UpdateData(BlogDbContext db)
        {
            var user = db.Users.Single(u => u.UserName == "GBotev");

            var oldName = user.FullName;

            user.FullName = "Georgi Botev";

            db.SaveChanges();

            Console.WriteLine($"User '{oldName}' has been renamed to '{user.FullName}'.");
        }

        private static void CreateData(BlogDbContext db)
        {
            var post = new Post()
            {
                AuthorId = 2,
                Title = "Random Title",
                Body = "Random Body",
                Date = DateTime.Now
            };

            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.Id} created!");
        }

        private static void GetAllAuthorsOfPosts(BlogDbContext db)
        {
            var users = db.Users.Select(u => new {u.UserName, u.FullName, u.Posts, u.Id})
                .Where(u => u.Posts.Count > 0)
                .OrderByDescending(u => u.Id);

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Full Name: {user.FullName}");
            }
        }

        private static void SelectAuthorOfSpecificPost(BlogDbContext db)
        {
            var user = db.Users
                .SelectMany(u => u.Posts, (u, p) => new {u.UserName, u.FullName, p.Id})
                .Single(p => p.Id == 4);

            Console.WriteLine($"Username: {user.UserName}");
            Console.WriteLine($"Full Name: {user.FullName}");
        }

        private static void JoinAuthorsWithTitles(BlogDbContext db)
        {
            var users = db.Users.SelectMany(u => u.Posts, (u, p) => new { u.UserName, p.Title });

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Post Title: {user.Title}");
                Console.WriteLine();
            }
        }

        private static void SelectAuthors(BlogDbContext db)
        {
            var users = db.Users.Select(u => new { u.UserName, u.FullName, u.Posts })
                .Where(u => u.Posts.Count > 0).ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine($"Posts Count: {user.Posts.Count}");
                Console.WriteLine();
            }
        }

        private static void ListOrderByTwoColumns(BlogDbContext db)
        {
            var users = db.Users.Select(u => new { u.UserName, u.FullName })
                .OrderByDescending(u => u.UserName)
                .ThenByDescending(u => u.FullName)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void ListOrderData(BlogDbContext db)
        {
            var users = db.Users.Select(u => new { u.UserName, u.FullName })
                .OrderBy(u => u.UserName)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void ListPostsTitleAndBodyFromPost(BlogDbContext db, bool listFull = false)
        {
            var posts = db.Posts.Select(p => new { p.Title, p.Body }).ToList();

            foreach (var post in posts)
            {
                var postContent = listFull ? post.Body : post.Body.Substring(0, 200) + "...";
                Console.WriteLine($"Title: {post.Title.Trim()}");
                Console.WriteLine($"Content: {postContent}");
                Console.WriteLine();
            }
        }

        private static void ListAllUsers(BlogDbContext db)
        {
            var users = db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.FullName}");
                Console.WriteLine($"Comments Count: {user.Comments.Count}");
                Console.WriteLine($"Posts Count: {user.Posts.Count}");
                Console.WriteLine();
            }
        }

        private static void ListAllPosts(BlogDbContext db)
        {
            var posts = db.Posts.ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"Title: {post.Title.Trim()}");
                Console.WriteLine($"AuthorId: {post.AuthorId}");
                Console.WriteLine($"Comments Count: {post.Comments.Count}");
                Console.WriteLine($"Tags Count: {post.Tags.Count}");
                Console.WriteLine();
            }
        }
    }
}
