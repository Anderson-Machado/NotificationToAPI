using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace NotificationToAPI.Notification
{
    public interface IApiNotification
    {
        object GetProblemDetail(IHttpContextAccessor httpContext);
        ValidationResult AddProblemDetail(ValidationResult validationFailure);
        bool HasNotifications();
    }
}
