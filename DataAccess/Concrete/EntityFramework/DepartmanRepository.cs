using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.EntityFramework
{
    public class DepartmanRepository : EfEntityRepositoryBase<Departman, ProjectDbContext>, IDepartmanRepository
    {
        public DepartmanRepository(ProjectDbContext context) : base(context)
        {

        }

        public Task<List<SelectionItem>> GetDepartmentsLookUp()
        {
            var lookUp = (from entity in Context.Departman
                          where entity.IsDeleted == false
                          select new SelectionItem()
                          {
                              Id = entity.Id,
                              Label = entity.Ad,
                          }).ToListAsync();
            return lookUp;
        }
    }
}
