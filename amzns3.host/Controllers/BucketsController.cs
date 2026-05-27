using amzns3.host.DTOs.Response;
using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tube_catcher.module.Common;

namespace amzns3.host.Controllers
{
    [Route("buckets")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        [HttpGet("list")]
        public async Task<IActionResult> ListBuckets([FromServices] IStorageService bucketServce)
        {
            var result = await bucketServce.ListBucketsAsync();

            return StatusCode((int)HttpStatusCode.OK,
                ApiResponse<List<BucketsS3ListResponseDto>>.SuccessResponse(result, "Lista recuperada com sucesso."));
        }
    }
}
