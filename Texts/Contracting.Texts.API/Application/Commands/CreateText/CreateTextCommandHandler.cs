using System;
using System.Threading;
using System.Threading.Tasks;
using Texts.API.Domain.Entities;
using MediatR;

namespace Texts.API.Application.Commands.CreateText
{
    public class CreateTextCommandHandler : IRequestHandler<CreateTextCommand, Guid>
    {
        private readonly ContractingTextsContext _context;
        private readonly IMediator _mediator;

        public CreateTextCommandHandler(ContractingTextsContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateTextCommand request, CancellationToken cancellationToken)
        {
            var entity = new Text
            {
                TextId = Guid.NewGuid(),
                Language = request.Language,
                Branch = request.Branch,
                Area = request.Area,
                Key = request.Key,
                Value = request.Value,
            };

            _context.Text.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new TextCreated { TextId = entity.TextId}, cancellationToken);

            return entity.TextId;
        }
    }
}
