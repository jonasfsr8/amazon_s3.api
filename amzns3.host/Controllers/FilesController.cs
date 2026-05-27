using amzns3.host.DTOs.Requests;
using amzns3.host.DTOs.Response;
using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tube_catcher.module.Common;

namespace amzns3.host.Controllers
{
    [Route("files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public FilesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("preview/{bucketName}/{key}")]
        public async Task<IActionResult> GetFileByKey(string bucketName, string key)
        {
            var result = await _storageService.GetFileByKeyAsync(bucketName, key);

            return File(result.ResponseStream, result.Headers.ContentType, result.Key);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllFilesAsync([FromQuery] FileRequestDto request)
        {
            var result = await _storageService.ListFileAsync(request);

            return StatusCode((int)HttpStatusCode.OK,
                ApiResponse<List<S3ObjectsResponseDto>>.SuccessResponse(result, "Lista recuperada com sucesso."));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, string bucketName, string? prefix)
        {
            var result = await _storageService.UploadFileAsync(file, bucketName, prefix);

            return StatusCode((int)HttpStatusCode.OK, 
                ApiResponse<object>.SuccessResponse(null, "Upload realizado com sucesso."));
        }

        [HttpDelete("delete/{bucketName}/{key}")]
        public async Task<IActionResult> DeleteFile(string bucketName, string key)
        {
            await _storageService.DeleteFileAsync(bucketName, key);

            return StatusCode((int)HttpStatusCode.OK, 
                ApiResponse<object>.SuccessResponse(null, "Arquivo deletado com sucesso."));
        }
    }
}
