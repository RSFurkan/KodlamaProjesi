using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelDepartman : BaseEntity
    {
        public int PersonelId { get; set; }
        public int DepartmanId { get; set; }
        public Personel Personel { get; set; }
        public Departman Departman { get; set; }

    }
}
