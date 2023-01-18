using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.Notifications.StaticMessages;
using Microsoft.AspNetCore.Authorization;

namespace uhlig.game.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotification _domainNotification;
        public ApiController(DomainNotification domainNotification)
        {
            _domainNotification = domainNotification;
        }

        protected IActionResult Result()
        {
            return Result((object?)null);
        }
        protected IActionResult Result<TData>(TData? data)
            where TData : class
        {
            JsonResult result;
            if (_domainNotification.IsValid())
                result = new JsonResult(new ResultJson(data));
            else
                result = new JsonResult(new ResultJson(data, _domainNotification.GetNotifications()));
            result.StatusCode = _domainNotification.GetStatusCode();
            return result;
        }
    }

    public class ResultJson
    {
        public object? Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Notification>? Errors { get; set; }

        public ResultJson(object? data, IEnumerable<Notification> errors)
        {
            this.Data = data;
            this.Errors = errors;
        }
        public ResultJson(object? data)
        {
            this.Data = data;
        }
    }

}
