using System;
using MediatR;

namespace Texts.API.Application.Commands.CreateText
{
    public class CreateTextCommand : IRequest<Guid>
    {
        public string Language { get; set; }

        public string Branch { get; set; }

        public string Area { get; set; }
        
        public string Key { get; set; } 
        
        public string Value { get; set; }
    }
}
