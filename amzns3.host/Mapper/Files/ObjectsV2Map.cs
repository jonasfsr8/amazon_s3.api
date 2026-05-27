using Amazon.S3.Model;
using amzns3.host.DTOs.Requests;
using amzns3.host.DTOs.Response;
using AutoMapper;

namespace amzns3.host.Mapper.Files
{
    public class ObjectsV2Map : Profile
    {
        public ObjectsV2Map() 
        {
            CreateMap<FileRequestDto, ListObjectsV2Request>();
            CreateMap<S3Object, S3ObjectsResponseDto>();
        }
    }
}
