namespace uhlig.game.domain.Notifications.StaticMessages
{
    public class NotificationsOptions
    {
        private IEnumerable<Notification> Notifications { get; set; }

        public NotificationsOptions(string language = "pt-br")
        {
            switch (language)
            {
                case "pt-br":
                    Notifications = PT_BR();
                    break;
                default:
                    Notifications = PT_BR();
                    break;
            }
        }
        private IEnumerable<Notification> PT_BR()
        {
            var notifications = new List<Notification>();
            notifications.Add(new Notification("VL001", "Não existem rodadas para a sala informada!", 400));
            notifications.Add(new Notification("VL002", "Não existe rodada para sua sala!", 400));

            notifications.Add(new Notification("ER000", "Erro!", 400));
            notifications.Add(new Notification("ER001", "Acesso não autorizado!", 403));
            notifications.Add(new Notification("ER002", "Sala não encontrada!", 400));
            notifications.Add(new Notification("ER003", "Nenhuma sala publica encontrada!", 400));
            notifications.Add(new Notification("ER004", "Rodada não encontrada!", 400));
            notifications.Add(new Notification("ER005", "Player não encontrado!", 400));
            notifications.Add(new Notification("ER006", "Não existem player nesta rodada!", 400));
            notifications.Add(new Notification("ER007", "Nenhuma frase encontrada na rodada!", 400));


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