using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ogrencisistem.Models;
using ogrencisistem.RabbitMQ;

namespace ogrencisistem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRabbitMQProducer _rabbitMQ;
    public ogrenci og1=new ogrenci{id="h",ad="jhdshjhj"};
    public HomeController(ILogger<HomeController> logger,IRabbitMQProducer rabbitMQ)
    {
        _logger = logger;
        _rabbitMQ=rabbitMQ;
    }

    public IActionResult Index()
    {
        
        _rabbitMQ.SendMessage<ogrenci>(og1);
        _rabbitMQ.SendMessage<string>("merhaba ilk mesajjj");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
