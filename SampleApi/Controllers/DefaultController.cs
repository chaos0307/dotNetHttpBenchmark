using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [Route("SamplePost")]
        [HttpPost]
        public string SamplePost()
        { return "Post. "; }
        [Route("SampleGet")]
        [HttpGet]
        public string SampleGet()
        { return "Get. "; }

    }
}