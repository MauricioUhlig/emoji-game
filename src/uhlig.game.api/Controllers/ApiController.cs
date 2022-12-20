using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace uhlig.game.api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

        public ApiController()
        {
        }


        protected IActionResult Result<TData>(TData data)
            where TData : class
        {
            //  if (this.IsValidOperation)
            {
                return ResultOk(data);
            }

            //return ResultErro(data, this.domainNotification.GetNotifications().Select(s => s.Value));
        }

        protected IActionResult Result()
        {
            // if (this.IsValidOperation)
            {
                return Ok();
            }

            // return ResultErro(this.domainNotification.GetNotifications().Select(s => s.Value));
        }


        protected static IActionResult ResultOk<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return new JsonResult(new ResultJson(true, data, messages));
        }

        protected static IActionResult ResultOk<TData>(TData data)
            where TData : class
        {
            return new JsonResult(new ResultJson(true, data));
        }

        private IActionResult ResultErro(IEnumerable<string> messages)
        {
            return ResultErro("Erro!", messages);
        }

        private IActionResult ResultErro<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return Result((int)HttpStatusCode.BadRequest,data, messages);
        }
        private IActionResult Result<TData>(int statusCode, TData data, IEnumerable<string> messages)
            where TData : class
        {
            var result = new JsonResult(new ResultJson(false, data, messages.Distinct()));
            result.StatusCode = statusCode;
            return result;
            
        }

        #region private
        #endregion

        #region protected

        /*   protected IEnumerable<DomainNotification> Notifications => this.domainNotification.GetNotifications();

                protected bool IsValidOperation => !this.domainNotification.HasNotification();

                protected void NotifyError(string code, string message)
                {
                    this.mediator.RaiseEventAsync(new DomainNotification(code, message));
                }*/

        #endregion
    }

    public class ResultJson
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public ResultJson(bool success, object data, IEnumerable<string> errors)
        {
            this.Success = success;
            this.Data = data;
            this.Errors = errors;
        }
        public ResultJson(bool success, object data)
        {
            this.Success = success;
            this.Data = data;
        }
    }

}
