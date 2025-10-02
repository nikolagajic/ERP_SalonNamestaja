using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_SalonNamestaja.DTO.StavkaKorpeDTO
{
    public class GetStavkaKorpeDto
    {
        public int StavkaId { get; set; }
        public int ProizvodId { get; set;}
        public string? SifraProizvod { get; set; }
        public int Kolicina { get; set; }
        public string? Naziv { get; set; }
        public double? Cena { get; set; }
    }
}