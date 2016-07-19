namespace Entity_Framework
{
    using System;

    class Program
    {
        static void Main()
        {
            var db = new BlogDbContext();

            var posts = db.Posts;

            var p = new Post()
            {
                Title = "New Posts From C#!",
                Body = "Adding new post from C# application",
                Date = DateTime.Now
            };

            db.Posts.Add(p);
            db.SaveChanges();

            foreach (var post in posts)
            {
                Console.WriteLine($"#{post.ID} | {post.Title}\n{post.Body}\n");
            }
        }
    }
}
