using MediatR;
using System;

namespace Texts.API.Application.Commands.UpdateText
{
    public class UpdateTextCommand : IRequest
    {
        public Guid TextId { get; set; }

        public string Language { get; set; }

        public string Branch { get; set; }

        public string Area { get; set; }

        public string Key { get; set; } 

        public string Value { get; set; }
    }
}
