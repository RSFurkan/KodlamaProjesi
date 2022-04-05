using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class PersonelRepository : EfEntityRepositoryBase<Personel, ProjectDbContext>, IPersonelRepository
    {
        public PersonelRepository(ProjectDbContext context) : base(context)
        {
        }


        

        public Task<List<SelectionItem>> GetPersonelLookUp()
        {
            var lookUp = (from entity in Context.Personel
                          where entity.IsDeleted == false
                          select new SelectionItem()
                          {
                              Id = entity.Id,
                              Label = entity.Ad + " " + entity.SoyAd,
                              ParentId=entity.SicilNumarasi

                          }).ToListAsync();
            return lookUp;
        }
    }
}
