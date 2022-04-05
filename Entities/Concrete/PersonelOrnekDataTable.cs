using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelOrnekDataTable : BaseEntity
    {
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public DateTime IstenCikisTarihi { get; set; } 

    }
}
