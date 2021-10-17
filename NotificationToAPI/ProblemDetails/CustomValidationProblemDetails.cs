using System.Collections.Generic;

namespace NotificationToAPI.ProblemDetails
{
    public class CustomValidationProblemDetails
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string TraceId { get; set; }

        public IDictionary<string, List<ValidationProblemDetailsError>> Errors { get; set; }
    }
}
