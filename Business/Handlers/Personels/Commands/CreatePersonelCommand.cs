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
    public class CreatePersonelCommand : IRequest<IResult>
    {
        public string SicilNumarasi { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Cinsiyet { get; set; }
        public string CepTelefonu { get; set; }
        public string MailAdresi { get; set; }

        public class CreatePersonelOrnekDataTableCommandHandler : IRequestHandler<CreatePersonelCommand, IResult>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMediator _mediator;
            public CreatePersonelOrnekDataTableCommandHandler(IPersonelRepository personelRepository, IMediator mediator)
            {
                _personelRepository=personelRepository;
                _mediator=mediator;

            }

            public async Task<IResult> Handle(CreatePersonelCommand request, CancellationToken cancellationToken)
            {
                /// sicil numarası tekrar edemez
                var isThereRecord = _personelRepository.Query().Any(personel => personel.SicilNumarasi == request.SicilNumarasi);
                if (isThereRecord == true)
                    return new ErrorResult(Messages.AlreadyExist);
                var addedPersonel = new Entities.Concrete.Personel()
                {
                    Ad = request.Ad,
                    CepTelefonu = request.CepTelefonu,
                    Cinsiyet = request.CepTelefonu,
                    IsDeleted=false,
                    MailAdresi = request.MailAdresi,
                    SicilNumarasi = request.SicilNumarasi,
                    SoyAd = request.SoyAd,
                };
                _personelRepository.Add(addedPersonel);
                await _personelRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }

    }
}
