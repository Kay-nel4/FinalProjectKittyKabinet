using MapTest2Locations.MessageBoardData;
using MapTest2Locations.Models;
using Microsoft.AspNetCore.Mvc;

namespace MapTest2Locations.Controllers;

public class MessageBoardController : Controller
{
    private readonly IMessageBoardRepository _repository;

    public MessageBoardController(IMessageBoardRepository repository)
    {
        _repository = repository;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var messages = await _repository.GetAllPostsAsync();
        return View(messages);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MessageBoard postData)
    {

        if (!ModelState.IsValid)
            return View(postData);
        
        postData.TimeCreated = DateTime.Now;
  
        await _repository.AddPostAsync(postData);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeletePostAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var post = await _repository.GetPostByIdAsync(id);

        if (post == null)
            return NotFound();
        return View(post);
    }
    
}