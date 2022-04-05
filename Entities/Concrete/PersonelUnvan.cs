using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelUnvan : BaseEntity
    {
        public int PersonelId { get; set; }
        public int UnvanId { get; set; }
        public Personel Personel { get; set; }
        public Unvan Unvan { get; set; }

    }
}
