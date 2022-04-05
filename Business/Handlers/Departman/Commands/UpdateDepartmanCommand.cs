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
    public class UpdateDepartmanCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string Ad { get; set; }

        public class UpdateDepartmanCommandHandler : IRequestHandler<UpdateDepartmanCommand, IResult>
        {
            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMediator _mediator;
            public UpdateDepartmanCommandHandler(IDepartmanRepository departmanRepository, IMediator mediator)
            {
                _departmanRepository = departmanRepository;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(UpdateDepartmanCommand request, CancellationToken cancellationToken)
            {
               var isThereRecord=await _departmanRepository.GetAsync(department=> department.Id==request.Id);

                isThereRecord.Kod=request.Kod;
                isThereRecord.Ad=request.Ad;

                _departmanRepository.Update(isThereRecord);
                await _departmanRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);


            }
        }
    }

}
