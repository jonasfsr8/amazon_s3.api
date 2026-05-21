using Amazon.S3;
using Amazon.S3.Model;
using amzns3.host.Interfaces;

namespace amzns3.host.Services
{
    public class BucketService : IBucketServce
    {
        private readonly IAmazonS3 _s3Client;

        public BucketService(IAmazonS3 amazonS3)
        {
            _s3Client = amazonS3;
        }

        public async Task<List<S3Bucket>> ListAllBuckets()
        {
            ListBucketsResponse response = await _s3Client.ListBucketsAsync();
            return response.Buckets;
        }
    }
}
