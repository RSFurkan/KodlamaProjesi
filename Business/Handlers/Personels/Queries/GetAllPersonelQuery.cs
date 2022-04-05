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

namespace Business.Handlers.Personels.Queries
{
    public class GetAllPersonelQuery :IRequest<IDataResult<IEnumerable<Entities.Concrete.Personel>>>
    {
        public class GetAllPersonelQueryyHandler : IRequestHandler<GetAllPersonelQuery, IDataResult<IEnumerable<Entities.Concrete.Personel>>>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMediator _mediator;
            public GetAllPersonelQueryyHandler(IPersonelRepository personelRepository, IMediator mediator)
            {
                _personelRepository = personelRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<Entities.Concrete.Personel>>> Handle(GetAllPersonelQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Entities.Concrete.Personel>>(await _personelRepository.GetListAsync(b => b.IsDeleted == false));
            }
        }
    }
}
