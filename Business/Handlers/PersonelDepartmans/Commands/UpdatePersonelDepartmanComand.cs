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
    public class UpdatePersonelDepartmanComand : IRequest<IResult>
    {
        public int Id { get; set; } 
        public int PersonelId { get; set; }
        public int DepartmanId { get; set; }

        public class UpdateDepartmanCommandHandler : IRequestHandler<UpdatePersonelDepartmanComand, IResult>
        {

            private readonly IPersonelDepartmanRepository _personelDepartmanRepository;
            private readonly IMediator _mediator;

            public UpdateDepartmanCommandHandler(IPersonelDepartmanRepository personelDepartmanRepository, IMediator mediator)
            {
                _personelDepartmanRepository = personelDepartmanRepository;
                _mediator = mediator;
            }
            // validation burada gerçekleşecek : todo 
            // [ValidationAspect(typeof(CreatePersonelDepartmentValidator))]

            public async Task<IResult> Handle(UpdatePersonelDepartmanComand request, CancellationToken cancellationToken)
            {
                var isThereRecord = await _personelDepartmanRepository.GetAsync(personelDepartment => personelDepartment.Id == request.Id);

                isThereRecord.PersonelId=request.PersonelId;
                isThereRecord.DepartmanId =request.DepartmanId;

                _personelDepartmanRepository.Update(isThereRecord);
                await _personelDepartmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated); 
            }
        }
    }
}
