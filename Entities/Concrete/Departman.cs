using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Departman :BaseEntity
    {
        public string Kod { get; set; }
        public string Ad { get; set; }
        public ICollection<PersonelDepartman> PersonelDepartmans { get; set; }

    }
}
