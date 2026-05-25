using Amazon.S3.Model;
using amzns3.host.DTOs;

namespace amzns3.host.Interfaces
{
    public interface IStorageService
    {
        Task<GetObjectResponse> GetFileByKeyAsync(string bucketName, string key);
        Task<ListObjectsV2Response> ListFileAsync(ListFilesRequest request);
        Task<List<S3Bucket>> ListBucketsAsync();
        Task<PutObjectResponse> UploadFileAsync(IFormFile file, string bucketName, string? prefix);
        Task DeleteFileAsync(string bucketName, string key);
        
    }
}
