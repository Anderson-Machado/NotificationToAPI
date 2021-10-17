using System.Text.Json.Serialization;

namespace NotificationToAPI.ProblemDetails
{
    public class ValidationProblemDetailsError
    {
        public ValidationProblemDetailsError(string errorCode, string description)
            => (ErrorCode, Description) = (errorCode, description);

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
