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
    public class CreatePersonelOrnekDataTableCommand : IRequest<IResult>
    {
        public int PersonelId { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public DateTime IstenCikisTarihi { get; set; }

        public class CreatePersonelOrnekDataTableCommandHandler : IRequestHandler<CreatePersonelOrnekDataTableCommand, IResult>
        {
            private readonly IPersonelOrnekDataTableRepository _personelOrnekDataTableRepository;
            private readonly IMediator _mediator;
            public CreatePersonelOrnekDataTableCommandHandler(IPersonelOrnekDataTableRepository personelOrnekDataTableRepository, IMediator mediator)
            {
                _personelOrnekDataTableRepository = personelOrnekDataTableRepository;
                _mediator = mediator;
            }
          //  [ValidationAspect(typeof(CreatePersonelOrnekDataValidator))]

            public async Task<IResult> Handle(CreatePersonelOrnekDataTableCommand request, CancellationToken cancellationToken)
            {
                //bir kişi birden fazla kez işe girip cıkabilir ancak cıkıs tarihi bos ise tekrar kayıt eklenemez
                var isThereRecord=_personelOrnekDataTableRepository.Query().Any(personel=>personel.IstenCikisTarihi==null && personel.PersonelId==request.PersonelId);
                if (isThereRecord == true)
                    return new ErrorResult(Messages.AlreadyExist);

                var addedPersonelOrnekDataTable = new PersonelOrnekDataTable()
                {
                    IsDeleted = false,
                    IseGirisTarihi=request.IseGirisTarihi,
                    PersonelId=request.PersonelId,
                    IstenCikisTarihi=request.IstenCikisTarihi
                };
                _personelOrnekDataTableRepository.Add(addedPersonelOrnekDataTable);
                await _personelOrnekDataTableRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);


            }
        }
    }
}
