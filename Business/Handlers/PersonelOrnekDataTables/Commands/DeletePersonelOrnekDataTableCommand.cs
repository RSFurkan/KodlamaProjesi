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

namespace Business.Handlers.PersonelOrnekDataTables.Commands
{
    public class DeletePersonelOrnekDataTableCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeletePersonelOrnekDataTableCommandHandler : IRequestHandler<DeletePersonelOrnekDataTableCommand, IResult>
        {
            private readonly IPersonelOrnekDataTableRepository _personelOrnekDataTableRepository;
            private readonly IMediator _mediator;
            public DeletePersonelOrnekDataTableCommandHandler(IPersonelOrnekDataTableRepository personelOrnekDataTableRepository, IMediator mediator)
            {
                _personelOrnekDataTableRepository = personelOrnekDataTableRepository;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(DeletePersonelOrnekDataTableCommand request, CancellationToken cancellationToken)
            {
                var personelOrnekDataTable = _personelOrnekDataTableRepository.Get(personelOrnekData => personelOrnekData.Id == request.Id);
                personelOrnekDataTable.IsDeleted = true;

                _personelOrnekDataTableRepository.Update(personelOrnekDataTable);
                await _personelOrnekDataTableRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
        }
}
