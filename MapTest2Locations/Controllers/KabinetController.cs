using MapTest2Locations.Data;
using MapTest2Locations.Models;
using Microsoft.AspNetCore.Mvc;

namespace MapTest2Locations.Controllers;

public class KabinetController : Controller
{
    private readonly IKabinetRepository _repository;

    public KabinetController(IKabinetRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        var kabinets = _repository.GetKittyKabinets();
        return View(kabinets);
    }

    public IActionResult ViewKabinet(int id)
    {
        var kabinet = _repository.GetKabinet(id);
        return View(kabinet);
    }

    public IActionResult UpdateKabinet(int id)
    {
        Kabinet kabinet = _repository.GetKabinet(id);
        {
            if (kabinet == null)
            {
                return View("Kabinet Not Found");
            }

            return View(kabinet);
        }
    }

    public IActionResult UpdateKabinetToDatabase(Kabinet kabinet)
    {
        _repository.UpdateKabinet(kabinet);
        return RedirectToAction("ViewKabinet", new { id = kabinet.KabinetNumber});
    }
}
