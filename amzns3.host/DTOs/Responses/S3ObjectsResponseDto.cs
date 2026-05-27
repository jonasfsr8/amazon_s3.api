namespace amzns3.host.DTOs.Response
{
    public class S3ObjectsResponseDto
    {
        public string BucketName { get; set; }
        public string Key { get; set; }
        public string LastModified { get; set; }
        public string Size { get; set; }
    }
}
