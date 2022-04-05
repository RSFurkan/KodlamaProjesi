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

namespace Business.Handlers.PersonelOrnekDataTables.Queries
{
    public class GetAllPersonelOrnekDataTableDtoQuery : IRequest<IDataResult<IEnumerable<Entities.Dtos.OrnekDataDto>>>
    {

        public class GetAllPersonelOrnekDataTableDtoQueryHandler : IRequestHandler<GetAllPersonelOrnekDataTableDtoQuery, IDataResult<IEnumerable<Entities.Dtos.OrnekDataDto>>>
        {

            private readonly IPersonelOrnekDataTableRepository _personelOrnekDataTableRepository;
            private readonly IMediator _mediator;
            public GetAllPersonelOrnekDataTableDtoQueryHandler(IPersonelOrnekDataTableRepository personelOrnekDataTableRepository, IMediator mediator)
            {
                _personelOrnekDataTableRepository = personelOrnekDataTableRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<OrnekDataDto>>> Handle(GetAllPersonelOrnekDataTableDtoQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<OrnekDataDto>>(await _personelOrnekDataTableRepository.GetOrnekDataDtos());
            }
        }
    }
}
