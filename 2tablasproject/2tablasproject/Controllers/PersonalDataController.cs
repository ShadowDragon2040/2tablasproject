using Microsoft.AspNetCore.Mvc;

namespace _2tablasproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
