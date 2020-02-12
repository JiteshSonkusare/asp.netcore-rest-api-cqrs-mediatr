using Texts.API.Application.Exceptions;
using Texts.API.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Texts.API.Application.Commands.DeleteText
{
    public class DeleteTextCommandHandler : IRequestHandler<DeleteTextCommand>
    {
        private readonly ContractingTextsContext _context;

        public DeleteTextCommandHandler(ContractingTextsContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTextCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Text.FindAsync(request.TextId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Text), request.TextId);
            }

            _context.Text.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
