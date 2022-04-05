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

namespace Business.Handlers.Departman.Commands
{
    public class CreateDepartmanCommand : IRequest<IResult>
    {
        public string Kod { get; set; }
        public string Ad { get; set; }

        public class CreateDepartmanCommandHandler : IRequestHandler<CreateDepartmanCommand, IResult>
        {
            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMediator _mediator;

            public CreateDepartmanCommandHandler(IDepartmanRepository departmanRepository, IMediator mediator)
            {
                _departmanRepository = departmanRepository;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(CreateDepartmanCommand request, CancellationToken cancellationToken)
            {
                var isthereRecord = _departmanRepository.Query().Any(x => x.Kod == request.Kod);

                //kayıt var ise ekleme yapılmayacak mesaj sabitlerinden uyarı mesajı dönecek.
                if (isthereRecord == true)
                    return new ErrorResult(Messages.AlreadyExist);

                var addedDepartment = new Entities.Concrete.Departman
                {
                    Ad = request.Ad,
                    IsDeleted = false,
                    Kod = request.Kod
                };
                _departmanRepository.Add(addedDepartment);
                await _departmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added); 

            }
        }

    }
}
