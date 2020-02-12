using System.Threading.Tasks;
using Texts.API.Application.Infrastructure.Notification.Models;

namespace Texts.API.Application.Infrastructure.Notification
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
