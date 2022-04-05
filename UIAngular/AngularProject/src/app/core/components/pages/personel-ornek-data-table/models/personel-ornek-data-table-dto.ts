export class PersonelOrnekDataTableDto
{
    id?: number; 
    sicilNumarasi?: string;
    ad?: string;
    soyad?: string;
    cinsiyet?: string; 
    cepTelefonu?: string; 
    evTelefonu: string;  
    mailAdresi?: string;  
    kod?: string;
    departmentAd?: string;
    iseGirisTarihi?: (Date | any);
    istenCikisTarihi?: (Date | any);
}