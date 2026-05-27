using Amazon.S3;
using Amazon.S3.Model;
using amzns3.host.DTOs.Requests;
using amzns3.host.DTOs.Response;
using amzns3.host.Exceptions;
using amzns3.host.Interfaces;
using AutoMapper;

namespace amzns3.host.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IMapper _mapper;

        public StorageService(IAmazonS3 amazonS3, IMapper mapper)
        {
            _s3Client = amazonS3;
            _mapper = mapper;
        }

        public async Task<List<BucketsS3ListResponseDto>> ListBucketsAsync()
        {
            ListBucketsResponse response = await _s3Client.ListBucketsAsync();

            return _mapper.Map<List<BucketsS3ListResponseDto>>(response.Buckets);
        }

        public async Task<GetObjectResponse> GetFileByKeyAsync(string bucketName, string key)
        {
            await BucketExists(_s3Client, bucketName);

            return await _s3Client.GetObjectAsync(bucketName, key);
        }

        public async Task<List<S3ObjectsResponseDto>> ListFileAsync(FileRequestDto request)
        {
            await BucketExists(_s3Client, request.BucketName);

            var objv2 = _mapper.Map<ListObjectsV2Request>(request);

            var response = await _s3Client.ListObjectsV2Async(objv2);

            return _mapper.Map<List<S3ObjectsResponseDto>>(response.S3Objects);
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

        private async Task BucketExists(IAmazonS3 s3Client, string bucketName)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);

            if(!bucketExists)
                throw new NotFoundException("Bucket não encontrado.");
        }        
    }
}
