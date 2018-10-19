using Microsoft.AspNetCore.Mvc;

namespace ReaxApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            return $"{name}, your app is running!";
        }

    }
}
