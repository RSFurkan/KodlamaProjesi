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
using Business.Handlers.Personels.ValidationRules;

namespace Business.Handlers.PersonelDepartmans.Commands
{
    public class CreatePersonelDepartmenCommand : IRequest<IResult>
    {
        public int PersonelId { get; set; }
        public int DepartmanId { get; set; }
        public class CreatePersonelDepartmenCommandHandler : IRequestHandler<CreatePersonelDepartmenCommand, IResult>
        {

            private readonly IPersonelDepartmanRepository _personelDepartmanRepository;
            private readonly IMediator _mediator;
            public CreatePersonelDepartmenCommandHandler(IPersonelDepartmanRepository personelDepartmanRepository, IMediator mediator)
            {
                _personelDepartmanRepository = personelDepartmanRepository;
                _mediator = mediator;
            }
            // validation burada gerçekleşecek : todo
            // [ValidationAspect(typeof(CreatePersonelValidator))] 

            public async Task<IResult> Handle(CreatePersonelDepartmenCommand request, CancellationToken cancellationToken)
            {
                // bir kişinin bir departmanı olabilir diye düşündüm
                var isthereRecord = _personelDepartmanRepository.Query().Any(personel => personel.PersonelId == request.PersonelId && personel.DepartmanId == request.DepartmanId);

                //kayıt var ise ekleme yapılmayacak mesaj sabitlerinden uyarı mesajı dönecek.
                if (isthereRecord == true)
                    return new ErrorResult(Messages.AlreadyExist);
                var addedPersonelDepartment = new PersonelDepartman()
                {
                    DepartmanId = request.DepartmanId,
                    PersonelId = request.PersonelId,
                    IsDeleted = false
                };
                _personelDepartmanRepository.Add(addedPersonelDepartment);
                await _personelDepartmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);


            }
        } 
    }
}
