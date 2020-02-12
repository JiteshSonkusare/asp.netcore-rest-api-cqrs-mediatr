using System;
using System.Threading;
using System.Threading.Tasks;
using Texts.API.Application.Infrastructure.Notification;
using MediatR;
using Texts.API.Application.Infrastructure.Notification.Models;

namespace Texts.API.Application.Commands.CreateText
{
    public class TextCreated : INotification
    {
        public Guid TextId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<TextCreated> 
        {
            private readonly INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(TextCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
