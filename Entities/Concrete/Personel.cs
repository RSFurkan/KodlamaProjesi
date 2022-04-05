using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Personel : BaseEntity
    {
        public string SicilNumarasi { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }   
        public string Cinsiyet { get; set; }
        public string CepTelefonu { get; set; }  
        public string MailAdresi { get; set; }
        //Bir personel birden fazla kez işe girip çıkabilir.
        public ICollection<PersonelOrnekDataTable> PersonelOrnekDataTables { get; set; }
        public ICollection<PersonelDepartman> PersonelDepartmans { get; set; }

    }
}
