using Amazon.S3.Model;

namespace amzns3.host.Interfaces
{
    public interface IBucketServce
    {
        Task<List<S3Bucket>> ListAllBuckets();
    }
}
