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
using Entities.Dtos;

namespace Business.Handlers.Departman.Queries
{
    public class GetDepartmentsLookUpQuery : IRequest<IDataResult<IEnumerable<SelectionItem>>>
    {

        public class GetBandsLookUpQueryHandler : IRequestHandler<GetDepartmentsLookUpQuery, IDataResult<IEnumerable<SelectionItem>>>
        {
            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMediator _mediator;
            public GetBandsLookUpQueryHandler(IDepartmanRepository departmanRepository, IMediator mediator)
            {
                _departmanRepository = departmanRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<SelectionItem>>> Handle(GetDepartmentsLookUpQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<SelectionItem>>(await _departmanRepository.GetDepartmentsLookUp());
            }
        }

    }
}
