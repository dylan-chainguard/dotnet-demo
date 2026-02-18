using BlogApp.Models;
using System.Collections.Concurrent;

public class BlogPostService
{
    private readonly ConcurrentDictionary<int, BlogPost> _posts = new();
    private int _nextId = 1;

    public BlogPostService()
    {
        // Add some sample posts
        CreatePost("Welcome to My Blog", "This is my first blog post. Welcome to my simple blogging platform!");
        CreatePost("ASP.NET Core is Amazing", "ASP.NET Core provides a great framework for building web applications with C#.");
    }

    public IEnumerable<BlogPost> GetAllPosts()
    {
        return _posts.Values.OrderByDescending(p => p.CreatedAt);
    }

    public BlogPost? GetPost(int id)
    {
        _posts.TryGetValue(id, out var post);
        return post;
    }

    public BlogPost CreatePost(string title, string content)
    {
        var post = new BlogPost
        {
            Id = _nextId++,
            Title = title,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _posts[post.Id] = post;
        return post;
    }

    public bool UpdatePost(int id, string title, string content)
    {
        if (_posts.TryGetValue(id, out var post))
        {
            post.Title = title;
            post.Content = content;
            post.UpdatedAt = DateTime.UtcNow;
            return true;
        }
        return false;
    }

    public bool DeletePost(int id)
    {
        return _posts.TryRemove(id, out _);
    }
}
