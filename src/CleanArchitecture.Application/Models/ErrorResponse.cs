namespace CleanArchitecture.Application.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string MessageCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
