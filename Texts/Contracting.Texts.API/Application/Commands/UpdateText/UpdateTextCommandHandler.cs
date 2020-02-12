using Texts.API.Application.Exceptions;
using Texts.API.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Texts.API.Application.Commands.UpdateText
{
    public class UpdateTextCommandHandler : IRequestHandler<UpdateTextCommand, Unit>
    {
        private readonly ContractingTextsContext _context;

        public UpdateTextCommandHandler(ContractingTextsContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTextCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Text.FindAsync(request.TextId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Text), request.TextId);
            }

            entity.TextId = request.TextId;
            entity.Language = request.Language;
            entity.Branch = request.Branch;
            entity.Area = request.Area;
            entity.Key = request.Key;
            entity.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
