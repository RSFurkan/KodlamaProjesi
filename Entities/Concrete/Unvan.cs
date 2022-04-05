using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Unvan : BaseEntity
    {
        public string UnvanKodu { get; set; }
        public string UnvanAdi { get; set; }
        public ICollection<PersonelUnvan> PersonelUnvans { get; set; }

    }
}
