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
    }
}
