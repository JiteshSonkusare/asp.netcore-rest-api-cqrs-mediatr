using System.Threading.Tasks;
using Texts.API.Application.Infrastructure.Notification.Models;

namespace Texts.API.Application.Infrastructure.Notification
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
