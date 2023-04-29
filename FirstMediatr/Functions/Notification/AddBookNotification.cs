using MediatR;

namespace FirstMediatr.Functions.Notification
{
    public class AddBookNotification : INotification
    {
        public string Title { get; set; } = string.Empty;
    }
}
