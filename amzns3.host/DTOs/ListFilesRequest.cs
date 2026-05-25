namespace amzns3.host.DTOs
{
    public class ListFilesRequest
    {
        public string BucketName { get; set; }
        public string? Prefix { get; set; }
    }
}
