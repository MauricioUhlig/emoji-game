using uhlig.game.domain.Notifications.StaticMessages;

namespace uhlig.game.domain.Notifications
{
    public class DomainNotification
    {
        private readonly NotificationsOptions _notificationsOptions;
        private IEnumerable<Notification> _notifications;
        public DomainNotification(NotificationsOptions notificationsOptions)
        {
            _notificationsOptions = notificationsOptions;
            _notifications = new List<Notification>();
        }
        public void AddNotification(string code)
        {
            var notification = _notifications.Where(x => x.Code == code)?.FirstOrDefault();
            if (notification == null)
                _notifications.Append(_notificationsOptions.GetNotificationByCode(code));
        }
        public bool IsValid()
        {
            var notification = _notifications.Where(x => x.StatusCode >= 400)?.FirstOrDefault();
            if (notification == null)
                return true;

            return false;
        }
        public IEnumerable<Notification> GetNotifications() => _notifications;
        public int GetStatusCode() => _notifications.OrderByDescending(x => x.StatusCode)?.FirstOrDefault()?.StatusCode ?? 200;

    }
}