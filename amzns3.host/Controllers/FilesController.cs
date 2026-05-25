using Amazon.S3.Model;
using amzns3.host.DTOs;
using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tube_catcher.module.Common;

namespace amzns3.host.Controllers
{
    [Route("[controller]")]
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

            return StatusCode((int)HttpStatusCode.OK,
                ApiResponse<GetObjectResponse>.SuccessResponse(result, "Recuperado com sucesso."));
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllFilesAsync([FromQuery] ListFilesRequest request)
        {
            var result = await _storageService.ListFileAsync(request);

            return StatusCode((int)HttpStatusCode.OK,
                ApiResponse<ListObjectsV2Response>.SuccessResponse(result, "Lista recuperada com sucesso."));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, string bucketName, string? prefix)
        {
            var result = await _storageService.UploadFileAsync(file, bucketName, prefix);

            return StatusCode((int)HttpStatusCode.OK, 
                ApiResponse<PutObjectResponse>.SuccessResponse(result, "Upload realizado com sucesso."));
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
