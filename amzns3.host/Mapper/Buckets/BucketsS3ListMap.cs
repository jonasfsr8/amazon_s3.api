using Amazon.S3.Model;
using amzns3.host.DTOs.Response;
using AutoMapper;

namespace amzns3.host.Mapper.Buckets
{
    public class BucketsS3ListMap : Profile
    {
        public BucketsS3ListMap() 
        {
            CreateMap<S3Bucket, BucketsS3ListResponseDto>();
        }
    }
}
