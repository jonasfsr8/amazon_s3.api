using System.Text.Json.Serialization;

namespace amzns3.host.DTOs.Requests
{
    public class FileRequestDto
    {
        public string BucketName { get; set; }
        public string? Prefix { get; set; }
    }
}
