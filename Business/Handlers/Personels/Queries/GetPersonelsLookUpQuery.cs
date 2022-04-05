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

namespace Business.Handlers.Personels.Queries
{
    public class GetPersonelsLookUpQuery : IRequest<IDataResult<IEnumerable<SelectionItem>>>
    {
        public class GetPersonelsLookUpQueryHandler : IRequestHandler<GetPersonelsLookUpQuery, IDataResult<IEnumerable<SelectionItem>>>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMediator _mediator;
            public GetPersonelsLookUpQueryHandler(IPersonelRepository personelRepository, IMediator mediator)
            {
                _personelRepository = personelRepository;
                _mediator = mediator;
            }

            public async Task<IDataResult<IEnumerable<SelectionItem>>> Handle(GetPersonelsLookUpQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<SelectionItem>>(await _personelRepository.GetPersonelLookUp());
            }
        }
        }
}
