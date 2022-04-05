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
    public class DeleteDepartmentCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, IResult>
        {

            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMediator _mediator;

            public DeleteDepartmentCommandHandler(IDepartmanRepository departmanRepository, IMediator mediator)
            {
                _departmanRepository = departmanRepository;
                _mediator = mediator;
            }
           // [ValidationAspect(typeof(UpdateDepartmanCommand))] 

            public async Task<IResult> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                var departmentToDelete =_departmanRepository.Get(department=>department.Id==request.Id);
                 departmentToDelete.IsDeleted = true;

                _departmanRepository.Update(departmentToDelete);
                await _departmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);  

            }
        }
        }
}
