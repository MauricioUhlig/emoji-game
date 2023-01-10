using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using uhlig.game.domain.Notifications;

namespace uhlig.game.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotification _domainNotification;
        public ApiController(DomainNotification domainNotification)
        {
            _domainNotification = domainNotification;
        }

        protected IActionResult Result()
        {
            if (_domainNotification.IsValid())
                return Result("OK");
            return Result("Error");
        }
        protected IActionResult Result<TData>(TData data)
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
        public object Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Dictionary<string, string>? Errors { get; set; }

        public ResultJson(object data, Dictionary<string, string> errors)
        {
            this.Data = data;
            this.Errors = errors;
        }
        public ResultJson(object data)
        {
            this.Data = data;
        }
    }

}
