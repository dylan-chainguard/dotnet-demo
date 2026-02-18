using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class BlogController : Controller
{
    private readonly BlogPostService _blogService;

    public BlogController(BlogPostService blogService)
    {
        _blogService = blogService;
    }

    public IActionResult Index()
    {
        var posts = _blogService.GetAllPosts();
        return View(posts);
    }

    [HttpPost]
    public IActionResult Create(string title, string content)
    {
        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
        {
            _blogService.CreatePost(title, content);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Update(int id, string title, string content)
    {
        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
        {
            _blogService.UpdatePost(id, title, content);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _blogService.DeletePost(id);
        return RedirectToAction(nameof(Index));
    }
}
