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
namespace Business.Handlers.Departman.Queries
{
    public class GetDepartmentsQuery :  IRequest<IDataResult<IEnumerable<Entities.Concrete.Departman>>>
    {
        public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IDataResult<IEnumerable<Entities.Concrete.Departman>>>
        {
            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMediator _mediator;
            public GetDepartmentsQueryHandler(IDepartmanRepository departmanRepository, IMediator mediator)
            {
                _departmanRepository = departmanRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<Entities.Concrete.Departman>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Entities.Concrete.Departman>>(await _departmanRepository.GetListAsync(b => b.IsDeleted == false));
            }
        } 
    }
}
