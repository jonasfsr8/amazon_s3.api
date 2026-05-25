using Amazon.S3;
using Amazon.S3.Model;
using amzns3.host.DTOs;
using amzns3.host.Exceptions;
using amzns3.host.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace amzns3.host.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;

        public StorageService(IAmazonS3 amazonS3)
        {
            _s3Client = amazonS3;
        }

        #region buckets
        public async Task<List<S3Bucket>> ListBucketsAsync()
        {
            ListBucketsResponse response = await _s3Client.ListBucketsAsync();
            return response.Buckets;
        }
        #endregion

        #region files
        public async Task<GetObjectResponse> GetFileByKeyAsync(string bucketName, string key)
        {
            await BucketExists(_s3Client, bucketName);

            return await _s3Client.GetObjectAsync(bucketName, key);
        }

        public async Task<ListObjectsV2Response> ListFileAsync(ListFilesRequest request)
        {
            await BucketExists(_s3Client, request.BucketName);

            var obj = new ListObjectsV2Request()
            {
                BucketName = request.BucketName,
                Prefix = request.Prefix
            };

            return await _s3Client.ListObjectsV2Async(obj);
        }

        public async Task<PutObjectResponse> UploadFileAsync(IFormFile file, string bucketName, string? prefix)
        {
            await BucketExists(_s3Client, bucketName);

            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix.TrimEnd('/')}/{file.FileName}",
                InputStream = file.OpenReadStream()
            };

            request.Metadata.Add("Content-Type", file.ContentType);
            return await _s3Client.PutObjectAsync(request);
        }

        public async Task DeleteFileAsync(string bucketName, string key)
        {
            await BucketExists(_s3Client, bucketName);

            await _s3Client.DeleteObjectAsync(bucketName, key);
        }
        #endregion 

        private async Task BucketExists(IAmazonS3 s3Client, string bucketName)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);

            if(!bucketExists)
                throw new NotFoundException("Bucket não encontrado.");
        }

        
    }
}
