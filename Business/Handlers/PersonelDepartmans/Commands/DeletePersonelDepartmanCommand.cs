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

namespace Business.Handlers.PersonelDepartmans.Commands
{
    public class DeletePersonelDepartmanCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteDepartmentCommandHandler : IRequestHandler<DeletePersonelDepartmanCommand, IResult>
        {

            private readonly IPersonelDepartmanRepository _personelDepartmanRepository;
            private readonly IMediator _mediator;


            public DeleteDepartmentCommandHandler(IPersonelDepartmanRepository personelDepartmanRepository, IMediator mediator)
            {
                _personelDepartmanRepository = personelDepartmanRepository;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(DeletePersonelDepartmanCommand request, CancellationToken cancellationToken)
            {
                var personelDepartmentToDelete = _personelDepartmanRepository.Get(personelDepartment => personelDepartment.Id == request.Id);
                personelDepartmentToDelete.IsDeleted = true;

                _personelDepartmanRepository.Update(personelDepartmentToDelete);
                await _personelDepartmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);

            }
        }
    }
}
