using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.StavkaKorpeDTO;

namespace ERP_SalonNamestaja.DTO.KorpaDTO
{
    public class GetKorpaDto
    {
        public int KorpaId { get; set; }
        public int KorisnikId { get; set; }

        public List<GetStavkaKorpeDto> Stavke { get; set; } = new();
        //public decimal Ukupno => Stavke.Sum(s => s.Kolicina * s.Cena);

    }
}