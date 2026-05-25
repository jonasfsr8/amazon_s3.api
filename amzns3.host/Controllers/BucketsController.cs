using Amazon.S3.Model;
using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tube_catcher.module.Common;

namespace amzns3.host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        [HttpGet("list")]
        public async Task<IActionResult> ListBuckets([FromServices] IStorageService bucketServce)
        {
            var result = await bucketServce.ListBucketsAsync();

            return StatusCode((int)HttpStatusCode.OK,
                ApiResponse<List<S3Bucket>>.SuccessResponse(result, "Lista recuperada com sucesso."));
        }
    }
}
