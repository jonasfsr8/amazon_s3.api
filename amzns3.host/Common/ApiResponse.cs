namespace tube_catcher.module.Common
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }

        public string message { get; set; }

        public T? response { get; set; }

        public IEnumerable<string>? errors { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "")
        {
            return new ApiResponse<T>
            {
                success = true,
                message = message,
                response = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, IEnumerable<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                success = false,
                message = message,
                errors = errors
            };
        }
    }
}
