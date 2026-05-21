using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace amzns3.host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        [HttpGet("ListAll")]
        public async Task<IActionResult> List([FromServices] IBucketServce bucketServce)
        {
            return Ok(await bucketServce.ListAllBuckets());
        }
    }
}
