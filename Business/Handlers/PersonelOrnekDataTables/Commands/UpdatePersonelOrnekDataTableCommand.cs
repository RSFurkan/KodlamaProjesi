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
    public class UpdatePersonelOrnekDataTableCommand : IRequest<IResult>
    {

        public int Id { get; set; }
        public int PersonelId { get; set; } 
        public DateTime IseGirisTarihi { get; set; }
        public DateTime IstenCikisTarihi { get; set; }

        public class UpdatePersonelOrnekDataTableCommandHandler : IRequestHandler<UpdatePersonelOrnekDataTableCommand, IResult>
        {

            private readonly IPersonelOrnekDataTableRepository _personelOrnekDataTableRepository;
            private readonly IMediator _mediator;
            public UpdatePersonelOrnekDataTableCommandHandler(IPersonelOrnekDataTableRepository personelOrnekDataTableRepository, IMediator mediator)
            {
                _personelOrnekDataTableRepository = personelOrnekDataTableRepository;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(UpdatePersonelOrnekDataTableCommand request, CancellationToken cancellationToken)
            {
                var isThereRecord = await _personelOrnekDataTableRepository.GetAsync(personelDepartment => personelDepartment.Id == request.Id);
                isThereRecord.IseGirisTarihi = request.IseGirisTarihi;
                isThereRecord.IstenCikisTarihi = request.IstenCikisTarihi;
                isThereRecord.PersonelId = request.PersonelId;

                _personelOrnekDataTableRepository.Update(isThereRecord);
                await _personelOrnekDataTableRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
        }
}
