namespace uhlig.game.domain.Notifications.StaticMessages
{
    public class NotificationsOptions
    {
        private IEnumerable<Notification> Notifications { get; set; }

        public NotificationsOptions(string language = "pt-br")
        {
            if (language == "pt-br")
                Notifications = PT_BR();

            Notifications = PT_BR();
        }
        private IEnumerable<Notification> PT_BR()
        {
            var notifications = new List<Notification>();
            notifications.Append(new Notification("ER001", "Acesso não autorizado!", 403));
            notifications.Append(new Notification("ER002", "Sala não encontrada!", 400));

            return notifications;
        }
        public Notification GetNotificationByCode(string code)
        {
            var notification = Notifications.Where(x => x.Code == code)?.FirstOrDefault();
            if (notification == null)
                throw new KeyNotFoundException();

            return notification;
        }
    }
}