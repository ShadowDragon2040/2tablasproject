using Microsoft.AspNetCore.Mvc;

namespace _2tablasproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
