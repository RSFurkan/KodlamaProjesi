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
    public class PersonelOrnekDataTableRepository : EfEntityRepositoryBase<PersonelOrnekDataTable, ProjectDbContext>, IPersonelOrnekDataTableRepository
    {
        public PersonelOrnekDataTableRepository(ProjectDbContext context) : base(context)
        {
        }
        public async Task<List<OrnekDataDto>> GetOrnekDataDtos()
        {
            //excelldeki örnek datayı oluşturan sorgu. store procedure proje ekinde yer alan work dosyasında yer almaktadır.

            var list = await (from p in Context.Personel
                              join pd in Context.PersonelOrnekDataTable on p.Id equals pd.PersonelId
                              join pdep in Context.PersonelDepartman on p.Id equals pdep.PersonelId
                              join dep in Context.Departman on pdep.DepartmanId equals dep.Id
                              where p.IsDeleted == false && pd.IsDeleted == false && pdep.IsDeleted == false
                              && dep.IsDeleted==false
                              select new OrnekDataDto()
                              {
                                  Adi = p.Ad,
                                  CepTelefonu = p.CepTelefonu,
                                  Cinsiyeti=p.CepTelefonu,
                                  EvTelefonu=p.EvTelefonu,
                                  IseGirisTarihi=pd.IseGirisTarihi,
                                  IstenCikisTarihi=pd.IstenCikisTarihi,
                                  MailAdresi=p.MailAdresi,
                                  SicilNumarasi=p.SicilNumarasi,
                                  Soyadi=p.SoyAd ,
                                  DepartmanAdi=dep.Ad,
                                  DepartmanKodu=dep.Kod 
                              }
                              ).ToListAsync();
            return list;

        }

    }
}
