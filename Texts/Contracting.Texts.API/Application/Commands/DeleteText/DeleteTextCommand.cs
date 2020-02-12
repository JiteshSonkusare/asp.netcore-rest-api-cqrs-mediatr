using MediatR;
using System;

namespace Texts.API.Application.Commands.DeleteText
{
    public class DeleteTextCommand : IRequest
    {
        public Guid TextId { get; set; }
    }
}
