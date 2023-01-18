using System.Text.Json.Serialization;

namespace uhlig.game.domain.Notifications.StaticMessages
{
    public class Notification
    {
        public string Code { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public Notification(string code, string message, int statusCode)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }
        public Notification(string code, string message)
        {
            Code = code;
            Message = message;

            switch (Code.Substring(1, 2).ToUpper())
            {
                case "ER":
                    StatusCode = 400;
                    break;
                case "VA":
                    StatusCode = 400;
                    break;
                case "NA":
                    StatusCode = 403;
                    break;
                case "NO":
                    StatusCode = 200;
                    break;
                default:
                    StatusCode = 500;
                    break;
            };
        }
    }
}