using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationToAPI.Notification
{
    public interface IApiNotification
    {
        IActionResult GetProblemDetail(IHttpContextAccessor httpContext);
        ValidationResult AddProblemDetail(ValidationResult validationFailure);
        bool HasNotifications();
    }
}
