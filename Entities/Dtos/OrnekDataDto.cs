using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrnekDataDto
    {
        public string SicilNumarasi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string DepartmanKodu { get; set; }
        public string DepartmanAdi { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public DateTime IstenCikisTarihi { get; set; }
        public string MailAdresi { get; set; }
        public string Cinsiyeti { get; set; }
        public string CepTelefonu { get; set; }
        public string EvTelefonu { get; set; }


    }
}
