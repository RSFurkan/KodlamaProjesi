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
namespace Business.Handlers.PersonelDepartmans.Queries
{
    public class GetAllPersonelDepartmanQuery  : IRequest<IDataResult<IEnumerable<Entities.Concrete.PersonelDepartman>>>
    {

        public class GetAllPersonelDepartmanQueryHandler : IRequestHandler<GetAllPersonelDepartmanQuery, IDataResult<IEnumerable<Entities.Concrete.PersonelDepartman>>>
        {
            private readonly IPersonelDepartmanRepository _personelDepartmanRepository;
            private readonly IMediator _mediator;
            public GetAllPersonelDepartmanQueryHandler(IPersonelDepartmanRepository personelDepartmanRepository, IMediator mediator)
            {
                _personelDepartmanRepository = personelDepartmanRepository;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<Entities.Concrete.PersonelDepartman>>> Handle(GetAllPersonelDepartmanQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Entities.Concrete.PersonelDepartman>>(await _personelDepartmanRepository.GetListAsync(b => b.IsDeleted == false));
            }

           
        }
    }
}
