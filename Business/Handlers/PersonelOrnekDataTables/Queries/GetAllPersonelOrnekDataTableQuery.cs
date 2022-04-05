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

namespace Business.Handlers.PersonelOrnekDataTables.Queries
{
    public class GetAllPersonelOrnekDataTableQuery : IRequest<IDataResult<IEnumerable<PersonelOrnekDataTable>>>
    {
        public class GetAllPersonelOrnekDataTableQueryHandler : IRequestHandler<GetAllPersonelOrnekDataTableQuery, IDataResult<IEnumerable<Entities.Concrete.PersonelOrnekDataTable>>>
        {
            private readonly IPersonelOrnekDataTableRepository _personelOrnekDataTableRepository;
            private readonly IMediator _mediator;
            public GetAllPersonelOrnekDataTableQueryHandler(IPersonelOrnekDataTableRepository personelOrnekDataTableRepository, IMediator mediator)
            {
                _personelOrnekDataTableRepository = personelOrnekDataTableRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<Entities.Concrete.PersonelOrnekDataTable>>> Handle(GetAllPersonelOrnekDataTableQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Entities.Concrete.PersonelOrnekDataTable>>(await _personelOrnekDataTableRepository.GetListAsync(b => b.IsDeleted == false));
            }
        }
    }
}
