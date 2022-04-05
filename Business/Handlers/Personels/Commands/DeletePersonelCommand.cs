using Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.Threading.Tasks;
using System.Threading;
using DataAccess.Abstract;
using System.Linq;
using Business.Constants;

namespace Business.Handlers.Personels.Commands
{
    public class DeletePersonelCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public class DeletePersonelCommandHandler : IRequestHandler<DeletePersonelCommand, IResult>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMediator _mediator;
            public DeletePersonelCommandHandler(IPersonelRepository personelRepository, IMediator mediator)
            {
                _personelRepository = personelRepository;
                _mediator = mediator;

            }

            public async Task<IResult> Handle(DeletePersonelCommand request, CancellationToken cancellationToken)
            {
                var deletedData = _personelRepository.Get(personelOrnekData => personelOrnekData.Id == request.Id);
                deletedData.IsDeleted = true;

                _personelRepository.Update(deletedData);
                await _personelRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
        }
}
