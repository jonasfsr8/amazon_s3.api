using Amazon.S3.Model;
using amzns3.host.DTOs.Requests;
using amzns3.host.DTOs.Response;

namespace amzns3.host.Interfaces
{
    public interface IStorageService
    {
        Task<GetObjectResponse> GetFileByKeyAsync(string bucketName, string key);
        Task<List<S3ObjectsResponseDto>> ListFileAsync(FileRequestDto request);
        Task<List<BucketsS3ListResponseDto>> ListBucketsAsync();
        Task<PutObjectResponse> UploadFileAsync(IFormFile file, string bucketName, string prefix);
        Task DeleteFileAsync(string bucketName, string key);
    }
}
