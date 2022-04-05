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
    public class UpdatePersonelCommand : IRequest<IResult>
    {
        public int Id { get; set; } 
        public string SicilNumarasi { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Cinsiyet { get; set; }
        public string CepTelefonu { get; set; }
        public string MailAdresi { get; set; }


        public class UpdatePersonelCommandHandler : IRequestHandler<UpdatePersonelCommand, IResult>
        {

            private readonly IPersonelRepository _personelRepository;
            private readonly IMediator _mediator;
            public UpdatePersonelCommandHandler(IPersonelRepository personelRepository, IMediator mediator)
            {
                _personelRepository = personelRepository;
                _mediator = mediator;

            }
            public async Task<IResult> Handle(UpdatePersonelCommand request, CancellationToken cancellationToken)
            {
                var isThereRecord = await _personelRepository.GetAsync(personelDepartment => personelDepartment.Id == request.Id);
                isThereRecord.Ad=request.Ad;
                isThereRecord.SoyAd=request.SoyAd;

                _personelRepository.Update(isThereRecord);
                await _personelRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
